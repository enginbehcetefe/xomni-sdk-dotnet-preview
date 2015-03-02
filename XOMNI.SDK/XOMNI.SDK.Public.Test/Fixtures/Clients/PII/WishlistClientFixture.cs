using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using XOMNI.SDK.Public.Clients.OmniPlay;
using XOMNI.SDK.Public.Clients.PII;
using XOMNI.SDK.Public.Models;
using XOMNI.SDK.Public.Models.Catalog;
using XOMNI.SDK.Public.Models.PII;
using XOMNI.SDK.Public.Test.Helpers;

namespace XOMNI.SDK.Public.Test.Fixtures.Clients.PII
{
    [TestClass]
    public class WishlistClientFixture : BaseClientFixture<WishlistClient>
    {
        const string validAPIResponseForGetAsync = @"{
           'Data':{
              'Name':'Wishlist Sample Name',
              'WishlistItems':[
                 {
                    'CategoryMetadata':null,
                    'Item':{
                       'DynamicAttributes':[
                          {
                             'TypeId':1,
                             'TypeValueId':1,
                             'Value':'Red',
                             'TypeName':'Color'
                          },
                          {
                             'TypeId':3,
                             'TypeValueId':7,
                             'Value':'A',
                             'TypeName':'Style'
                          },
                          {
                             'TypeId':2,
                             'TypeValueId':9,
                             'Value':'S',
                             'TypeName':'Size'
                          }
                       ],
                       'Id':1,
                       'RFID':null,
                       'UUID':null,
                       'SKU':null,
                       'Name':'D1 Red-S-A Style',
                       'Model':'Model 1',
                       'Title':'D1 Title',
                       'ShortDescription':'Master Item 1 Short Description',
                       'LongDescription':null,
                       'Rating':null,
                       'LikeCount':80,
                       'CategoryId':66,
                       'InStock':true,
                       'PublicWebLink':null,
                       'DefaultItemId':1,
                       'BrandId':1,
                       'UnitTypeId':3,
                       'UnitTypeName':'Quantity',
                       'UnitTypeCode':'Quantity',
                       'Prices':[
                          {
                             'NormalPrice':100.55,
                             'DiscountPrice':null,
                             'CurrencySymbol':'€',
                             'CurrencyId':2
                          },
                          {
                             'NormalPrice':140.55,
                             'DiscountPrice':null,
                             'CurrencySymbol':'$',
                             'CurrencyId':1
                          }
                       ],
                       'Tags':[

                       ],
                       'Weights':[

                       ],
                       'Dimensions':[
                          {
                             'DimensionTypeId':1,
                             'DimensionDescription':'Meter',
                             'Width':1,
                             'Height':1,
                             'Depth':1
                          },
                          {
                             'DimensionTypeId':2,
                             'DimensionDescription':'Inch',
                             'Width':3,
                             'Height':3,
                             'Depth':3
                          }
                       ],
                       'Metadata':[

                       ],
                       'ImageAssets':[

                       ],
                       'VideoAssets':[

                       ],
                       'DocumentAssets':[

                       ],
                       'HasVariants':true
                    },
                    'BluetoothId':'BluetoothId',
                    'DateAdded':'2013-07-12T12:53:39.777',
                    'UniqueKey':'90a1de56-20ea-4460-b6f1-6ab533387f6b'
                 },
                 {
                    'CategoryMetadata':null,
                    'Item':{
                       'DynamicAttributes':[
                          {
                             'TypeId':1,
                             'TypeValueId':1,
                             'Value':'Red',
                             'TypeName':'Color'
                          },
                          {
                             'TypeId':3,
                             'TypeValueId':7,
                             'Value':'A',
                             'TypeName':'Style'
                          },
                          {
                             'TypeId':2,
                             'TypeValueId':9,
                             'Value':'S',
                             'TypeName':'Size'
                          }
                       ],
                       'Id':2,
                       'RFID':null,
                       'UUID':null,
                       'SKU':null,
                       'Name':'D2 Red-S-A Style',
                       'Model':'Model 2',
                       'Title':'D2 Title',
                       'ShortDescription':'D2 Short Description',
                       'LongDescription':'D2 Long Description',
                       'Rating':null,
                       'LikeCount':null,
                       'CategoryId':67,
                       'InStock':true,
                       'PublicWebLink':null,
                       'DefaultItemId':2,
                       'BrandId':2,
                       'UnitTypeId':2,
                       'UnitTypeName':'250 Kilogram',
                       'UnitTypeCode':'Kg',
                       'Prices':[
                          {
                             'NormalPrice':10.55,
                             'DiscountPrice':null,
                             'CurrencySymbol':'$',
                             'CurrencyId':1
                          },
                          {
                             'NormalPrice':20.55,
                             'DiscountPrice':15,
                             'CurrencySymbol':'€',
                             'CurrencyId':2
                          }
                       ],
                       'Tags':[
                          {
                             'Id':2,
                             'Name':'c4da4bd6-2783-4a45-8fa8-2c4777113f19',
                             'Description':'c4da4bd6-2783-4a45-8fa8-2c4777113f19',
                             'TagMetadata':[

                             ]
                          }
                       ],
                       'Weights':[

                       ],
                       'Dimensions':[
                          {
                             'DimensionTypeId':1,
                             'DimensionDescription':'Meter',
                             'Width':11,
                             'Height':11,
                             'Depth':11
                          },
                          {
                             'DimensionTypeId':2,
                             'DimensionDescription':'Inch',
                             'Width':5,
                             'Height':5,
                             'Depth':5
                          }
                       ],
                       'Metadata':[

                       ],
                       'ImageAssets':[

                       ],
                       'VideoAssets':[

                       ],
                       'DocumentAssets':[

                       ],
                       'HasVariants':true
                    },
                    'BluetoothId':'BluetoothId',
                    'DateAdded':'2013-07-12T12:53:40.753',
                    'UniqueKey':'5df0c833-326f-4ac1-8ea2-a118b17b6e95'
                 }
              ],
              'LastSeenLocation':null,
              'IsPublic':true,
              'UniqueKey':'3d6a2c36-d85e-458f-b13f-438c03bc22be'
           }
        }";

