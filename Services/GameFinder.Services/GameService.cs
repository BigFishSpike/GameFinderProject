namespace GameFinder.Services
{
    using GameFinder.Data;
    using GameFinder.Data.Models;
    using GameFinder.Services.DTOs;
    using GameFinder.Services.Interfaces;
    using Microsoft.EntityFrameworkCore;

    public class GameService : IGameService
    {
        private readonly GameFinderDbContext dbContext;

        public GameService(GameFinderDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task <IEnumerable<GameDto>> FindGames(GameFindDto criteria)
        {
            IQueryable<Game> findGames = dbContext.Games;

            if (!string.IsNullOrWhiteSpace(criteria.Genre))
            {
                findGames = findGames
                    .Where(g => g.Genre.Name == criteria.Genre);
            }

            if (criteria.Difficulty.HasValue)
            {
                findGames = findGames
                    .Where(g => g.Difficulties
                    .Any(gd => gd.Difficulty == criteria.Difficulty.Value));
            }

            if (criteria.PlayerOptions.HasValue)
            {
                findGames = findGames
                    .Where(g => g.PlayerOptions
                    .Any(po => po.PlayerOption == criteria.PlayerOptions.Value));
            }

            if (criteria.Mode.HasValue)
            {
                findGames = findGames
                    .Where(g => g.Modes
                    .Any(m => m.Mode == criteria.Mode.Value));
            }

            return await findGames
                .Select(g => new GameDto
                {
                    Id = g.Id,
                    Name = g.Name,
                    ImageUrl = g.ImageUrl,
                })
                .ToListAsync();

        }

        public async Task<IEnumerable<GameDto>> GetGamesList(int gamesPerPage)
        {
            return await dbContext.Games
               .OrderBy(g => g.GenreId)
               .ThenBy(g => g.Name)
               .Take(gamesPerPage)
               .Select(g => new GameDto()
               {
                   Id = g.Id,
                   Name = g.Name,
                   ImageUrl = g.ImageUrl,
                   GenreName = g.Genre.Name,
               })
               .ToArrayAsync();
        }

        public async Task<GameDetailsDto?> GetGameDetails(int id)
        {
            return await dbContext.Games
                .Where(g => g.Id == id)
                .Select(g => new GameDetailsDto()
                {
                    Id = g.Id,
                    Name = g.Name,
                    Description = g.Description,
                    GenreId = g.Genre.Id,
                    CreatedByUserId = g.CreatedByUserId,

                    Difficulties = g.Difficulties 
                    .Select(gd => gd.Difficulty)
                    .ToList(),

                    PlayerOptions = g.PlayerOptions
                    .Select(po => po.PlayerOption)
                    .ToList(),

                    Modes = g.Modes
                    .Select(m => m.Mode)
                    .ToList(),
                    ImageUrl = g.ImageUrl,
                    ReleaseDate = g.ReleaseDate,
                })
                .SingleOrDefaultAsync();
        }

        public async Task<int> AddGame(GameAddDto gameDto)
        {
            Game game = new Game
            {
                Name = gameDto.Name,
                Description = gameDto.Description,
                ImageUrl = gameDto.ImageUrl,
                ReleaseDate = gameDto.ReleaseDate,
                GenreId = gameDto.GenreId,
                CreatedByUserId = gameDto.CreatedByUser,

                Difficulties = gameDto.Difficulties
                .Distinct()
                .Select(difficulty => new GameDifficulty 
                {
                    Difficulty = difficulty
                })
                .ToList(),
                PlayerOptions = gameDto.PlayerOptions
                .Distinct()
                .Select(playerOption => new GamePlayerOption
                {
                    PlayerOption = playerOption
                })
                .ToList(),Modes = gameDto.Modes
                .Select(mode => new GameMode
                {
                    Mode = mode
                })
                .ToList()};
            
            await dbContext.Games.AddAsync(game);
            await dbContext.SaveChangesAsync();

            return game.Id;
        }

        public async Task<bool> UpdateGame(GameUpdateDto gameDto, string userId)
        {
            Game? game = await dbContext.Games
                .Include(g => g.Difficulties)
                .Include(g => g.PlayerOptions)
                .Include(g => g.Modes)
                .SingleOrDefaultAsync(g => g.Id == gameDto.Id);

            if (game == null)
            {
                return false;
            }

            if (game.CreatedByUserId != userId)
            {
                return false;
            }
            game.Name = gameDto.Name;
            game.Description = gameDto.Description;
            game.ImageUrl = gameDto.ImageUrl;
            game.ReleaseDate = gameDto.ReleaseDate;
            game.GenreId = gameDto.GenreId;

            dbContext.RemoveRange(game.Difficulties);
            game.Difficulties = gameDto.Difficulties
                .Distinct()
                .Select(difficulty => new GameDifficulty
                {
                    GameId = game.Id,
                    Difficulty = difficulty
                })
                .ToList();

            dbContext.RemoveRange(game.PlayerOptions);
            game.PlayerOptions = gameDto.PlayerOptions
                .Distinct()
                .Select(playerOption => new GamePlayerOption
                {
                    GameId = game.Id,
                    PlayerOption = playerOption
                })
                .ToList();

            dbContext.RemoveRange(game.Modes);
            game.Modes = gameDto.Modes
                .Distinct()
                .Select(mode => new GameMode
                {
                    GameId = game.Id,
                    Mode = mode
                })
                .ToList();

            await dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteGame(int id, string userId)
        {
            Game? game = await dbContext.Games.SingleOrDefaultAsync(g => g.Id == id);

            if (game == null)
            {
                return false;
            }

            if (game.CreatedByUserId != userId)
            {
                return false;
            }

            dbContext.Games.Remove(game);

            await dbContext.SaveChangesAsync();

            return true;
        }
    }
}
