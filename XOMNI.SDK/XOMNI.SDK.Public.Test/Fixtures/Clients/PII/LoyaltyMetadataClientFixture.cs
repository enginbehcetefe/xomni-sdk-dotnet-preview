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
using XOMNI.SDK.Public.Models.OmniPlay;
using XOMNI.SDK.Public.Models.PII;
using XOMNI.SDK.Public.Test.Helpers;

namespace XOMNI.SDK.Public.Test.Fixtures.Clients.PII
{
    [TestClass]
    public class LoyaltyMetadataClientFixture : BaseMetadataClientFixture<LoyaltyMetadataClient>
    {
        [TestMethod, TestCategory("LoyaltyMetadataClient"), TestCategory("GetImageMetadataAsync"), TestCategory("HTTP.GET")]
        public async Task GetAsyncResponseParseTest()
        {
            await base.MetadataResponseParseTestAsync(
                (LoyaltyMetadataClient l) => l.GetAsync(),
                validHttpResponseMessage,
                validAPIResponse,
                piiUser: piiUser
            );
        }

        [TestMethod, TestCategory("LoyaltyMetadataClient"), TestCategory("GetImageMetadataAsync"), TestCategory("HTTP.GET")]
        public async Task GetAsyncHttpMethodTest()
        {
            await base.HttpMethodTestAsync(
                (LoyaltyMetadataClient c) => c.GetAsync(),
                HttpMethod.Get,
                piiUser: piiUser);
        }

        [TestMethod, TestCategory("LoyaltyMetadataClient"), TestCategory("GetImageMetadataAsync"), TestCategory("HTTP.GET")]
        public async Task GetAsyncUriCheckTest()
        {
            await base.UriTestAsync(
              (LoyaltyMetadataClient c) => c.GetAsync(),
              "/pii/loyaltymetadata",
                piiUser: piiUser);
        }

        [TestMethod, TestCategory("LoyaltyMetadataClient"), TestCategory("GetImageMetadataAsync"), TestCategory("HTTP.GET")]
        public async Task GetAsyncNotFoundTest()
        {
            var expectedExceptionResult = JsonConvert.DeserializeObject<ExceptionResult>(genericErrorResponse);
            expectedExceptionResult.HttpStatusCode = HttpStatusCode.NotFound;

            await base.APIExceptionResponseTestAsync(
              (LoyaltyMetadataClient c) => c.GetAsync(),
              notFoundHttpResponseMessage,
              expectedExceptionResult,
                piiUser: piiUser);
        }

        [TestMethod, TestCategory("LoyaltyMetadataClient"), TestCategory("GetImageMetadataAsync"), TestCategory("HTTP.GET")]
        public async Task GetAsyncUnauthorizedTest()
        {
            var expectedExceptionResult = JsonConvert.DeserializeObject<ExceptionResult>(genericErrorResponse);
            expectedExceptionResult.HttpStatusCode = HttpStatusCode.Unauthorized;

            await base.APIExceptionResponseTestAsync(
              (LoyaltyMetadataClient c) => c.GetAsync(),
              unauthorizedHttpResponseMessage,
              expectedExceptionResult,
                piiUser: piiUser);
        }

        [TestMethod, TestCategory("LoyaltyMetadataClient"), TestCategory("GetImageMetadataAsync"), TestCategory("HTTP.GET")]
        public async Task GetAsyncSDKExceptionTest()
        {
            await base.SDKExceptionResponseTestAsync(
                (LoyaltyMetadataClient c) => c.GetAsync(),
                new ArgumentException("User/OmniSession")
            );
        }

        [TestMethod, TestCategory("LoyaltyMetadataClient"), TestCategory("GetImageMetadataAsync"), TestCategory("HTTP.GET")]
        public async Task GetAsyncDefaultRequestHeadersTest()
        {
            await base.DefaultRequestHeadersTestAsync(
                (LoyaltyMetadataClient c) => c.GetAsync(),
                piiUser: piiUser);
        }

    }
}
