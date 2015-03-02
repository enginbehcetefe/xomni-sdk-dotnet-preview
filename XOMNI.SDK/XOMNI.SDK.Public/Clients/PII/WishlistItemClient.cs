using System;
using System.Net.Http;
using System.Threading.Tasks;
using XOMNI.SDK.Public.Clients;
using XOMNI.SDK.Public.Models;
using XOMNI.SDK.Public.Models.PII;
using XOMNI.SDK.Public.Extensions;

namespace XOMNI.SDK.Public.Clients.PII
{
    public class WishlistItemClient : BaseClient
    {
        public WishlistItemClient(HttpClient httpClient)
            : base(httpClient)
        {

        }

        public async Task DeleteWishlistItemAsync(Guid wishlistItemUniqueKey, Location location = null)
        {
            string path = string.Format("/pii/wishlistitem?wishlistItemUniqueKey={0}", wishlistItemUniqueKey);

            if (location != null)
            {
                Validator.For(location.Latitude, "Latitude").InRange(-90, 90);
                Validator.For(location.Longitude, "Longitude").InRange(-180, 180);
                path += string.Format("&longitude={0}&latitude={1}", location.Longitude, location.Latitude);
            }
            await Client.DeleteAsync(path).ConfigureAwait(false);
        }

        public async Task DeleteWishlistItemsAsync(Guid wishlistUniqueKey, Location location = null)
        {
            string path = string.Format("/pii/wishlistitems?wishlistUniqueKey={0}", wishlistUniqueKey);

            if (location != null)
            {
                Validator.For(location.Latitude, "Latitude").InRange(-90, 90);
                Validator.For(location.Longitude, "Longitude").InRange(-180, 180);
                path += string.Format("&longitude={0}&latitude={1}", location.Longitude, location.Latitude);
            }
            await Client.DeleteAsync(path).ConfigureAwait(false);
        }

        public async Task<ApiResponse<WishlistItem>> PostAsync(Guid wishlistUniqueKey, WishlistItem wishlistItem)
        {
            ValidatePIIToken();
            Validator.For(wishlistItem, "wishlistItem").IsNotNull();
            Validator.For(wishlistItem.ItemId, "ItemId").IsGreaterThanOrEqual(1);

            if (wishlistItem.LastSeenLocation != null)
            {
                Validator.For(wishlistItem.LastSeenLocation.Latitude, "Latitude").InRange(-90, 90);
                Validator.For(wishlistItem.LastSeenLocation.Longitude, "Longitude").InRange(-180, 180);
            }
            string path = string.Format("/pii/wishlistitem?wishlistUniqueKey={0}", wishlistUniqueKey);

            using (var response = await Client.PostAsJsonAsync(path, wishlistItem).ConfigureAwait(false))
            {
                return await response.Content.ReadAsAsync<ApiResponse<WishlistItem>>().ConfigureAwait(false);
            }
        }
    }
}