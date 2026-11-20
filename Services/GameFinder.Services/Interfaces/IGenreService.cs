namespace GameFinder.Services.Interfaces
{
    using GameFinder.Services.DTOs;

    public interface IGenreService
    {
        Task<IEnumerable<GenreDto>> GenresGetList();

        Task<GenreDetailsDto?> GenreGetDetails(int id); 

        Task<int> GenreAdd(GenreAddDto genreDto);

        Task<bool> GenreEdit(GenreEditDto genreDto, string userId, bool isAdmin);

        Task<bool> GenreDelete(int id, string userId, int replacementGenreId, bool isAdmin);
    }
}
