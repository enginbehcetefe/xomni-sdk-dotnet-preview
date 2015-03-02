using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using XOMNI.SDK.Public.Clients.Catalog;
using XOMNI.SDK.Public.Models;
using XOMNI.SDK.Public.Models.Catalog;
using XOMNI.SDK.Public.Test.Helpers;

namespace XOMNI.SDK.Public.Test.Fixtures.Clients.Catalog
{
    [TestClass]
    public class BrandClientFixture : BaseClientFixture<BrandClient>
    {
        #region Arrange
        const string validAPIResponse = @"{
            'Data': {
                'Results': [
                    {
                        'Id': 1,
                        'Name': 'Brand 1'
                    },
                    {
                        'Id': 2,
                        'Name': 'Brand 2'
                    },
                    {
                        'Id': 3,
                        'Name': 'Brand 3'
                    }
                ],
                'TotalCount': 12
            }
        } ";

        const string validAPIRequest = @"{
            'DefaultItemId':null,
            'RFID':null,
            'UUID':null,
            'Name':null,
            'SKU':null,
            'CategoryId':66,
            'BrandId':12,
            'Model':null,
            'Title':null,
            'MinWidth':100,
            'MaxWidth':300,
            'MinHeight':null,
            'MaxHeight':null,
            'MinWeigth':null,
            'MaxWeigth':null,
            'MinDepth' : null,
            'MaxDepth' : null,
            'DimensionTypeId' : 2,
            'WeightTypeId' :null,
            'MinPrice':null,
            'MaxPrice':null,
            'TagId':6,
            'DelimitedDynamicAttributeValues':null,
            'IncludeOnlyMasterItems':false,
            'TagQuery' : null,
            'IncludePassiveItems' : false
        }";

        readonly SearchRequest searchRequest = new SearchRequest()
        {
            DefaultItemId = null,
            RFID = null,
            UUID = null,
            Name = null,
            SKU = null,
            CategoryId = 66,
            BrandId = 12,
            Model = null,
            Title = null,
            MinWidth = 100,
            MaxWidth = 300,
            MinWeight = null,
            MaxWeight = null,
            MinHeight = null,
            MaxHeight = null,
            MinDepth = null,
            MaxDepth = null,
            DimensionTypeId = 2,
            WeightTypeId = null,
            MinPrice = null,
            MaxPrice = null,
            TagId = 6,
            DelimitedDynamicAttributeValues = null,
            IncludeOnlyMasterItems = false,
            TagQuery = null,
            IncludePassiveItems = false
        };

        #endregion

        #region GetAsync
        [TestMethod, TestCategory("BrandClient"), TestCategory("GetAsync"), TestCategory("HTTP.GET")]
        public async Task GetAsyncResponseParseTest()
        {
            await base.ResponseParseTestAsync(
                (BrandClient c) => c.GetAsync(1, 2),
                new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new MockedJsonContent(validAPIResponse)
                },
                validAPIResponse
            );
        }

        [TestMethod, TestCategory("BrandClient"), TestCategory("GetAsync"), TestCategory("HTTP.GET")]
        public async Task GetAsyncHttpMethodTest()
        {
            await base.HttpMethodTestAsync(
                (BrandClient c) => c.GetAsync(1, 2),
                HttpMethod.Get);
        }

        [TestMethod, TestCategory("BrandClient"), TestCategory("GetAsync"), TestCategory("HTTP.GET")]
        public async Task GetAsyncUriCheckTest()
        {
            await base.UriTestAsync(
              (BrandClient c) => c.GetAsync(1, 2),
              "/catalog/brands?skip=1&take=2");
        }

        [TestMethod, TestCategory("BrandClient"), TestCategory("GetAsync"), TestCategory("HTTP.GET")]
        public async Task GetAsyncBadRequestTest()
        {
            var expectedExceptionResult = JsonConvert.DeserializeObject<ExceptionResult>(genericErrorResponse);
            expectedExceptionResult.HttpStatusCode = HttpStatusCode.BadRequest;

            await base.APIExceptionResponseTestAsync(
              (BrandClient c) => c.GetAsync(1, 2),
              badRequestHttpResponseMessage,
              expectedExceptionResult
            );
        }

        [TestMethod, TestCategory("BrandClient"), TestCategory("GetAsync"), TestCategory("HTTP.GET")]
        public async Task GetAsyncNotFoundTest()
        {
            var expectedExceptionResult = JsonConvert.DeserializeObject<ExceptionResult>(genericErrorResponse);
            expectedExceptionResult.HttpStatusCode = HttpStatusCode.NotFound;

            await base.APIExceptionResponseTestAsync(
              (BrandClient c) => c.GetAsync(1, 2),
              notFoundHttpResponseMessage,
              expectedExceptionResult
            );
        }

        [TestMethod, TestCategory("BrandClient"), TestCategory("GetAsync"), TestCategory("HTTP.GET")]
        public async Task GetAsyncSkipTest()
        {
            await base.SDKExceptionResponseTestAsync(
                (BrandClient c) => c.GetAsync(-1, 2),
                new ArgumentException("skip must be greater than or equal to 0.")
            );
        }

        [TestMethod, TestCategory("BrandClient"), TestCategory("GetAsync"), TestCategory("HTTP.GET")]
        public async Task GetAsyncTakeTest()
        {
            await base.SDKExceptionResponseTestAsync(
                (BrandClient c) => c.GetAsync(1, -2),
                new ArgumentException("take must be greater than or equal to 1.")
            );
        }

        [TestMethod, TestCategory("BrandClient"), TestCategory("GetAsync"), TestCategory("HTTP.GET")]
        public async Task GetAsyncHeadersTest()
        {
            await base.DefaultRequestHeadersTestAsync(
                (BrandClient c) => c.GetAsync(1, 2)
            );
        }
        #endregion

        #region GetBrandsByCategoryAsync
        [TestMethod, TestCategory("BrandClient"), TestCategory("GetBrandsByCategoryAsync"), TestCategory("HTTP.GET")]
        public async Task GetBrandsByCategoryAsyncResponseParseTest()
        {
            await base.ResponseParseTestAsync(
                (BrandClient c) => c.GetBrandsByCategoryAsync(1, 1, 2),
                new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new MockedJsonContent(validAPIResponse)
                },
                validAPIResponse
            );
        }

        [TestMethod, TestCategory("BrandClient"), TestCategory("GetBrandsByCategoryAsync"), TestCategory("HTTP.GET")]
        public async Task GetBrandsByCategoryAsyncHttpMethodTest()
        {
            await base.HttpMethodTestAsync(
                (BrandClient c) => c.GetBrandsByCategoryAsync(1, 1, 2),
                HttpMethod.Get);
        }

        [TestMethod, TestCategory("BrandClient"), TestCategory("GetBrandsByCategoryAsync"), TestCategory("HTTP.GET")]
        public async Task GetBrandsByCategoryAsyncUriCheckTest()
        {
            await base.UriTestAsync(
              (BrandClient c) => c.GetBrandsByCategoryAsync(1, 1, 2),
              "/catalog/brands?categoryId=1&skip=1&take=2");
        }

        [TestMethod, TestCategory("BrandClient"), TestCategory("GetBrandsByCategoryAsync"), TestCategory("HTTP.GET")]
        public async Task GetBrandsByCategoryAsyncBadRequestTest()
        {
            var expectedExceptionResult = JsonConvert.DeserializeObject<ExceptionResult>(genericErrorResponse);
            expectedExceptionResult.HttpStatusCode = HttpStatusCode.BadRequest;

            await base.APIExceptionResponseTestAsync(
              (BrandClient c) => c.GetBrandsByCategoryAsync(1, 1, 2),
              badRequestHttpResponseMessage,
              expectedExceptionResult
            );
        }

        [TestMethod, TestCategory("BrandClient"), TestCategory("GetBrandsByCategoryAsync"), TestCategory("HTTP.GET")]
        public async Task GetBrandsByCategoryAsyncNotFoundTest()
        {
            var expectedExceptionResult = JsonConvert.DeserializeObject<ExceptionResult>(genericErrorResponse);
            expectedExceptionResult.HttpStatusCode = HttpStatusCode.NotFound;

            await base.APIExceptionResponseTestAsync(
              (BrandClient c) => c.GetBrandsByCategoryAsync(1, 1, 2),
              notFoundHttpResponseMessage,
              expectedExceptionResult
            );
        }

        [TestMethod, TestCategory("BrandClient"), TestCategory("GetBrandsByCategoryAsync"), TestCategory("HTTP.GET")]
        public async Task GetBrandsByCategoryAsyncSkipTest()
        {
            await base.SDKExceptionResponseTestAsync(
                (BrandClient c) => c.GetBrandsByCategoryAsync(1, -1, 2),
                new ArgumentException("skip must be greater than or equal to 0.")
            );
        }

        [TestMethod, TestCategory("BrandClient"), TestCategory("GetBrandsByCategoryAsync"), TestCategory("HTTP.GET")]
        public async Task GetBrandsByCategoryAsyncTakeTest()
        {
            await base.SDKExceptionResponseTestAsync(
                (BrandClient c) => c.GetBrandsByCategoryAsync(1, 1, -2),
                new ArgumentException("take must be greater than or equal to 1.")
            );
        }

        [TestMethod, TestCategory("BrandClient"), TestCategory("GetBrandsByCategoryAsync"), TestCategory("HTTP.GET")]
        public async Task GetBrandsByCategoryAsyncCategoryIdTest()
        {
            await base.SDKExceptionResponseTestAsync(
                (BrandClient c) => c.GetBrandsByCategoryAsync(-1, 1, 2),
                new ArgumentException("categoryId must be greater than or equal to 1.")
            );
        }

        [TestMethod, TestCategory("BrandClient"), TestCategory("GetBrandsByCategoryAsync"), TestCategory("HTTP.GET")]
        public async Task GetBrandsByCategoryAsyncHeadersTest()
        {
            await base.DefaultRequestHeadersTestAsync(
                (BrandClient c) => c.GetBrandsByCategoryAsync(1, 1, 2)
            );
        }
        #endregion

        #region GetBrandsByTagAsync
        [TestMethod, TestCategory("BrandClient"), TestCategory("GetBrandsByTagAsync"), TestCategory("HTTP.GET")]
        public async Task GetBrandsByTagAsyncResponseParseTest()
        {
            await base.ResponseParseTestAsync(
                (BrandClient c) => c.GetBrandsByTagAsync(1, 1, 2),
                new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new MockedJsonContent(validAPIResponse)
                },
                validAPIResponse
            );
        }

        [TestMethod, TestCategory("BrandClient"), TestCategory("GetBrandsByTagAsync"), TestCategory("HTTP.GET")]
        public async Task GetBrandsByTagAsyncHttpMethodTest()
        {
            await base.HttpMethodTestAsync(
                (BrandClient c) => c.GetBrandsByTagAsync(1, 1, 2),
                HttpMethod.Get);
        }

        [TestMethod, TestCategory("BrandClient"), TestCategory("GetBrandsByTagAsync"), TestCategory("HTTP.GET")]
        public async Task GetBrandsByTagAsyncUriCheckTest()
        {
            await base.UriTestAsync(
              (BrandClient c) => c.GetBrandsByTagAsync(1, 1, 2),
              "/catalog/brands?tagId=1&skip=1&take=2");
        }

        [TestMethod, TestCategory("BrandClient"), TestCategory("GetBrandsByTagAsync"), TestCategory("HTTP.GET")]
        public async Task GetBrandsByTagAsyncBadRequestTest()
        {
            var expectedExceptionResult = JsonConvert.DeserializeObject<ExceptionResult>(genericErrorResponse);
            expectedExceptionResult.HttpStatusCode = HttpStatusCode.BadRequest;

            await base.APIExceptionResponseTestAsync(
              (BrandClient c) => c.GetBrandsByTagAsync(1, 1, 2),
              badRequestHttpResponseMessage,
              expectedExceptionResult
            );
        }

        [TestMethod, TestCategory("BrandClient"), TestCategory("GetBrandsByTagAsync"), TestCategory("HTTP.GET")]
        public async Task GetBrandsByTagAsyncNotFoundTest()
        {
            var expectedExceptionResult = JsonConvert.DeserializeObject<ExceptionResult>(genericErrorResponse);
            expectedExceptionResult.HttpStatusCode = HttpStatusCode.NotFound;

            await base.APIExceptionResponseTestAsync(
              (BrandClient c) => c.GetBrandsByTagAsync(1, 1, 2),
              notFoundHttpResponseMessage,
              expectedExceptionResult
            );
        }

        [TestMethod, TestCategory("BrandClient"), TestCategory("GetBrandsByTagAsync"), TestCategory("HTTP.GET")]
        public async Task GetBrandsByTagAsyncSkipTest()
        {
            await base.SDKExceptionResponseTestAsync(
                (BrandClient c) => c.GetBrandsByTagAsync(1, -1, 2),
                new ArgumentException("skip must be greater than or equal to 0.")
            );
        }

        [TestMethod, TestCategory("BrandClient"), TestCategory("GetBrandsByTagAsync"), TestCategory("HTTP.GET")]
        public async Task GetBrandsByTagAsyncTakeTest()
        {
            await base.SDKExceptionResponseTestAsync(
                (BrandClient c) => c.GetBrandsByTagAsync(1, 1, -2),
                new ArgumentException("take must be greater than or equal to 1.")
            );
        }

        [TestMethod, TestCategory("BrandClient"), TestCategory("GetBrandsByTagAsync"), TestCategory("HTTP.GET")]
        public async Task GetBrandsByTagAsyncTagIdTest()
        {
            await base.SDKExceptionResponseTestAsync(
                (BrandClient c) => c.GetBrandsByTagAsync(-1, 1, 2),
                new ArgumentException("tagId must be greater than or equal to 1.")
            );
        }

        [TestMethod, TestCategory("BrandClient"), TestCategory("GetBrandsByTagAsync"), TestCategory("HTTP.GET")]
        public async Task GetBrandsByTagAsyncHeadersTest()
        {
            await base.DefaultRequestHeadersTestAsync(
                (BrandClient c) => c.GetBrandsByTagAsync(1, 1, 2)
            );
        }
        #endregion

        #region GetBrandsBySearchRequestAsync
        [TestMethod, TestCategory("BrandClient"), TestCategory("GetBrandsBySearchRequestAsync"), TestCategory("HTTP.POST")]
        public async Task GetBrandsBySearchRequestAsyncResponseParseTest()
        {
            await base.ResponseParseTestAsync(
                (BrandClient c) => c.GetBrandsBySearchRequestAsync(searchRequest),
                new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new MockedJsonContent(validAPIResponse)
                },
                validAPIResponse
            );
        }

        [TestMethod, TestCategory("BrandClient"), TestCategory("GetBrandsBySearchRequestAsync"), TestCategory("HTTP.POST")]
        public async Task GetBrandsBySearchRequestAsyncRequestParseTest()
        {
            await base.RequestParseTestAsync<SearchRequest>(
                (BrandClient c) => c.GetBrandsBySearchRequestAsync(searchRequest),
                validAPIRequest
            );
        }

        [TestMethod, TestCategory("BrandClient"), TestCategory("GetBrandsBySearchRequestAsync"), TestCategory("HTTP.POST")]
        public async Task GetBrandsBySearchRequestAsyncHttpMethodTest()
        {
            await base.HttpMethodTestAsync(
                (BrandClient c) => c.GetBrandsBySearchRequestAsync(searchRequest),
                HttpMethod.Post);
        }

        [TestMethod, TestCategory("BrandClient"), TestCategory("GetBrandsBySearchRequestAsync"), TestCategory("HTTP.POST")]
        public async Task GetBrandsBySearchRequestAsyncUriCheckTest()
        {
            await base.UriTestAsync(
              (BrandClient c) => c.GetBrandsBySearchRequestAsync(searchRequest),
              "/catalog/brands");
        }

        [TestMethod, TestCategory("BrandClient"), TestCategory("GetBrandsBySearchRequestAsync"), TestCategory("HTTP.POST")]
        public async Task GetBrandsBySearchRequestAsyncNotFoundTest()
        {
            var expectedExceptionResult = JsonConvert.DeserializeObject<ExceptionResult>(genericErrorResponse);
            expectedExceptionResult.HttpStatusCode = HttpStatusCode.NotFound;

            await base.APIExceptionResponseTestAsync(
              (BrandClient c) => c.GetBrandsBySearchRequestAsync(searchRequest),
              notFoundHttpResponseMessage,
              expectedExceptionResult
            );
        }

        [TestMethod, TestCategory("BrandClient"), TestCategory("GetBrandsBySearchRequestAsync"), TestCategory("HTTP.POST")]
        public async Task GetBrandsBySearchRequestAsyncHeadersTest()
        {
            await base.SDKExceptionResponseTestAsync(
                (BrandClient c) => c.GetBrandsBySearchRequestAsync(null),
                new ArgumentNullException("searchRequest can not be null."));

            await base.SDKExceptionResponseTestAsync(
                (BrandClient c) => c.GetBrandsBySearchRequestAsync(new SearchRequest()
                {
                    MinWeight = 300,
                    MaxWeight = 400,
                    DelimitedDynamicAttributeValues = "1:1"
                }),
                new ArgumentNullException("WeightTypeId can not be null.")
            );

            await base.SDKExceptionResponseTestAsync(
              (BrandClient c) => c.GetBrandsBySearchRequestAsync(new SearchRequest()
              {
                  MinWidth = 300,
                  MinHeight = 300,
                  MinDepth = 400,
                  DelimitedDynamicAttributeValues = "1:1"
              }),
              new ArgumentNullException("DimensionTypeId can not be null."));

            await base.SDKExceptionResponseTestAsync(
              (BrandClient c) => c.GetBrandsBySearchRequestAsync(new SearchRequest()
              {
                  MinWidth = 300,
                  MaxWidth = 220,
                  DelimitedDynamicAttributeValues = "1:1"
              }),
              new ArgumentException(string.Format("{0} can not be greater than {1}.", "MinWidth", "MaxWidth")));
        }
        #endregion
    }
}
