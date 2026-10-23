namespace GameFinder.Services
{
    using GameFinder.Data;
    using GameFinder.Data.Models;
    using GameFinder.Services.DTOs;
    using GameFinder.Services.Interfaces;
    using Microsoft.EntityFrameworkCore;

    public class UserFavouriteService : IUserFavouriteService
    {
        private readonly GameFinderDbContext dbContext;

        public UserFavouriteService(GameFinderDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<IEnumerable<GameDto>> GetUserFavouritesAsync(string userId)
        {
            List<GameDto> favourites = await dbContext.UserFavourites
                .Where(uf => uf.UserId == userId)
                .OrderBy(uf => uf.Game.Name)
                .Select(uf => new GameDto
                {
                    Id = uf.Game.Id,
                    Name = uf.Game.Name,
                    ImageUrl = uf.Game.ImageUrl,
                    GenreName = uf.Game.Genre.Name,
                })
                .ToListAsync();

            return favourites;
        }

        public async Task<bool> AddFavouriteAsync(string userId, int gameId)
        {
            bool alreadyAdded = await dbContext.UserFavourites
                .AnyAsync(uf => uf.UserId == userId && uf.GameId == gameId);

            if (alreadyAdded)
            {
                return false;
            }

            bool validUser = await dbContext.Users
                .AnyAsync(user => user.Id == userId);

            bool validGame = await dbContext.Games
                .AnyAsync(game => game.Id == gameId);

            if (!validUser || !validGame)
            {
                return false;
            }

            UserFavourite newFavourite = new UserFavourite
            {
                UserId = userId,
                GameId = gameId
            };

            await dbContext.UserFavourites.AddAsync(newFavourite);
            await dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<bool> IsFavouriteAsync(string userId, int gameId)
        {
            return await dbContext.UserFavourites
                .AnyAsync(uf => uf.UserId == userId && uf.GameId == gameId);
        }

        public async Task<bool> RemoveFavouriteAsync(string userId, int gameId)
        {
            UserFavourite? favourite = await dbContext.UserFavourites
                .FirstOrDefaultAsync(uf => uf.UserId == userId && uf.GameId == gameId);
            
            if (favourite == null)
            {
                return false;
            }
            
            dbContext.UserFavourites.Remove(favourite);
            await dbContext.SaveChangesAsync();

            return true;
        }
    }
}
