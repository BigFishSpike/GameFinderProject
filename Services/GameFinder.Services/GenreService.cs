namespace GameFinder.Services
{
    using GameFinder.Data;
    using GameFinder.Data.Models;
    using GameFinder.Services.DTOs;
    using GameFinder.Services.Interfaces;
    using Microsoft.EntityFrameworkCore;

    public class GenreService : IGenreService
    {
        private readonly GameFinderDbContext dbContext;

        public GenreService(GameFinderDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<GenreDto>> GenresGetList()
        {
            return await dbContext.Genres
                .OrderBy(g => g.Id)
                .ThenBy(g => g.Name)
                .Select(g => new GenreDto()
                {
                    Id = g.Id,
                    Name = g.Name,
                    ImageUrl = g.ImageUrl,
                })
                .ToListAsync();
        }

        public async Task<GenreDetailsDto?> GenreGetDetails(int id)
        {

            return await dbContext.Genres
                .Where(g => g.Id == id)
                .Select(g => new GenreDetailsDto
                {
                    Id = g.Id,
                    Name = g.Name,
                    ImageUrl = g.ImageUrl,
                    Description = g.Description,
                    CreatedByUserId = g.CreatedByUserId,

                    Games = g.Games
                    .OrderBy(ga => ga.Name)
                    .Select(ga => new GameDto()
                    {
                        Id = ga.Id,
                        Name = ga.Name,
                        ImageUrl = ga.ImageUrl,
                    })
                    .ToList()
                })
                .SingleOrDefaultAsync();

        }

        public async Task<int> GenreAdd(GenreAddDto genreDto)
        {
            
            bool nameExists = await dbContext.Genres.AnyAsync(g => g.Name == genreDto.Name);

            if (nameExists)
            {
                return 0;
            }


            Genre genre = new Genre
            {
                Name = genreDto.Name,
                Description = genreDto.Description,
                ImageUrl = genreDto.ImageUrl,
                CreatedByUserId = genreDto.CreatedByUserId
            };

            dbContext.Genres.Add(genre);

            await dbContext.SaveChangesAsync();

            return genre.Id;
        }
        public async Task<bool> GenreEdit(GenreEditDto genreDto, string userId)
        {
            Genre? genre = await dbContext.Genres.SingleOrDefaultAsync(g => g.Id == genreDto.Id);

            if (genre == null)
            {
                return false;
            }

            if (genre.CreatedByUserId != userId)
            {
                return false;
            }

            bool nameExists = await dbContext.Genres.AnyAsync(g => g.Name == genreDto.Name && g.Id != genreDto.Id);

            if (nameExists)
            {
                return false;
            }

            genre.Name = genreDto.Name;
            genre.Description = genreDto.Description;
            genre.ImageUrl = genreDto.ImageUrl;

            await dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<bool> GenreDelete(int id, string userId, int replacementGenreId)
        {
            Genre? genre = await dbContext.Genres
                .Include(g => g.Games)
                .SingleOrDefaultAsync(g => g.Id == id);

            if (genre == null)
            {
                return false;
            }

            if (genre.CreatedByUserId != userId)
            {
                return false;
            }

            if (id == replacementGenreId)
            {
                return false;
            }

            Genre? replacementGenre = await dbContext.Genres.SingleOrDefaultAsync(g => g.Id == replacementGenreId);

            if (replacementGenre == null)
            {
                return false;
            }

            foreach (Game game in genre.Games)
            {
                game.GenreId = replacementGenreId;
            }

            dbContext.Genres.Remove(genre);

            await dbContext.SaveChangesAsync();

            return true;
        }
    }
    
}