        const string validAPIResponseForGetNoParameterAsync = @"{
            'Data': [
                '63644db9-cfa5-41ae-b2c8-11b9c4de11fd',
                '0c2c71b7-4f7f-40cf-9ed4-bcc336d8bd52',
                '92436a5a-4cb7-44b1-8d2b-f75e263f0e29'
            ]
        }";

        const string validAPIResponseForPostAsync = @"{
            'Data':
                {
                    'UniqueKey': 'f3924b10-02e2-4f9a-8f7c-d6fdcb5a9b92',
                    'Name': 'My Wishlist',
                    'LastSeenLocation':
                    {
                        'Longitude': -122.335197,
                        'Latitude': 47.646711
                    },
                    'IsPublic': false
                }
        }";

        const string validAPIResponseForPutAsync = @"{
            'Data':
                {
                    'UniqueKey': 'f3924b10-02e2-4f9a-8f7c-d6fdcb5a9b92',
                    'Name': 'Test Wishlist1',
                    'LastSeenLocation':
                    {
                        'Longitude': -122.335197,
                        'Latitude': 47.646711
                    },
                    'IsPublic': false
                }
        }";

        const string validAPIRequestForPostAsync = @"{
            'Name': 'Test Wishlist',
            'LastSeenLocation': {
                'Longitude': -122.335197,
                'Latitude': 47.646711
            },
            'IsPublic': false,
        }";

        const string validAPIRequestForPutAsync = @"{
            'UniqueKey': 'f3924b10-02e2-4f9a-8f7c-d6fdcb5a9b92',
            'Name': 'Test Wishlist',
            'LastSeenLocation':
             {
                  'Longitude': -122.335197,
                  'Latitude': 47.646711
             },
        }";

        const string validAPIRequestForPostMailAsync = @"{
            'MailTemplateName': 'Templat1',
            'UniqueKey': '63644db9-cfa5-41ae-b2c8-11b9c4de11fd',
            'To': 'mycustomer@email.com',
            'ToDisplayName': 'My Customer',
        }";

        readonly Wishlist sampleWishlist = new Wishlist()
        {
            Name = "Test Wishlist",
            LastSeenLocation = new Location()
            {
                Longitude = -122.335197,
                Latitude = 47.646711
            },
            IsPublic = false
        };

        readonly Wishlist sampleWishlistForPutAsync = new Wishlist()
        {
            UniqueKey = Guid.Parse("f3924b10-02e2-4f9a-8f7c-d6fdcb5a9b92"),
            Name = "Test Wishlist",
            LastSeenLocation = new Location()
            {
                Longitude = -122.335197,
                Latitude = 47.646711
            },
            IsPublic = false
        };

        readonly MailSendRequest sampleMailSendRequest = new MailSendRequest()
        {
            MailTemplateName = "Test Templat1",
            UniqueKey = Guid.Parse("63644db9-cfa5-41ae-b2c8-11b9c4de11fd"),
            To = "mycustomer@email.com",
            ToDisplayName = "My Customer"
        };

        readonly Location sampleLocation = new Location()
        {
            Latitude = 22,
            Longitude = 23
        };

        readonly Location sampleLatitudeInvalidLocation = new Location()
        {
            Latitude = 91,
            Longitude = 45
        };

        readonly Location sampleLongitudeInvalidLocation = new Location()
        {
            Latitude = 45,
            Longitude = 181
        };

        #region DeleteAsync ByClearing

        [TestMethod, TestCategory("WishlistClient"), TestCategory("DeleteAsync"), TestCategory("HTTP.DELETE")]
        public async Task DeleteByClearingAsyncHttpMethodTest()
        {
            await base.HttpMethodTestAsync(
                (WishlistClient c) => c.DeleteAsync(),
                HttpMethod.Delete,
                piiUser: piiUser
                );
        }

        [TestMethod, TestCategory("WishlistClient"), TestCategory("DeleteAsync"), TestCategory("HTTP.DELETE")]
        public async Task DeleteByClearingAsyncUriCheckTest()
        {
            await base.UriTestAsync(
              (WishlistClient c) => c.DeleteAsync(),
              "/pii/wishlists",
              piiUser: piiUser
              );
        }

        [TestMethod, TestCategory("WishlistClient"), TestCategory("DeleteAsync"), TestCategory("HTTP.DELETE")]
        public async Task DeleteByClearingAsyncDefaultRequestHeadersTest()
        {
            await base.DefaultRequestHeadersTestAsync(
                (WishlistClient c) => c.DeleteAsync(),
                piiUser: piiUser
                );
        }

        [TestMethod, TestCategory("WishlistClient"), TestCategory("DeleteAsync"), TestCategory("HTTP.DELETE")]
        public async Task DeleteAsyncWithUniqeKeyNotFoundTest()
        {
            var expectedExceptionResult = JsonConvert.DeserializeObject<ExceptionResult>(genericErrorResponse);
            expectedExceptionResult.HttpStatusCode = HttpStatusCode.NotFound;

            await base.APIExceptionResponseTestAsync(
              (WishlistClient c) => c.DeleteAsync(Guid.Parse(uniqeId)),
              notFoundHttpResponseMessage,
              expectedExceptionResult,
              piiUser: piiUser
              );
        }

        #endregion

        #region DeleteAsync ByDeleting


        [TestMethod, TestCategory("WishlistClient"), TestCategory("DeleteAsync"), TestCategory("HTTP.DELETE")]
        public async Task DeleteByDeletingAsyncHttpMethodTest()
        {
            await base.HttpMethodTestAsync(
                (WishlistClient d) => d.DeleteAsync(Guid.Parse(uniqeId)),
                HttpMethod.Delete,
                piiUser: piiUser
                );
        }

        [TestMethod, TestCategory("WishlistClient"), TestCategory("DeleteAsync"), TestCategory("HTTP.DELETE")]
        public async Task DeleteByDeletingAsyncUriCheckTest()
        {
            await base.UriTestAsync(
              (WishlistClient d) => d.DeleteAsync(Guid.Parse(uniqeId)),
              string.Format("/pii/wishlist?wishlistUniqueKey={0}", uniqeId),
              piiUser: piiUser
              );
        }

        [TestMethod, TestCategory("WishlistClient"), TestCategory("DeleteAsync"), TestCategory("HTTP.DELETE")]
        public async Task DeleteByDeletingAsyncDefaultRequestHeadersTest()
        {
            await base.DefaultRequestHeadersTestAsync(
                (WishlistClient d) => d.DeleteAsync(Guid.Parse(uniqeId)),
                piiUser: piiUser
                );
        }

        [TestMethod, TestCategory("WishlistClient"), TestCategory("DeleteAsync"), TestCategory("HTTP.DELETE")]
        public async Task DeleteByDeletingAsyncNotFoundTest()
        {
            var expectedExceptionResult = JsonConvert.DeserializeObject<ExceptionResult>(genericErrorResponse);
            expectedExceptionResult.HttpStatusCode = HttpStatusCode.NotFound;

            await base.APIExceptionResponseTestAsync(
              (WishlistClient d) => d.DeleteAsync(Guid.Parse(uniqeId)),
              notFoundHttpResponseMessage,
              expectedExceptionResult,
              piiUser: piiUser
              );
        }

        [TestMethod, TestCategory("WishlistClient"), TestCategory("DeleteAsync"), TestCategory("HTTP.DELETE")]
        public async Task DeleteByDeletingAsyncForbiddenTest()
        {
            var expectedExceptionResult = JsonConvert.DeserializeObject<ExceptionResult>(genericErrorResponse);
            expectedExceptionResult.HttpStatusCode = HttpStatusCode.Forbidden;

            await base.APIExceptionResponseTestAsync(
              (WishlistClient d) => d.DeleteAsync(Guid.Parse(uniqeId)),
              forbiddenHttpResponseMessage,
              expectedExceptionResult,
              piiUser: piiUser
              );
        }
        #endregion

        #region GetAsync

        [TestMethod, TestCategory("WishlistClient"), TestCategory("GetAsync"), TestCategory("HTTP.GET")]
        public async Task GetAsyncResponseParseTest()
        {
            await base.ResponseParseTestAsync(
                (WishlistClient c) => c.GetAsync(Guid.Parse(uniqeId)),
                new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new MockedJsonContent(validAPIResponseForGetAsync)
                },
                validAPIResponseForGetAsync,
                piiUser : piiUser
                );
        }

        [TestMethod, TestCategory("WishlistClient"), TestCategory("GetAsync"), TestCategory("HTTP.GET")]
        public async Task GetAsyncHttpMethodTest()
        {
            await base.HttpMethodTestAsync(
                (WishlistClient c) => c.GetAsync(Guid.Parse(uniqeId)),
                HttpMethod.Get,
                piiUser : piiUser
                );
        }

        [TestMethod, TestCategory("WishlistClient"), TestCategory("GetAsync"), TestCategory("HTTP.GET")]
        public async Task GetAsyncUriCheckTest()
        {
            await base.UriTestAsync(
                (WishlistClient c) => c.GetAsync(Guid.Parse(uniqeId)),
              string.Format("/pii/wishlist?wishlistUniqueKey={0}&includeItemStaticProperties={1}&includeItemDynamicProperties={2}&includeCategoryMetadata={3}&imageAssetDetail={4}&videoAssetDetail={5}&documentAssetDetail={6}", uniqeId, true, false, false, 0, 0, 0), piiUser: piiUser);

            await base.UriTestAsync(
              (WishlistClient c) => c.GetAsync(Guid.Parse(uniqeId), sampleLocation),
              string.Format("/pii/wishlist?wishlistUniqueKey={0}&longitude={1}&latitude={2}&includeItemStaticProperties={3}&includeItemDynamicProperties={4}&includeCategoryMetadata={5}&imageAssetDetail={6}&videoAssetDetail={7}&documentAssetDetail={8}", uniqeId, 23, 22, true, false, false, 0, 0, 0, 0), piiUser: piiUser);

            await base.UriTestAsync(
              (WishlistClient c) => c.GetAsync(Guid.Parse(uniqeId), sampleLocation, includeItemStaticProperties: false),
              string.Format("/pii/wishlist?wishlistUniqueKey={0}&longitude={1}&latitude={2}&includeItemStaticProperties={3}&includeItemDynamicProperties={4}&includeCategoryMetadata={5}&imageAssetDetail={6}&videoAssetDetail={7}&documentAssetDetail={8}", uniqeId, sampleLocation.Longitude, sampleLocation.Latitude, false, false, false, 0, 0, 0), piiUser: piiUser);

            await base.UriTestAsync(
              (WishlistClient c) => c.GetAsync(Guid.Parse(uniqeId), sampleLocation, includeItemDynamicProperties: true),
              string.Format("/pii/wishlist?wishlistUniqueKey={0}&longitude={1}&latitude={2}&includeItemStaticProperties={3}&includeItemDynamicProperties={4}&includeCategoryMetadata={5}&imageAssetDetail={6}&videoAssetDetail={7}&documentAssetDetail={8}", uniqeId, sampleLocation.Longitude, sampleLocation.Latitude, true, true, false, 0, 0, 0), piiUser: piiUser);

            await base.UriTestAsync(
              (WishlistClient c) => c.GetAsync(Guid.Parse(uniqeId), sampleLocation, includeCategoryMetadata: true),
               string.Format("/pii/wishlist?wishlistUniqueKey={0}&longitude={1}&latitude={2}&includeItemStaticProperties={3}&includeItemDynamicProperties={4}&includeCategoryMetadata={5}&imageAssetDetail={6}&videoAssetDetail={7}&documentAssetDetail={8}", uniqeId, sampleLocation.Longitude, sampleLocation.Latitude, true, false, true, 0, 0, 0), piiUser: piiUser);

            await base.UriTestAsync(
              (WishlistClient c) => c.GetAsync(Guid.Parse(uniqeId), sampleLocation, includeItemStaticProperties: false, includeItemDynamicProperties: true, includeCategoryMetadata: true),
               string.Format("/pii/wishlist?wishlistUniqueKey={0}&longitude={1}&latitude={2}&includeItemStaticProperties={3}&includeItemDynamicProperties={4}&includeCategoryMetadata={5}&imageAssetDetail={6}&videoAssetDetail={7}&documentAssetDetail={8}", uniqeId, sampleLocation.Longitude, sampleLocation.Latitude, false, true, true, 0, 0, 0), piiUser: piiUser);

            await base.UriTestAsync(
              (WishlistClient c) => c.GetAsync(Guid.Parse(uniqeId), sampleLocation, includeItemStaticProperties: false, includeItemDynamicProperties: true, includeCategoryMetadata: true, imageAssetDetail: AssetDetailType.IncludeAll, videoAssetDetail: AssetDetailType.None, documentAssetDetail: AssetDetailType.IncludeOnlyDefaultWithMetadata),
               string.Format("/pii/wishlist?wishlistUniqueKey={0}&longitude={1}&latitude={2}&includeItemStaticProperties={3}&includeItemDynamicProperties={4}&includeCategoryMetadata={5}&imageAssetDetail={6}&videoAssetDetail={7}&documentAssetDetail={8}", uniqeId, sampleLocation.Longitude, sampleLocation.Latitude, false, true, true, 2, 0, 4), piiUser: piiUser);

            await base.UriTestAsync(
              (WishlistClient c) => c.GetAsync(Guid.Parse(uniqeId), sampleLocation, includeItemStaticProperties: false, includeItemDynamicProperties: true, includeCategoryMetadata: true, imageAssetDetail: AssetDetailType.IncludeAll, videoAssetDetail: AssetDetailType.None, documentAssetDetail: AssetDetailType.IncludeOnlyDefaultWithMetadata, metadataKey: "key", metadataValue: "value"),
               string.Format("/pii/wishlist?wishlistUniqueKey={0}&longitude={1}&latitude={2}&includeItemStaticProperties={3}&includeItemDynamicProperties={4}&includeCategoryMetadata={5}&imageAssetDetail={6}&videoAssetDetail={7}&documentAssetDetail={8}&metadataKey={9}&metadataValue={10}", uniqeId, sampleLocation.Longitude, sampleLocation.Latitude, false, true, true, 2, 0, 4, "key", "value"), piiUser: piiUser);
        }

        [TestMethod, TestCategory("WishlistClient"), TestCategory("GetAsync"), TestCategory("HTTP.GET")]
        public async Task GetAsyncDefaultRequestHeadersTest()
        {
            await base.DefaultRequestHeadersTestAsync(
                (WishlistClient c) => c.GetAsync(Guid.Parse(uniqeId)),
                piiUser: piiUser
            );
        }

        [TestMethod, TestCategory("WishlistClient"), TestCategory("GetAsync"), TestCategory("HTTP.GET")]
        public async Task GetAsyncParameterTest()
        {
            await base.SDKExceptionResponseTestAsync(
                (WishlistClient c) => c.GetAsync(Guid.Parse(uniqeId), location: sampleLatitudeInvalidLocation),
                new ArgumentOutOfRangeException("Latitude", 91, string.Format("{0} must be in range ({1} - {2}).", "Latitude", -90, 90)),piiUser:piiUser);

            await base.SDKExceptionResponseTestAsync(
                (WishlistClient c) => c.GetAsync(Guid.Parse(uniqeId), location: sampleLongitudeInvalidLocation),
                new ArgumentOutOfRangeException("Longitude", 181, string.Format("{0} must be in range ({1} - {2}).", "Longitude", -180, 180)), piiUser: piiUser);

            await base.SDKExceptionResponseTestAsync(
                (WishlistClient c) => c.GetAsync(Guid.Parse(uniqeId), metadataKey: "key"),
                new ArgumentException("metadataValue can not be empty or null."), piiUser: piiUser);

            await base.SDKExceptionResponseTestAsync(
                (WishlistClient c) => c.GetAsync(Guid.Parse(uniqeId), metadataValue: "value"),
                new ArgumentException("metadataKey can not be empty or null."), piiUser: piiUser);
        }

        #endregion

        #region PostAccessAsync

        [TestMethod, TestCategory("WishlistClient"), TestCategory("PostAccessAsync"), TestCategory("HTTP.POST")]
        public async Task PostAccessAsyncHttpMethodTest()
        {
            await base.HttpMethodTestAsync(
                (WishlistClient c) => c.PostAccessAsync(Guid.Parse(uniqeId), true),
                HttpMethod.Post, piiUser: piiUser
                );
        }

        [TestMethod, TestCategory("WishlistClient"), TestCategory("PostAccessAsync"), TestCategory("HTTP.POST")]
        public async Task PostAccessAsyncUriCheckTest()
        {
            await base.UriTestAsync(
              (WishlistClient c) => c.PostAccessAsync(Guid.Parse(uniqeId), true),
              string.Format("/pii/wishlistaccess?wishlistUniqueKey={0}&isPublic={1}", uniqeId, true),
              piiUser: piiUser
              );
        }

        [TestMethod, TestCategory("WishlistClient"), TestCategory("PostAccessAsync"), TestCategory("HTTP.POST")]
        public async Task PostAccessAsyncDefaultRequestHeadersTest()
        {
            await base.DefaultRequestHeadersTestAsync(
                (WishlistClient c) => c.PostAccessAsync(Guid.Parse(uniqeId), true),
                piiUser: piiUser
                );
        }

        [TestMethod, TestCategory("WishlistClient"), TestCategory("PostAccessAsync"), TestCategory("HTTP.POST")]
        public async Task PostAccessAsyncNotFoundTest()
        {
            var expectedExceptionResult = JsonConvert.DeserializeObject<ExceptionResult>(genericErrorResponse);
            expectedExceptionResult.HttpStatusCode = HttpStatusCode.NotFound;

            await base.APIExceptionResponseTestAsync(
              (WishlistClient c) => c.PostAccessAsync(Guid.Parse(uniqeId), true),
              notFoundHttpResponseMessage,
              expectedExceptionResult,
              piiUser: piiUser
              );
        }

        [TestMethod, TestCategory("WishlistClient"), TestCategory("PostAccessAsync"), TestCategory("HTTP.POST")]
        public async Task PostAccessAsyncForbiddenTest()
        {
            var expectedExceptionResult = JsonConvert.DeserializeObject<ExceptionResult>(genericErrorResponse);
            expectedExceptionResult.HttpStatusCode = HttpStatusCode.Forbidden;

            await base.APIExceptionResponseTestAsync(
              (WishlistClient c) => c.PostAccessAsync(Guid.Parse(uniqeId), true),
              forbiddenHttpResponseMessage,
              expectedExceptionResult,
              piiUser: piiUser
              );
        }
        #endregion

        #region GetNoParameterAsync

        [TestMethod, TestCategory("WishlistClient"), TestCategory("GetNoParameterAsync"), TestCategory("HTTP.GET")]
        public async Task GetNoParameterAsyncResponseParseTest()
        {
            await base.ResponseParseTestAsync(
                (WishlistClient c) => c.GetAsync(),
                new HttpResponseMessage(HttpStatusCode.OK) 
                {
                    Content = new MockedJsonContent(validAPIResponseForGetNoParameterAsync)
                },
                validAPIResponseForGetNoParameterAsync,
                piiUser: piiUser);
        }

        [TestMethod, TestCategory("WishlistClient"), TestCategory("GetNoParameterAsync"), TestCategory("HTTP.GET")]
        public async Task GetNoParameterAsyncHttpMethodTest()
        {
            await base.HttpMethodTestAsync(
                (WishlistClient c) => c.GetAsync(),
                HttpMethod.Get,
                piiUser:piiUser 
                );
        }

        [TestMethod, TestCategory("WishlistClient"), TestCategory("GetNoParameterAsync"), TestCategory("HTTP.GET")]
        public async Task GetNoParameterAsyncUriCheckTest()
        {
            await base.UriTestAsync(
              (WishlistClient c) => c.GetAsync(),
              string.Format("/pii/wishlists"),
              piiUser:piiUser
              );
        }

        [TestMethod, TestCategory("WishlistClient"), TestCategory("GetNoParameterAsync"), TestCategory("HTTP.GET")]
        public async Task GetNoParameterAsyncDefaultRequestHeadersTest()
        {
            await base.DefaultRequestHeadersTestAsync(
                (WishlistClient c) => c.GetAsync(),
                piiUser:piiUser
                );
        }

        [TestMethod, TestCategory("WishlistClient"), TestCategory("GetNoParameterAsync"), TestCategory("HTTP.GET")]
        public async Task GetNoParameterAsyncNotFoundTest()
        {
            var expectedExceptionResult = JsonConvert.DeserializeObject<ExceptionResult>(genericErrorResponse);
            expectedExceptionResult.HttpStatusCode = HttpStatusCode.NotFound;

            await base.APIExceptionResponseTestAsync(
              (WishlistClient c) => c.GetAsync(),
              notFoundHttpResponseMessage,
              expectedExceptionResult,
              piiUser:piiUser
              );
        }
        
        #endregion

        #region PostWishlistAsync

        [TestMethod, TestCategory("WishlistClient"), TestCategory("PostWishlistAsync"), TestCategory("HTTP.POST")]
        public async Task PostWishlistAsyncRequestParseTest()
        {
            await base.RequestParseTestAsync<Wishlist>(
                (WishlistClient c) => c.PostWishlistAsync(sampleWishlist),
                validAPIRequestForPostAsync,
                piiUser: piiUser
                );
        }

        [TestMethod, TestCategory("WishlistClient"), TestCategory("PostWishlistAsync"), TestCategory("HTTP.POST")]
        public async Task PostWishlistAsyncHttpMethodTest()
        {
            await base.HttpMethodTestAsync(
                (WishlistClient c) => c.PostWishlistAsync(sampleWishlist),
                HttpMethod.Post,
                piiUser: piiUser
                );
        }

        [TestMethod, TestCategory("WishlistClient"), TestCategory("PostWishlistAsync"), TestCategory("HTTP.POST")]
        public async Task PostWishlistAsyncUriCheckTest()
        {
            await base.UriTestAsync(
              (WishlistClient p) => p.PostWishlistAsync(sampleWishlist),
              "/pii/wishlist",
              piiUser: piiUser
              );
        }

        [TestMethod, TestCategory("WishlistClient"), TestCategory("PostWishlistAsync"), TestCategory("HTTP.POST")]
        public async Task PostWishlistAsyncDefaultRequestHeadersTest()
        {
            await base.DefaultRequestHeadersTestAsync(
                (WishlistClient p) => p.PostWishlistAsync(sampleWishlist),
                piiUser: piiUser
                );
        }

        [TestMethod, TestCategory("WishlistClient"), TestCategory("PostWishlistAsync"), TestCategory("HTTP.POST")]
        public async Task PostWishlistAsyncParameterTest()
        {
            await base.SDKExceptionResponseTestAsync(
                (WishlistClient c) => c.PostWishlistAsync(null),
                new ArgumentNullException("wishlist can not be null.")
                , piiUser: piiUser);

            await base.SDKExceptionResponseTestAsync(
                (WishlistClient p) => p.PostWishlistAsync(new WishlistWithItems()
                {
                    LastSeenLocation = sampleLatitudeInvalidLocation
                }),
                new ArgumentOutOfRangeException("Latitude", 91, string.Format("{0} must be in range ({1} - {2}).", "Latitude", -90, 90))
                , piiUser: piiUser);

            await base.SDKExceptionResponseTestAsync(
                (WishlistClient p) => p.PostWishlistAsync(new WishlistWithItems()
                {
                    LastSeenLocation = sampleLongitudeInvalidLocation
                }),
                  new ArgumentOutOfRangeException("Longitude", 181, string.Format("{0} must be in range ({1} - {2}).", "Longitude", -180, 180))
                , piiUser: piiUser);
        }
        #endregion

        #region PutAsync
        
        [TestMethod, TestCategory("WishlistClient"), TestCategory("PutAsync"), TestCategory("HTTP.PUT")]
        public async Task PutAsyncRequestParseTest()
        {
            await base.RequestParseTestAsync<ShoppingCart>(
                (WishlistClient c) => c.PutAsync(sampleWishlistForPutAsync),
                validAPIRequestForPutAsync,
                piiUser: piiUser
                );
        }

        [TestMethod, TestCategory("WishlistClient"), TestCategory("PutAsync"), TestCategory("HTTP.PUT")]
        public async Task PutAsyncHttpMethodTest()
        {
            await base.HttpMethodTestAsync(
                (WishlistClient c) => c.PutAsync(sampleWishlistForPutAsync),
                HttpMethod.Put,
                piiUser: piiUser
                );
        }

        [TestMethod, TestCategory("WishlistClient"), TestCategory("PutAsync"), TestCategory("HTTP.PUT")]
        public async Task PutAsyncUriCheckTest()
        {
            await base.UriTestAsync(
              (WishlistClient c) => c.PutAsync(sampleWishlistForPutAsync),
              "/pii/wishlist",
              piiUser: piiUser
              );
        }

        [TestMethod, TestCategory("WishlistClient"), TestCategory("PutAsync"), TestCategory("HTTP.PUT")]
        public async Task PutAsyncParametersTest()
        {
            await base.SDKExceptionResponseTestAsync(
               (WishlistClient c) => c.PutAsync(null),
               new ArgumentNullException("wishlist can not be null."), piiUser: piiUser);

            await base.SDKExceptionResponseTestAsync(
                (WishlistClient c) => c.PutAsync(new Wishlist()
                {
                    LastSeenLocation = sampleLatitudeInvalidLocation
                }),
                    new ArgumentOutOfRangeException("Latitude", 91, string.Format("{0} must be in range ({1} - {2}).", "Latitude", -90, 90)), piiUser: piiUser);

            await base.SDKExceptionResponseTestAsync(
                (WishlistClient c) => c.PutAsync(new Wishlist()
                {
                    LastSeenLocation = sampleLongitudeInvalidLocation
                }),
                new ArgumentOutOfRangeException("Longitude", 181, string.Format("{0} must be in range ({1} - {2}).", "Longitude", -180, 180)), piiUser: piiUser);
        }

        [TestMethod, TestCategory("WishlistClient"), TestCategory("PutAsync"), TestCategory("HTTP.PUT")]
        public async Task PutAsyncDefaultRequestHeadersTest()
        {
            await base.DefaultRequestHeadersTestAsync(
                (WishlistClient c) => c.PutAsync(sampleWishlistForPutAsync),
                piiUser: piiUser
                );
        }

        #endregion

        #region PostMailAsync

        [TestMethod, TestCategory("WishlistClient"), TestCategory("PostMailAsync"), TestCategory("HTTP.POST")]
        public async Task PostMailAsyncRequestParseTest()
        {
            await base.RequestParseTestAsync<ShoppingCart>(
                (WishlistClient c) => c.PostMailAsync(sampleMailSendRequest),
                validAPIRequestForPostMailAsync,
                piiUser: piiUser
                );
        }

        [TestMethod, TestCategory("WishlistClient"), TestCategory("PostMailAsync"), TestCategory("HTTP.POST")]
        public async Task PostMailAsyncHttpMethodTest()
        {
            await base.HttpMethodTestAsync(
                (WishlistClient c) => c.PostMailAsync(sampleMailSendRequest),
                HttpMethod.Post,
                piiUser: piiUser
                );
        }

        [TestMethod, TestCategory("WishlistClient"), TestCategory("PostMailAsync"), TestCategory("HTTP.POST")]
        public async Task PostMailAsyncUriCheckTest()
        {
            await base.UriTestAsync(
              (WishlistClient c) => c.PostMailAsync(sampleMailSendRequest),
              "/pii/wishlist/mail",
              piiUser: piiUser
              );
        }


        [TestMethod, TestCategory("WishlistClient"), TestCategory("PostMailAsync"), TestCategory("HTTP.POST")]
        public async Task PostMailAsyncNotFoundTest()
        {
            var expectedExceptionResult = JsonConvert.DeserializeObject<ExceptionResult>(genericErrorResponse);
            expectedExceptionResult.HttpStatusCode = HttpStatusCode.NotFound;

            await base.APIExceptionResponseTestAsync(
              (WishlistClient c) => c.PostMailAsync(sampleMailSendRequest),
              notFoundHttpResponseMessage,
              expectedExceptionResult,
              piiUser: piiUser
              );
        }

        [TestMethod, TestCategory("WishlistClient"), TestCategory("PostMailAsync"), TestCategory("HTTP.POST")]
        public async Task PostMailAsyncBadRequestTest()
        {
            var expectedExceptionResult = JsonConvert.DeserializeObject<ExceptionResult>(genericErrorResponse);
            expectedExceptionResult.HttpStatusCode = HttpStatusCode.BadRequest;

            await base.APIExceptionResponseTestAsync(
              (WishlistClient c) => c.PostMailAsync(sampleMailSendRequest),
              badRequestHttpResponseMessage,
              expectedExceptionResult,
              piiUser: piiUser
              );
        }

        [TestMethod, TestCategory("WishlistClient"), TestCategory("PostMailAsync"), TestCategory("HTTP.POST")]
        public async Task PostMailAsynForbiddenTest()
        {
            var expectedExceptionResult = JsonConvert.DeserializeObject<ExceptionResult>(genericErrorResponse);
            expectedExceptionResult.HttpStatusCode = HttpStatusCode.Forbidden;

            await base.APIExceptionResponseTestAsync(
              (WishlistClient c) => c.PostMailAsync(sampleMailSendRequest),
              forbiddenHttpResponseMessage,
              expectedExceptionResult,
              piiUser: piiUser
              );
        }

        [TestMethod, TestCategory("WishlistClient"), TestCategory("PostMailAsync"), TestCategory("HTTP.POST")]
        public async Task PostMailAsyncParametersTest()
        {
            await base.SDKExceptionResponseTestAsync(
               (WishlistClient c) => c.PostMailAsync(null),
               new ArgumentNullException("mailSendRequest can not be null."),
               piiUser: piiUser
               );
        }

        #endregion

    }
}
