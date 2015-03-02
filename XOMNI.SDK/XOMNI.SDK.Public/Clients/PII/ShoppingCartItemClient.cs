using System;
using System.Net.Http;
using System.Threading.Tasks;
using XOMNI.SDK.Public.Clients;
using XOMNI.SDK.Public.Models;
using XOMNI.SDK.Public.Models.PII;
using XOMNI.SDK.Public.Extensions;

namespace XOMNI.SDK.Public.Clients.PII
{
    public class ShoppingCartItemClient : BaseClient
    {
        public ShoppingCartItemClient(HttpClient httpClient)
            : base(httpClient)
        {

        }

        public async Task<ApiResponse<ShoppingCartItem>> PutAsync(Guid shoppingCartItemUniqueKey, int quantity, Location lastSeenLocation = null)
        {
            Validator.For(quantity, "quantity").IsGreaterThanOrEqual(0);

            string path = string.Format("/pii/shoppingcartitem?shoppingCartItemUniqueKey={0}&quantity={1}", shoppingCartItemUniqueKey, quantity);

            if (lastSeenLocation != null)
            {
                Validator.For(lastSeenLocation.Latitude, "Latitude").InRange(-90, 90);
                Validator.For(lastSeenLocation.Longitude, "Longitude").InRange(-180, 180);
                path += string.Format("&longitude={0}&latitude={1}", lastSeenLocation.Longitude, lastSeenLocation.Latitude);
            }

            using (var response = await Client.PutAsJsonAsync(path, string.Empty).ConfigureAwait(false))
            {
                return await response.Content.ReadAsAsync<ApiResponse<ShoppingCartItem>>().ConfigureAwait(false);
            }
        }

        public async Task DeleteShoppingCartItemAsync(Guid shoppingCartItemUniqueKey, Location lastSeenLocation = null)
        {
            ValidatePIIToken();

            string path = string.Format("/pii/shoppingcartitem?shoppingCartItemUniqueKey={0}", shoppingCartItemUniqueKey);
            if (lastSeenLocation != null)
            {
                Validator.For(lastSeenLocation.Latitude, "Latitude").InRange(-90, 90);
                Validator.For(lastSeenLocation.Longitude, "Longitude").InRange(-180, 180);
                path += string.Format("&longitude={0}&latitude={1}", lastSeenLocation.Longitude, lastSeenLocation.Latitude);
            }

            await Client.DeleteAsync(path).ConfigureAwait(false);
        }

        public async Task DeleteShoppingCartItemsAsync(Guid shoppingCartUniqueKey, Location lastSeenLocation = null)
        {
            ValidatePIIToken();

            string path = string.Format("/pii/shoppingcartitems?shoppingCartUniqueKey={0}", shoppingCartUniqueKey);
            if (lastSeenLocation != null)
            {
                Validator.For(lastSeenLocation.Latitude, "Latitude").InRange(-90, 90);
                Validator.For(lastSeenLocation.Longitude, "Longitude").InRange(-180, 180);
                path += string.Format("&longitude={0}&latitude={1}", lastSeenLocation.Longitude, lastSeenLocation.Latitude);
            }

            await Client.DeleteAsync(path).ConfigureAwait(false);
        }

        public async Task<ApiResponse<ShoppingCartItem>> PostAsync(Guid shoppingCartUniqueKey, ShoppingCartItem shoppingCartItem)
        {
            ValidatePIIToken();
            Validator.For(shoppingCartItem, "shoppingCartItem").IsNotNull();
            Validator.For(shoppingCartItem.ItemId, "ItemId").IsGreaterThanOrEqual(1);
            Validator.For(shoppingCartItem.Quantity, "Quantity").IsGreaterThanOrEqual(0);

            if (shoppingCartItem.LastSeenLocation != null)
            {
                Validator.For(shoppingCartItem.LastSeenLocation.Latitude, "Latitude").InRange(-90, 90);
                Validator.For(shoppingCartItem.LastSeenLocation.Longitude, "Longitude").InRange(-180, 180);
            }

            string path = string.Format("/pii/shoppingcartitem?shoppingCartUniqueKey={0}", shoppingCartUniqueKey);

            using (var response = await Client.PostAsJsonAsync(path, shoppingCartItem).ConfigureAwait(false))
            {
                return await response.Content.ReadAsAsync<ApiResponse<ShoppingCartItem>>().ConfigureAwait(false);
            }
        }
    }
}