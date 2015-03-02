using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using XOMNI.SDK.Public.Clients;
using XOMNI.SDK.Public.Models;
using XOMNI.SDK.Public.Models.Catalog;
using XOMNI.SDK.Public.Models.PII;
using XOMNI.SDK.Public.Extensions;

namespace XOMNI.SDK.Public.Clients.PII
{
	public class WishlistClient : BaseClient
	{
		public WishlistClient(HttpClient httpClient)
			: base(httpClient)
		{

		}

        public async Task DeleteAsync()
        {
            ValidatePIIToken();

            string path = "/pii/wishlists";
            await Client.DeleteAsync(path).ConfigureAwait(false);
        }

        public async Task DeleteAsync(Guid wishlistUniqueKey)
		{
            ValidatePIIToken();

			string path = string.Format("/pii/wishlist?wishlistUniqueKey={0}", wishlistUniqueKey);
            await Client.DeleteAsync(path).ConfigureAwait(false);
		}

        public async Task<ApiResponse<WishlistWithItems>> GetAsync(Guid wishlistUniqueKey, Location location = null, bool includeItemStaticProperties = true, bool includeItemDynamicProperties = false, bool includeCategoryMetadata = false, AssetDetailType imageAssetDetail = AssetDetailType.None, AssetDetailType videoAssetDetail = AssetDetailType.None, AssetDetailType documentAssetDetail = AssetDetailType.None, string metadataKey = null, string metadataValue = null)
        {
            ValidatePIIToken();
            string path = string.Format("/pii/wishlist?wishlistUniqueKey={0}&", wishlistUniqueKey);

            if (location != null)
            {
                Validator.For(location.Longitude, "Longitude").InRange(-180, 180);
                Validator.For(location.Latitude, "Latitude").InRange(-90, 90);
                path += string.Format("longitude={0}&latitude={1}&", location.Longitude, location.Latitude);
            }
            path += string.Format("includeItemStaticProperties={0}&includeItemDynamicProperties={1}&includeCategoryMetadata={2}&imageAssetDetail={3}&videoAssetDetail={4}&documentAssetDetail={5}", includeItemStaticProperties, includeItemDynamicProperties, includeCategoryMetadata, (int)imageAssetDetail, (int)videoAssetDetail, (int)documentAssetDetail);

            if (!string.IsNullOrEmpty(metadataKey) && !string.IsNullOrEmpty(metadataValue))
            {
                path += string.Format("&metadataKey={0}&metadataValue={1}", metadataKey, metadataValue);
            }
            else if (!string.IsNullOrEmpty(metadataKey) || !string.IsNullOrEmpty(metadataValue))
            {
                Validator.For(metadataKey, "metadataKey").IsNotNullOrEmpty();
                Validator.For(metadataValue, "metadataValue").IsNotNullOrEmpty();
            }

            using (var response = await Client.GetAsync(path).ConfigureAwait(false))
            {
                return await response.Content.ReadAsAsync<ApiResponse<WishlistWithItems>>().ConfigureAwait(false);
            }
        }

        public async Task PostAccessAsync(Guid wishlistUniqueKey, bool isPublic)
        {
            ValidatePIIToken();
            string path = string.Format("/pii/wishlistaccess?wishlistUniqueKey={0}&isPublic={1}", wishlistUniqueKey, isPublic);
            await Client.PostAsJsonAsync(path, string.Empty).ConfigureAwait(false);
        }

        public async Task<ApiResponse<List<Guid>>> GetAsync()
		{
            ValidatePIIToken();
			string path = "/pii/wishlists";

			using (var response = await Client.GetAsync(path).ConfigureAwait(false))
			{
                return await response.Content.ReadAsAsync<ApiResponse<List<Guid>>>().ConfigureAwait(false);
			}
		}

        public async Task<ApiResponse<Wishlist>> PostWishlistAsync(Wishlist wishlist)
		{
            ValidatePIIToken();
            Validator.For(wishlist, "wishlist").IsNotNull();

            if (wishlist.LastSeenLocation != null)
            {
                Validator.For(wishlist.LastSeenLocation.Latitude, "Latitude").InRange(-90, 90);
                Validator.For(wishlist.LastSeenLocation.Longitude, "Longitude").InRange(-180, 180);
            }

			string path = "/pii/wishlist";

            using (var response = await Client.PostAsJsonAsync(path, wishlist).ConfigureAwait(false))
			{
                return await response.Content.ReadAsAsync<ApiResponse<Wishlist>>().ConfigureAwait(false);
			}
		}

        public async Task<ApiResponse<Wishlist>> PutAsync(Wishlist wishlist)
		{
            ValidatePIIToken();
            Validator.For(wishlist, "wishlist").IsNotNull();

            if (wishlist.LastSeenLocation != null)
            {
                Validator.For(wishlist.LastSeenLocation.Latitude, "Latitude").InRange(-90, 90);
                Validator.For(wishlist.LastSeenLocation.Longitude, "Longitude").InRange(-180, 180);
            }

			string path = "/pii/wishlist";

			using (var response = await Client.PutAsJsonAsync(path, wishlist).ConfigureAwait(false))
			{
                return await response.Content.ReadAsAsync<ApiResponse<Wishlist>>().ConfigureAwait(false);
			}
		}

        public async Task PostMailAsync(MailSendRequest mailSendRequest)
		{
            ValidatePIIToken();
            Validator.For(mailSendRequest, "mailSendRequest").IsNotNull();

			string path = "/pii/wishlist/mail";
            await Client.PostAsJsonAsync(path, mailSendRequest).ConfigureAwait(false);
		}
	}
}