using GameFinder.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameFinder.Services.Interfaces
{
    public interface IUserFavouriteService
    {
        Task<bool> AddFavouriteAsync(string userId, int gameId);

        Task<bool> RemoveFavouriteAsync(string userId, int gameId);

        Task<bool> IsFavouriteAsync(string userId, int gameId);

        Task<IEnumerable<GameDto>> GetUserFavouritesAsync(string userId);

    }
}
