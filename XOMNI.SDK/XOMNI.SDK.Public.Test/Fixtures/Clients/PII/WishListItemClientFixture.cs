using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using XOMNI.SDK.Public.Clients.PII;
using XOMNI.SDK.Public.Models;
using XOMNI.SDK.Public.Models.PII;
using XOMNI.SDK.Public.Test.Helpers;

namespace XOMNI.SDK.Public.Test.Fixtures.Clients.PII
{
    [TestClass]
    public class WishlistItemClientFixture : BaseClientFixture<WishlistItemClient>
    {
        #region Arrange
        const string validAPIRequest = @"{
           'ItemId':2,
           'BluetoothId':'BluetoothId',
           'LastSeenLocation':{
              'Longitude':-122.335197,
              'Latitude':47.646711
           },
        }";

        const string validAPIResponse = @"{
            'Data': {
                'ItemId': 2,
                'BluetoothId': 'BluetoothId',
                'LastSeenLocation': {
                    'Longitude': -122.335197,
                    'Latitude': 47.646711
                },
                'DateAdded': '2013-03-12T14:13:07.7543788+02:00',
                'UniqueKey': '942653b2-88e9-43fc-a336-c720d0c1ee76'
            }
        }";

        readonly WishlistItem sampleWishlistItem = new WishlistItem()
        {
            ItemId = 2,
            BluetoothId = "BluetoothId",
            LastSeenLocation = new Location()
            {
                Longitude = -122.335197,
                Latitude = 47.646711
            }
        };

        readonly Location validLocation = new Location()
        {
            Latitude = 21.22,
            Longitude = 28.43
        };

        readonly Location invalidLatitudeLocation = new Location()
        {
            Latitude = -95,
            Longitude = 23
        };

        readonly Location invalidLongitudeLocation = new Location()
        {
            Latitude = 23,
            Longitude = -185
        };

        #endregion

        #region DeleteWishlistItemAsync

        [TestMethod, TestCategory("WishlistItemClient"), TestCategory("DeleteWishlistItemAsync"), TestCategory("HTTP.DELETE")]
        public async Task DeleteWishlistItemAsyncHttpMethodTest()
        {
            await base.HttpMethodTestAsync(
                (WishlistItemClient c) => c.DeleteWishlistItemAsync(Guid.NewGuid()),
                HttpMethod.Delete);
        }

        [TestMethod, TestCategory("WishlistItemClient"), TestCategory("DeleteWishlistItemAsync"), TestCategory("HTTP.DELETE")]
        public async Task DeleteWishlistItemAsyncUriCheckTest()
        {
            await base.UriTestAsync(
              (WishlistItemClient c) => c.DeleteWishlistItemAsync(Guid.Parse(uniqeId)),
              string.Format("/pii/wishlistitem?wishlistItemUniqueKey={0}", uniqeId));

            await base.UriTestAsync(
              (WishlistItemClient c) => c.DeleteWishlistItemAsync(Guid.Parse(uniqeId), validLocation),
              string.Format("/pii/wishlistitem?wishlistItemUniqueKey={0}&longitude={1}&latitude={2}", uniqeId, validLocation.Longitude, validLocation.Latitude));
        }

        [TestMethod, TestCategory("WishlistItemClient"), TestCategory("DeleteWishlistItemAsync"), TestCategory("HTTP.DELETE")]
        public async Task DeleteWishlistItemAsyncParameterTest()
        {
            await base.SDKExceptionResponseTestAsync(
              (WishlistItemClient c) => c.DeleteWishlistItemAsync(Guid.NewGuid(), invalidLatitudeLocation),
              new ArgumentOutOfRangeException("Latitude", -95, string.Format("{0} must be in range ({1} - {2}).", "Latitude", -90, 90))
              );

            await base.SDKExceptionResponseTestAsync(
                 (WishlistItemClient c) => c.DeleteWishlistItemAsync(Guid.NewGuid(), invalidLongitudeLocation),
                 new ArgumentOutOfRangeException("Longitude", -185, string.Format("{0} must be in range ({1} - {2}).", "Longitude", -180, 180)));
        }

        [TestMethod, TestCategory("WishlistItemClient"), TestCategory("DeleteWishlistItemAsync"), TestCategory("HTTP.DELETE")]
        public async Task DeleteWishlistItemAsyncDefaultRequestHeadersTest()
        {
            await base.DefaultRequestHeadersTestAsync(
                (WishlistItemClient c) => c.DeleteWishlistItemAsync(Guid.NewGuid())
                );
        }

        [TestMethod, TestCategory("WishlistItemClient"), TestCategory("DeleteWishlistItemAsync"), TestCategory("HTTP.DELETE")]
        public async Task DeleteWishlistItemAsyncNotFoundTest()
        {
            var expectedExceptionResult = JsonConvert.DeserializeObject<ExceptionResult>(genericErrorResponse);
            expectedExceptionResult.HttpStatusCode = HttpStatusCode.NotFound;

            await base.APIExceptionResponseTestAsync(
              (WishlistItemClient c) => c.DeleteWishlistItemAsync(Guid.NewGuid()),
              notFoundHttpResponseMessage,
              expectedExceptionResult);
        }

        [TestMethod, TestCategory("WishlistItemClient"), TestCategory("DeleteWishlistItemAsync"), TestCategory("HTTP.DELETE")]
        public async Task DeleteWishlistItemAsyncForbiddenTest()
        {
            var expectedExceptionResult = JsonConvert.DeserializeObject<ExceptionResult>(genericErrorResponse);
            expectedExceptionResult.HttpStatusCode = HttpStatusCode.Forbidden;

            await base.APIExceptionResponseTestAsync(
              (WishlistItemClient c) => c.DeleteWishlistItemAsync(Guid.NewGuid()),
              forbiddenHttpResponseMessage,
              expectedExceptionResult
              );
        }
        #endregion

        #region DeleteWishlistItemsAsync

        [TestMethod, TestCategory("WishlistItemClient"), TestCategory("DeleteWishlistItemsAsync"), TestCategory("HTTP.DELETE")]
        public async Task DeleteWishlistItemsAsyncHttpMethodTest()
        {
            await base.HttpMethodTestAsync(
                (WishlistItemClient c) => c.DeleteWishlistItemsAsync(Guid.NewGuid()),
                HttpMethod.Delete
                );
        }

        [TestMethod, TestCategory("WishlistItemClient"), TestCategory("DeleteWishlistItemsAsync"), TestCategory("HTTP.DELETE")]
        public async Task DeleteWishlistItemsAsyncUriCheckTest()
        {
            await base.UriTestAsync(
              (WishlistItemClient c) => c.DeleteWishlistItemsAsync(Guid.Parse(uniqeId)),
              string.Format("/pii/wishlistitems?wishlistUniqueKey={0}", uniqeId));

            await base.UriTestAsync(
              (WishlistItemClient c) => c.DeleteWishlistItemsAsync(Guid.Parse(uniqeId), validLocation),
              string.Format("/pii/wishlistitems?wishlistUniqueKey={0}&longitude={1}&latitude={2}", uniqeId, validLocation.Longitude.ToString(), validLocation.Latitude.ToString()));
        }

        [TestMethod, TestCategory("WishlistItemClient"), TestCategory("DeleteWishlistItemsAsync"), TestCategory("HTTP.DELETE")]
        public async Task DeleteWishlistItemsAsyncParameterTest()
        {
            await base.SDKExceptionResponseTestAsync(
              (WishlistItemClient c) => c.DeleteWishlistItemsAsync(Guid.NewGuid(), invalidLatitudeLocation),
              new ArgumentOutOfRangeException("Latitude", -95, string.Format("{0} must be in range ({1} - {2}).", "Latitude", -90, 90)));

            await base.SDKExceptionResponseTestAsync(
                 (WishlistItemClient c) => c.DeleteWishlistItemsAsync(Guid.NewGuid(), invalidLongitudeLocation),
                 new ArgumentOutOfRangeException("Longitude", -185, string.Format("{0} must be in range ({1} - {2}).", "Longitude", -180, 180)));
        }

        [TestMethod, TestCategory("WishlistItemClient"), TestCategory("DeleteWishlistItemsAsync"), TestCategory("HTTP.DELETE")]
        public async Task DeleteWishlistItemsAsyncDefaultRequestHeadersTest()
        {
            await base.DefaultRequestHeadersTestAsync(
                (WishlistItemClient c) => c.DeleteWishlistItemsAsync(Guid.NewGuid()));
        }

        [TestMethod, TestCategory("WishlistItemClient"), TestCategory("DeleteWishlistItemsAsync"), TestCategory("HTTP.DELETE")]
        public async Task DeleteWishlistItemsAsyncNotFoundTest()
        {
            var expectedExceptionResult = JsonConvert.DeserializeObject<ExceptionResult>(genericErrorResponse);
            expectedExceptionResult.HttpStatusCode = HttpStatusCode.NotFound;

            await base.APIExceptionResponseTestAsync(
              (WishlistItemClient c) => c.DeleteWishlistItemsAsync(Guid.NewGuid()),
              notFoundHttpResponseMessage,
              expectedExceptionResult);
        }

        [TestMethod, TestCategory("WishlistItemClient"), TestCategory("DeleteWishlistItemsAsync"), TestCategory("HTTP.DELETE")]
        public async Task DeleteWishlistItemsAsyncForbiddenTest()
        {
            var expectedExceptionResult = JsonConvert.DeserializeObject<ExceptionResult>(genericErrorResponse);
            expectedExceptionResult.HttpStatusCode = HttpStatusCode.Forbidden;

            await base.APIExceptionResponseTestAsync(
              (WishlistItemClient c) => c.DeleteWishlistItemsAsync(Guid.NewGuid()),
              forbiddenHttpResponseMessage,
              expectedExceptionResult);
        }
        #endregion

        #region PostAsync

        [TestMethod, TestCategory("WishlistItemClient"), TestCategory("PostAsync"), TestCategory("HTTP.POST")]
        public async Task PostAsyncRequestParseTest()
        {
            await base.RequestParseTestAsync<WishlistItem>(
                (WishlistItemClient c) => c.PostAsync(Guid.NewGuid(), sampleWishlistItem),
                validAPIRequest,
                piiUser: piiUser
                );
        }

        [TestMethod, TestCategory("WishlistItemClient"), TestCategory("PostAsync"), TestCategory("HTTP.POST")]
        public async Task PostAsyncResponseParseTest()
        {
            await base.ResponseParseTestAsync(
                (WishlistItemClient c) => c.PostAsync(Guid.NewGuid(), sampleWishlistItem),
                new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new MockedJsonContent(validAPIResponse)
                },
                validAPIResponse,
                piiUser: piiUser
                );
        }

        [TestMethod, TestCategory("WishlistItemClient"), TestCategory("PostAsync"), TestCategory("HTTP.POST")]
        public async Task PostAsyncHttpMethodTest()
        {
            await base.HttpMethodTestAsync(
                (WishlistItemClient c) => c.PostAsync(Guid.NewGuid(), sampleWishlistItem),
                HttpMethod.Post,
                piiUser: piiUser
                );
        }

        [TestMethod, TestCategory("WishlistItemClient"), TestCategory("PostAsync"), TestCategory("HTTP.POST")]
        public async Task PostAsyncUriCheckTest()
        {
            await base.UriTestAsync(
             (WishlistItemClient c) => c.PostAsync(Guid.Parse(uniqeId), sampleWishlistItem),
             string.Format("/pii/wishlistitem?wishlistUniqueKey={0}", uniqeId),
             piiUser: piiUser
             );
        }

        [TestMethod, TestCategory("WishlistItemClient"), TestCategory("PostAsync"), TestCategory("HTTP.POST")]
        public async Task PostAsyncParameterTest()
        {
            await base.SDKExceptionResponseTestAsync(
              (WishlistItemClient c) => c.PostAsync(Guid.NewGuid(), new WishlistItem()
                  {
                      ItemId = -1
                  }),
              new ArgumentException(string.Format("{0} must be greater than or equal to 1.", "ItemId")),
              piiUser: piiUser
              );

            await base.SDKExceptionResponseTestAsync(
               (WishlistItemClient c) => c.PostAsync(Guid.NewGuid(), null),
               new ArgumentNullException(string.Format("{0} can not be null.", "wishlistItem")),
               piiUser: piiUser
               );

            await base.SDKExceptionResponseTestAsync(
                (WishlistItemClient c) => c.PostAsync(Guid.NewGuid(), new WishlistItem()
                {
                    ItemId = 3,
                    LastSeenLocation = invalidLatitudeLocation
                }),
                new ArgumentOutOfRangeException("Latitude", -95, string.Format("{0} must be in range ({1} - {2}).", "Latitude", -90, 90)),
                piiUser: piiUser
                );

            await base.SDKExceptionResponseTestAsync(
                (WishlistItemClient c) => c.PostAsync(Guid.NewGuid(), new WishlistItem()
                {
                    ItemId = 3,
                    LastSeenLocation = invalidLongitudeLocation
                }),
                new ArgumentOutOfRangeException("Longitude", -185, string.Format("{0} must be in range ({1} - {2}).", "Longitude", -180, 180)),
                piiUser: piiUser
                );

        }

        [TestMethod, TestCategory("WishlistItemClient"), TestCategory("PostAsync"), TestCategory("HTTP.POST")]
        public async Task PostAsyncForbiddenTest()
        {
            var expectedExceptionResult = JsonConvert.DeserializeObject<ExceptionResult>(genericErrorResponse);
            expectedExceptionResult.HttpStatusCode = HttpStatusCode.Forbidden;

            await base.APIExceptionResponseTestAsync(
              (WishlistItemClient c) => c.PostAsync(Guid.NewGuid(), sampleWishlistItem),
              forbiddenHttpResponseMessage,
              expectedExceptionResult,
              piiUser: piiUser
              );
        }
        #endregion
    }
}
