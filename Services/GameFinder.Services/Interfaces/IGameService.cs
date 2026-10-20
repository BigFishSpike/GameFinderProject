using GameFinder.Services.DTOs;

namespace GameFinder.Services.Interfaces
{
    public interface IGameService
    {
        Task<IEnumerable<GameDto>> GetGamesList(int entities);

        Task<IEnumerable<GameDto>> FindGames(GameFindDto userRequests);

        Task<GameDetailsDto?> GetGameDetails(int id);

        Task<int> AddGame(GameAddDto gameDto);

        Task<bool> UpdateGame(GameUpdateDto gameDto, string userId);

        Task<bool> DeleteGame(int id, string userId);
    }
}
