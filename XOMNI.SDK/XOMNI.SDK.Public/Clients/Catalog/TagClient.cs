using System;
using System.Net.Http;
using System.Threading.Tasks;
using XOMNI.SDK.Public.Clients;
using XOMNI.SDK.Public.Models;
using XOMNI.SDK.Public.Models.Catalog;
using XOMNI.SDK.Public.Extensions;

namespace XOMNI.SDK.Public.Clients.Catalog
{
	public class TagClient : BaseClient
	{
		public TagClient(HttpClient httpClient)
			: base(httpClient)
		{

		}

		public async Task<PaginatedContainer<Tag>> GetAsync(int skip, int take, bool includeMetadata = false)
		{
            Validator.For(skip, "skip").IsGreaterThanOrEqual(0);
            Validator.For(take, "take").IsGreaterThanOrEqual(1);

			string path = string.Format("/catalog/tag?skip={0}&take={1}&includeMetadata={2}", skip, take, includeMetadata);

			using (var response = await Client.GetAsync(path).ConfigureAwait(false))
			{
                return await response.Content.ReadAsAsync<PaginatedContainer<Tag>>().ConfigureAwait(false);
			}
		}
	}
}