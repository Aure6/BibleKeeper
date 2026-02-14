using Blazored.LocalStorage;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BibleKeeper.Client.Models;

namespace BibleKeeper.Client.Services
{
    public class FavoritesService
    {
        private readonly ILocalStorageService _localStorage;
        private const string Key = "user_favorites"; // La clé de stockage dans le navigateur

        public FavoritesService(ILocalStorageService localStorage)
        {
            _localStorage = localStorage;
        }

        // 1. Récupérer tous les favoris
        public async Task<List<BibleFavorite>> GetFavoritesAsync()
        {
            return await _localStorage.GetItemAsync<List<BibleFavorite>>(Key)
                   ?? new List<BibleFavorite>();
        }

        // 2. Ajouter un favori (depuis l'API vers le LocalStorage)
        public async Task AddFavoriteAsync(BibleFavorite favorite)
        {
            var favorites = await GetFavoritesAsync();
            favorites.Add(favorite);
            await _localStorage.SetItemAsync(Key, favorites);
        }

        // 3. Modifier un favori
        public async Task UpdateFavoriteAsync(BibleFavorite updatedFavorite)
        {
            var favorites = await GetFavoritesAsync();

            // On trouve l'élément à modifier via son ID
            var index = favorites.FindIndex(f => f.Id == updatedFavorite.Id);

            if (index != -1)
            {
                updatedFavorite.LastModified = DateTime.UtcNow;
                favorites[index] = updatedFavorite; // On remplace l'ancien par le nouveau
                await _localStorage.SetItemAsync(Key, favorites);
            }
        }

        // 4. Supprimer un favori
        public async Task DeleteFavoriteAsync(Guid id)
        {
            var favorites = await GetFavoritesAsync();
            var itemToRemove = favorites.FirstOrDefault(f => f.Id == id);

            if (itemToRemove != null)
            {
                favorites.Remove(itemToRemove);
                await _localStorage.SetItemAsync(Key, favorites);
            }
        }
    }
}