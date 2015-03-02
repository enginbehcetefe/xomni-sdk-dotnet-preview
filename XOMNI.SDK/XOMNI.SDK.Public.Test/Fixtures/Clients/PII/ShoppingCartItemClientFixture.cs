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
    public class ShoppingCartItemClientFixture : BaseClientFixture<ShoppingCartItemClient>
    {
        #region Arrange
        const string validAPIResponseForPutAsync = @"{
            'Data': {
                'ItemId': 2,
                'Quantity': 2,
                'BluetoothId': 'BluetoothId',
                'LastSeenLocation': {
                    'Longitude': -122.335197,
                    'Latitude': 47.646711
                },
                'DateAdded': '2013-03-12T14:13:07.7543788+02:00',
                'UniqueKey': '942653b2-88e9-43fc-a336-c720d0c1ee76'
            }
        }";

        const string validAPIResponseForPostAsync = @"{
           'ItemId':2,
           'Quantity':2,
           'BluetoothId':'BluetoothId',
           'LastSeenLocation':{
              'Longitude':-122.335197,
              'Latitude':47.646711
           },
        }";

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

        readonly ShoppingCartItem sampleShoppingCartItem = new ShoppingCartItem()
        {
            ItemId = 2,
            Quantity = 2,
            BluetoothId = "BluetoothId",
            LastSeenLocation = new Location()
            {
                Longitude = -122.335197,
                Latitude = 47.646711
            }
        };

        #endregion

        #region PutAsync

        [TestMethod, TestCategory("ShoppingCartItemClient"), TestCategory("PutAsync"), TestCategory("HTTP.PUT")]
        public async Task PutAsyncResponseParseTest()
        {
            await base.ResponseParseTestAsync(
                (ShoppingCartItemClient c) => c.PutAsync(Guid.NewGuid(), 1, validLocation),
                new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new MockedJsonContent(validAPIResponseForPutAsync)
                },
                validAPIResponseForPutAsync,
                piiUser: piiUser
                );
        }

        [TestMethod, TestCategory("ShoppingCartItemClient"), TestCategory("PutAsync"), TestCategory("HTTP.PUT")]
        public async Task PutAsyncHttpMethodTest()
        {
            await base.HttpMethodTestAsync(
                (ShoppingCartItemClient c) => c.PutAsync(Guid.NewGuid(), 1, validLocation),
                HttpMethod.Put,
                piiUser: piiUser
                );
        }

        [TestMethod, TestCategory("ShoppingCartItemClient"), TestCategory("PutAsync"), TestCategory("HTTP.PUT")]
        public async Task PutAsyncUriCheckTest()
        {
            await base.UriTestAsync(
             (ShoppingCartItemClient c) => c.PutAsync(Guid.Parse(uniqeId), 1),
             string.Format("/pii/shoppingcartitem?shoppingCartItemUniqueKey={0}&quantity={1}", uniqeId, 1),
             piiUser: piiUser
             );

            await base.UriTestAsync(
              (ShoppingCartItemClient c) => c.PutAsync(Guid.Parse(uniqeId), 1, validLocation),
              string.Format("/pii/shoppingcartitem?shoppingCartItemUniqueKey={0}&quantity={1}&longitude={2}&latitude={3}", uniqeId, 1, validLocation.Longitude, validLocation.Latitude),
              piiUser: piiUser
              );
        }

        [TestMethod, TestCategory("ShoppingCartItemClient"), TestCategory("PutAsync"), TestCategory("HTTP.PUT")]
        public async Task PutAsyncParameterTest()
        {
            await base.SDKExceptionResponseTestAsync(
              (ShoppingCartItemClient c) => c.PutAsync(Guid.NewGuid(), -1, validLocation),
              new ArgumentException(string.Format("{0} must be greater than or equal to {1}.", "quantity", 0)));

            await base.SDKExceptionResponseTestAsync(
              (ShoppingCartItemClient c) => c.PutAsync(Guid.NewGuid(), 2, invalidLatitudeLocation),
              new ArgumentOutOfRangeException("Latitude", -95, string.Format("{0} must be in range ({1} - {2}).", "Latitude", -90, 90)),
              piiUser: piiUser
              );

            await base.SDKExceptionResponseTestAsync(
              (ShoppingCartItemClient c) => c.PutAsync(Guid.NewGuid(), 2, invalidLongitudeLocation),
              new ArgumentOutOfRangeException("Longitude", -185, string.Format("{0} must be in range ({1} - {2}).", "Longitude", -180, 180)),
              piiUser: piiUser
              );
        }

        [TestMethod, TestCategory("ShoppingCartItemClient"), TestCategory("PutAsync"), TestCategory("HTTP.PUT")]
        public async Task PutAsyncNotFoundTest()
        {
            var expectedExceptionResult = JsonConvert.DeserializeObject<ExceptionResult>(genericErrorResponse);
            expectedExceptionResult.HttpStatusCode = HttpStatusCode.NotFound;

            await base.APIExceptionResponseTestAsync(
              (ShoppingCartItemClient c) => c.PutAsync(Guid.NewGuid(), 1, validLocation),
              notFoundHttpResponseMessage,
              expectedExceptionResult,
              piiUser: piiUser
              );
        }

        [TestMethod, TestCategory("ShoppingCartItemClient"), TestCategory("PutAsync"), TestCategory("HTTP.PUT")]
        public async Task PutAsyncForbiddenTest()
        {
            var expectedExceptionResult = JsonConvert.DeserializeObject<ExceptionResult>(genericErrorResponse);
            expectedExceptionResult.HttpStatusCode = HttpStatusCode.Forbidden;

            await base.APIExceptionResponseTestAsync(
              (ShoppingCartItemClient c) => c.PutAsync(Guid.NewGuid(), 1, validLocation),
              forbiddenHttpResponseMessage,
              expectedExceptionResult,
              piiUser: piiUser
              );
        }
        #endregion

        #region DeleteShoppingCartItemAsync

        [TestMethod, TestCategory("ShoppingCartItemClient"), TestCategory("DeleteShoppingCartItemAsync"), TestCategory("HTTP.DELETE")]
        public async Task DeleteShoppingCartItemAsyncHttpMethodTest()
        {
            await base.HttpMethodTestAsync(
                (ShoppingCartItemClient c) => c.DeleteShoppingCartItemAsync(Guid.NewGuid()),
                HttpMethod.Delete, piiUser: piiUser
                );
        }

        [TestMethod, TestCategory("ShoppingCartItemClient"), TestCategory("DeleteShoppingCartItemAsync"), TestCategory("HTTP.DELETE")]
        public async Task DeleteShoppingCartItemAsyncUriCheckTest()
        {
            await base.UriTestAsync(
              (ShoppingCartItemClient c) => c.DeleteShoppingCartItemAsync(Guid.Parse(uniqeId)),
              string.Format("/pii/shoppingcartitem?shoppingCartItemUniqueKey={0}", uniqeId), piiUser: piiUser);

            await base.UriTestAsync(
              (ShoppingCartItemClient c) => c.DeleteShoppingCartItemAsync(Guid.Parse(uniqeId), validLocation),
              string.Format("/pii/shoppingcartitem?shoppingCartItemUniqueKey={0}&longitude={1}&latitude={2}", uniqeId, validLocation.Longitude, validLocation.Latitude), piiUser: piiUser
              );
        }

        [TestMethod, TestCategory("ShoppingCartItemClient"), TestCategory("DeleteShoppingCartItemAsync"), TestCategory("HTTP.DELETE")]
        public async Task DeleteShoppingCartItemAsyncParameterTest()
        {
            await base.SDKExceptionResponseTestAsync(
              (ShoppingCartItemClient c) => c.DeleteShoppingCartItemAsync(Guid.NewGuid(), invalidLatitudeLocation),
              new ArgumentOutOfRangeException("Latitude", -95, string.Format("{0} must be in range ({1} - {2}).", "Latitude", -90, 90))
              , piiUser: piiUser);

            await base.SDKExceptionResponseTestAsync(
                 (ShoppingCartItemClient c) => c.DeleteShoppingCartItemAsync(Guid.NewGuid(), invalidLongitudeLocation),
                 new ArgumentOutOfRangeException("Longitude", -185, string.Format("{0} must be in range ({1} - {2}).", "Longitude", -180, 180)), piiUser: piiUser
            );
        }

        [TestMethod, TestCategory("ShoppingCartItemClient"), TestCategory("DeleteShoppingCartItemAsync"), TestCategory("HTTP.DELETE")]
        public async Task DeleteShoppingCartItemAsyncDefaultRequestHeadersTest()
        {
            await base.DefaultRequestHeadersTestAsync(
                (ShoppingCartItemClient c) => c.DeleteShoppingCartItemAsync(Guid.NewGuid()), piiUser: piiUser
                );
        }

        [TestMethod, TestCategory("ShoppingCartItemClient"), TestCategory("DeleteShoppingCartItemAsync"), TestCategory("HTTP.DELETE")]
        public async Task DeleteShoppingCartItemAsyncNotFoundTest()
        {
            var expectedExceptionResult = JsonConvert.DeserializeObject<ExceptionResult>(genericErrorResponse);
            expectedExceptionResult.HttpStatusCode = HttpStatusCode.NotFound;

            await base.APIExceptionResponseTestAsync(
              (ShoppingCartItemClient c) => c.DeleteShoppingCartItemAsync(Guid.NewGuid()),
              notFoundHttpResponseMessage,
              expectedExceptionResult, piiUser: piiUser);
        }

        [TestMethod, TestCategory("ShoppingCartItemClient"), TestCategory("DeleteShoppingCartItemAsync"), TestCategory("HTTP.DELETE")]
        public async Task DeleteShoppingCartItemAsyncForbiddenTest()
        {
            var expectedExceptionResult = JsonConvert.DeserializeObject<ExceptionResult>(genericErrorResponse);
            expectedExceptionResult.HttpStatusCode = HttpStatusCode.Forbidden;

            await base.APIExceptionResponseTestAsync(
              (ShoppingCartItemClient c) => c.DeleteShoppingCartItemAsync(Guid.NewGuid()),
              forbiddenHttpResponseMessage,
              expectedExceptionResult, piiUser: piiUser
              );
        }
        #endregion

        #region DeleteShoppingCartItemsAsync

        [TestMethod, TestCategory("ShoppingCartItemClient"), TestCategory("DeleteShoppingCartItemsAsync"), TestCategory("HTTP.DELETE")]
        public async Task DeleteShoppingCartItemsAsyncHttpMethodTest()
        {
            await base.HttpMethodTestAsync(
                (ShoppingCartItemClient c) => c.DeleteShoppingCartItemsAsync(Guid.NewGuid()),
                HttpMethod.Delete, piiUser: piiUser
                );
        }

        [TestMethod, TestCategory("ShoppingCartItemClient"), TestCategory("DeleteShoppingCartItemsAsync"), TestCategory("HTTP.DELETE")]
        public async Task DeleteShoppingCartItemsAsyncUriCheckTest()
        {
            await base.UriTestAsync(
              (ShoppingCartItemClient c) => c.DeleteShoppingCartItemsAsync(Guid.Parse(uniqeId)),
              string.Format("/pii/shoppingcartitems?shoppingCartUniqueKey={0}", uniqeId), piiUser: piiUser);

            await base.UriTestAsync(
              (ShoppingCartItemClient c) => c.DeleteShoppingCartItemsAsync(Guid.Parse(uniqeId), validLocation),
              string.Format("/pii/shoppingcartitems?shoppingCartUniqueKey={0}&longitude={1}&latitude={2}", uniqeId, validLocation.Longitude.ToString(), validLocation.Latitude.ToString()), piiUser: piiUser
              );
        }

        [TestMethod, TestCategory("ShoppingCartItemClient"), TestCategory("DeleteShoppingCartItemsAsync"), TestCategory("HTTP.DELETE")]
        public async Task DeleteShoppingCartItemsAsyncParameterTest()
        {
            await base.SDKExceptionResponseTestAsync(
              (ShoppingCartItemClient c) => c.DeleteShoppingCartItemsAsync(Guid.NewGuid(), invalidLatitudeLocation),
              new ArgumentOutOfRangeException("Latitude", -95, string.Format("{0} must be in range ({1} - {2}).", "Latitude", -90, 90))
              , piiUser: piiUser);

            await base.SDKExceptionResponseTestAsync(
                 (ShoppingCartItemClient c) => c.DeleteShoppingCartItemsAsync(Guid.NewGuid(), invalidLongitudeLocation),
                 new ArgumentOutOfRangeException("Longitude", -185, string.Format("{0} must be in range ({1} - {2}).", "Longitude", -180, 180))
            , piiUser: piiUser);
        }

        [TestMethod, TestCategory("ShoppingCartItemClient"), TestCategory("DeleteShoppingCartItemsAsync"), TestCategory("HTTP.DELETE")]
        public async Task DeleteShoppingCartItemsAsyncDefaultRequestHeadersTest()
        {
            await base.DefaultRequestHeadersTestAsync(
                (ShoppingCartItemClient c) => c.DeleteShoppingCartItemsAsync(Guid.NewGuid())
                , piiUser: piiUser);
        }

        [TestMethod, TestCategory("ShoppingCartItemClient"), TestCategory("DeleteShoppingCartItemsAsync"), TestCategory("HTTP.DELETE")]
        public async Task DeleteShoppingCartItemsAsyncNotFoundTest()
        {
            var expectedExceptionResult = JsonConvert.DeserializeObject<ExceptionResult>(genericErrorResponse);
            expectedExceptionResult.HttpStatusCode = HttpStatusCode.NotFound;

            await base.APIExceptionResponseTestAsync(
              (ShoppingCartItemClient c) => c.DeleteShoppingCartItemsAsync(Guid.NewGuid()),
              notFoundHttpResponseMessage,
              expectedExceptionResult, piiUser: piiUser);
        }

        [TestMethod, TestCategory("ShoppingCartItemClient"), TestCategory("DeleteShoppingCartItemsAsync"), TestCategory("HTTP.DELETE")]
        public async Task DeleteShoppingCartItemsAsyncForbiddenTest()
        {
            var expectedExceptionResult = JsonConvert.DeserializeObject<ExceptionResult>(genericErrorResponse);
            expectedExceptionResult.HttpStatusCode = HttpStatusCode.Forbidden;

            await base.APIExceptionResponseTestAsync(
              (ShoppingCartItemClient c) => c.DeleteShoppingCartItemsAsync(Guid.NewGuid()),
              forbiddenHttpResponseMessage,
              expectedExceptionResult, piiUser: piiUser);
        }
        #endregion

        #region PostAsync

        [TestMethod, TestCategory("ShoppingCartItemClient"), TestCategory("PostAsync"), TestCategory("HTTP.POST")]
        public async Task PostAsyncRequestParseTest()
        {
            await base.RequestParseTestAsync<ShoppingCartItem>(
                (ShoppingCartItemClient c) => c.PostAsync(Guid.NewGuid(), sampleShoppingCartItem),
                validAPIResponseForPostAsync,
                piiUser: piiUser
                );
        }

        [TestMethod, TestCategory("ShoppingCartItemClient"), TestCategory("PostAsync"), TestCategory("HTTP.POST")]
        public async Task PostAsyncResponseParseTest()
        {
            await base.ResponseParseTestAsync(
                (ShoppingCartItemClient c) => c.PostAsync(Guid.NewGuid(), sampleShoppingCartItem),
                new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new MockedJsonContent(validAPIResponseForPostAsync)
                },
                validAPIResponseForPostAsync,
                piiUser: piiUser
                );
        }

        [TestMethod, TestCategory("ShoppingCartItemClient"), TestCategory("PostAsync"), TestCategory("HTTP.POST")]
        public async Task PostAsyncHttpMethodTest()
        {
            await base.HttpMethodTestAsync(
                (ShoppingCartItemClient c) => c.PostAsync(Guid.NewGuid(), sampleShoppingCartItem),
                HttpMethod.Post,
                piiUser: piiUser
                );
        }

        [TestMethod, TestCategory("ShoppingCartItemClient"), TestCategory("PostAsync"), TestCategory("HTTP.POST")]
        public async Task PostAsyncUriCheckTest()
        {
            await base.UriTestAsync(
             (ShoppingCartItemClient c) => c.PostAsync(Guid.Parse(uniqeId), sampleShoppingCartItem),
             string.Format("/pii/shoppingcartitem?shoppingCartUniqueKey={0}", uniqeId),
             piiUser: piiUser
             );
        }

        [TestMethod, TestCategory("ShoppingCartItemClient"), TestCategory("PostAsync"), TestCategory("HTTP.POST")]
        public async Task PostAsyncParameterTest()
        {
            await base.SDKExceptionResponseTestAsync(
              (ShoppingCartItemClient c) => c.PostAsync(Guid.NewGuid(), new ShoppingCartItem()
                  {
                      ItemId = -1
                  }),
              new ArgumentException(string.Format("{0} must be greater than or equal to 1.", "ItemId")),
              piiUser: piiUser
              );

            await base.SDKExceptionResponseTestAsync(
               (ShoppingCartItemClient c) => c.PostAsync(Guid.NewGuid(), null),
               new ArgumentNullException(string.Format("{0} can not be null.", "shoppingCartItem")),
               piiUser: piiUser
               );

            await base.SDKExceptionResponseTestAsync(
              (ShoppingCartItemClient c) => c.PostAsync(Guid.NewGuid(), new ShoppingCartItem()
                  {
                      ItemId = 5,
                      Quantity = -1
                  }),
              new ArgumentException(string.Format("{0} must be greater than or equal to {1}.", "Quantity", 0)),
              piiUser);

            await base.SDKExceptionResponseTestAsync(
              (ShoppingCartItemClient c) => c.PostAsync(Guid.NewGuid(), new ShoppingCartItem() 
              {
                  ItemId = 5,
                  Quantity = 5,
                  LastSeenLocation = invalidLatitudeLocation
              }),
              new ArgumentOutOfRangeException("Latitude", -95, string.Format("{0} must be in range ({1} - {2}).", "Latitude", -90, 90)),
              piiUser: piiUser
              );

            await base.SDKExceptionResponseTestAsync(
              (ShoppingCartItemClient c) => c.PostAsync(Guid.NewGuid(), new ShoppingCartItem()
              {
                  ItemId = 5,
                  Quantity = 5,
                  LastSeenLocation = invalidLongitudeLocation
              }),
              new ArgumentOutOfRangeException("Longitude", -185, string.Format("{0} must be in range ({1} - {2}).", "Longitude", -180, 180)),
              piiUser: piiUser
              );
        }

        [TestMethod, TestCategory("ShoppingCartItemClient"), TestCategory("PostAsync"), TestCategory("HTTP.POST")]
        public async Task PostAsyncNotFoundTest()
        {
            var expectedExceptionResult = JsonConvert.DeserializeObject<ExceptionResult>(genericErrorResponse);
            expectedExceptionResult.HttpStatusCode = HttpStatusCode.NotFound;

            await base.APIExceptionResponseTestAsync(
              (ShoppingCartItemClient c) => c.PostAsync(Guid.NewGuid(), sampleShoppingCartItem),
              notFoundHttpResponseMessage,
              expectedExceptionResult,
              piiUser: piiUser
              );
        }

        [TestMethod, TestCategory("ShoppingCartItemClient"), TestCategory("PostAsync"), TestCategory("HTTP.POST")]
        public async Task PostAsyncForbiddenTest()
        {
            var expectedExceptionResult = JsonConvert.DeserializeObject<ExceptionResult>(genericErrorResponse);
            expectedExceptionResult.HttpStatusCode = HttpStatusCode.Forbidden;

            await base.APIExceptionResponseTestAsync(
              (ShoppingCartItemClient c) => c.PostAsync(Guid.NewGuid(), sampleShoppingCartItem),
              forbiddenHttpResponseMessage,
              expectedExceptionResult,
              piiUser: piiUser
              );
        }
        #endregion
    }
}
