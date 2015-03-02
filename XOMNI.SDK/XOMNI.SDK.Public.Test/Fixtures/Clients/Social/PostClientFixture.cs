using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using XOMNI.SDK.Public.Clients.Social;
using XOMNI.SDK.Public.Models;
using XOMNI.SDK.Public.Models.Social;
using XOMNI.SDK.Public.Test.Helpers;

namespace XOMNI.SDK.Public.Test.Fixtures.Clients.Social
{
    [TestClass]
    public class PostClientFixture : BaseClientFixture<PostClient>
    {
        #region arrange

        const string validAPIResponseForGetPostAndDeleteAsync = @"{
            'Data':{
                'Comments':[
                   {
                       'TargetPostId':16,
                       'TargetCommentId':0,
                       'Id':14,
                       'CreatedDate':'2013-08-14T14:07:54.813',
                       'Content':'This is a sample comment.',
                       'RelatedItemId':5,
                       'AvailablePlatforms':[
                          {
                              'Platform':'Facebook',
                              'Status':'Succeed',
                              'Author':'Test User',
                              'AuthorPictureUrl':'http://graph.facebook.com/100005333233573/picture'
                          }
                       ]
                   }
                ],
                'Author':'Test PII User',
                'Id':16,
                'CreatedDate':'2013-08-14T13:51:03.563',
                'Content':'This is a sample post.',
                'RelatedItemId':5,
                'AvailablePlatforms':[
                   {
                       'Platform':'Facebook',
                       'Status':'Succeed',
                       'Author':'Test User',
                       'AuthorPictureUrl':'http://graph.facebook.com/100005333233573/picture'
                   }
                ]
            }
        }";

        const string validAPIResponseForGetPoliciesAsync = @"{
          'Data': {
            'MaxContentLength': 112,
            'ShortenedUrlLength': 23,
            'RepliedToTwitterAlias': 'xomni_cloud'
          }
        }";

        readonly SocialPostRequest sampleSocialPostRequest = new SocialPostRequest()
        {
            Content = "TestContent",
            RelatedItemId = 5
        };

        #endregion

        #region GetAsync

        [TestMethod, TestCategory("PostClient"), TestCategory("GetAsync"), TestCategory("HTTP.GET")]
        public async Task GetAsyncResponseParseTest()
        {
            await base.ResponseParseTestAsync(
                (PostClient p) => p.GetAsync(1),
                    new HttpResponseMessage(HttpStatusCode.OK)
                    {
                        Content = new MockedJsonContent(validAPIResponseForGetPostAndDeleteAsync)
                    },
                    validAPIResponseForGetPostAndDeleteAsync,
                    piiUser: piiUser
            );
        }

        [TestMethod, TestCategory("PostClient"), TestCategory("GetAsync"), TestCategory("HTTP.GET")]
        public async Task GetAsyncHttpMethodTest()
        {
            await base.HttpMethodTestAsync(
                (PostClient p) => p.GetAsync(1),
                HttpMethod.Get,
                piiUser: piiUser);
        }

        [TestMethod, TestCategory("PostClient"), TestCategory("GetAsync"), TestCategory("HTTP.GET")]
        public async Task GetAsyncUriCheckTest()
        {
            await base.UriTestAsync(
              (PostClient p) => p.GetAsync(1),
              "/social/post?relatedItemId=1",
                piiUser: piiUser);
        }

        [TestMethod, TestCategory("PostClient"), TestCategory("GetAsync"), TestCategory("HTTP.GET")]
        public async Task GetAsyncNotFoundTest()
        {
            var expectedExceptionResult = JsonConvert.DeserializeObject<ExceptionResult>(genericErrorResponse);
            expectedExceptionResult.HttpStatusCode = HttpStatusCode.NotFound;

            await base.APIExceptionResponseTestAsync(
              (PostClient p) => p.GetAsync(1),
              notFoundHttpResponseMessage,
              expectedExceptionResult,
                piiUser: piiUser);
        }

        [TestMethod, TestCategory("PostClient"), TestCategory("GetAsync"), TestCategory("HTTP.GET")]
        public async Task GetAsyncSDKExceptionTest()
        {
            await base.SDKExceptionResponseTestAsync(
                (PostClient p) => p.GetAsync(1),
                new ArgumentException("User/OmniSession")
                );
        }

        [TestMethod, TestCategory("PostClient"), TestCategory("GetAsync"), TestCategory("HTTP.GET")]
        public async Task GetAsyncDefaultRequestHeadersTest()
        {
            await base.DefaultRequestHeadersTestAsync(
                (PostClient p) => p.GetAsync(1),
                piiUser: piiUser);
        }

        [TestMethod, TestCategory("PostClient"), TestCategory("GetAsync"), TestCategory("HTTP.GET")]
        public async Task GetAsyncTargetRelatedItemIdValidTest()
        {
            await base.SDKExceptionResponseTestAsync(
                (PostClient p) => p.GetAsync(-1),
                new ArgumentException("relatedItemId must be greater than or equal to 1."),
                piiUser: piiUser
            );
        }

        #endregion

        #region GetPoliciesAsync

        [TestMethod, TestCategory("PostClient"), TestCategory("GetPoliciesAsync"), TestCategory("HTTP.GET")]
        public async Task GetPoliciesAsyncResponseParseTest()
        {
            await base.ResponseParseTestAsync(
                (PostClient p) => p.GetPoliciesAsync(),
                    new HttpResponseMessage(HttpStatusCode.OK)
                    {
                        Content = new MockedJsonContent(validAPIResponseForGetPoliciesAsync)
                    },
                    validAPIResponseForGetPoliciesAsync,
                    piiUser: piiUser
            );
        }

        [TestMethod, TestCategory("PostClient"), TestCategory("GetPoliciesAsync"), TestCategory("HTTP.GET")]
        public async Task GetPoliciesAsyncHttpMethodTest()
        {
            await base.HttpMethodTestAsync(
                (PostClient p) => p.GetPoliciesAsync(),
                HttpMethod.Get,
                piiUser: piiUser);
        }

        [TestMethod, TestCategory("PostClient"), TestCategory("GetPoliciesAsync"), TestCategory("HTTP.GET")]
        public async Task GetPoliciesAsyncUriCheckTest()
        {
            await base.UriTestAsync(
              (PostClient p) => p.GetPoliciesAsync(),
              "/social/post/policies",
                piiUser: piiUser);
        }

        [TestMethod, TestCategory("PostClient"), TestCategory("GetPoliciesAsync"), TestCategory("HTTP.GET")]
        public async Task GetPoliciesAsyncNotFoundTest()
        {
            var expectedExceptionResult = JsonConvert.DeserializeObject<ExceptionResult>(genericErrorResponse);
            expectedExceptionResult.HttpStatusCode = HttpStatusCode.NotFound;

            await base.APIExceptionResponseTestAsync(
              (PostClient p) => p.GetPoliciesAsync(),
              notFoundHttpResponseMessage,
              expectedExceptionResult,
                piiUser: piiUser);
        }


        [TestMethod, TestCategory("PostClient"), TestCategory("GetPoliciesAsync"), TestCategory("HTTP.GET")]
        public async Task GetPoliciesAsyncSDKExceptionTest()
        {
            await base.SDKExceptionResponseTestAsync(
                (PostClient p) => p.GetPoliciesAsync(),
                new ArgumentException("User/OmniSession")
                );
        }

        [TestMethod, TestCategory("PostClient"), TestCategory("GetPoliciesAsync"), TestCategory("HTTP.GET")]
        public async Task GetPoliciesAsyncDefaultRequestHeadersTest()
        {
            await base.DefaultRequestHeadersTestAsync(
                (PostClient p) => p.GetPoliciesAsync(),
                piiUser: piiUser);
        }

        #endregion

        #region PostAsync
        [TestMethod, TestCategory("PostClient"), TestCategory("PostAsync"), TestCategory("HTTP.POST")]
        public async Task PostAsyncResponseParseTest()
        {
            await base.ResponseParseTestAsync(
                (PostClient p) => p.PostAsync(new SocialPostRequest()
                {
                    RelatedItemId = 1,
                    Content = "Test"
                }),
                    new HttpResponseMessage(HttpStatusCode.OK)
                    {
                        Content = new MockedJsonContent(validAPIResponseForGetPostAndDeleteAsync)
                    },
                    validAPIResponseForGetPostAndDeleteAsync
                    );
        }

        [TestMethod, TestCategory("PostClient"), TestCategory("PostAsync"), TestCategory("HTTP.POST")]
        public async Task PostAsyncHttpMethodTest()
        {
            await base.HttpMethodTestAsync(
                (PostClient p) => p.PostAsync(sampleSocialPostRequest),
                HttpMethod.Post
                );
        }

        [TestMethod, TestCategory("PostClient"), TestCategory("PostAsync"), TestCategory("HTTP.POST")]
        public async Task PostAsyncUriCheckTest()
        {
            await base.UriTestAsync(
              (PostClient p) => p.PostAsync(sampleSocialPostRequest),
              "/social/post"
              );
        }

        [TestMethod, TestCategory("PostClient"), TestCategory("PostAsync"), TestCategory("HTTP.POST")]
        public async Task PostAsyncNotFoundTest()
        {
            var expectedExceptionResult = JsonConvert.DeserializeObject<ExceptionResult>(genericErrorResponse);
            expectedExceptionResult.HttpStatusCode = HttpStatusCode.NotFound;

            await base.APIExceptionResponseTestAsync(
              (PostClient p) => p.PostAsync(sampleSocialPostRequest),
              notFoundHttpResponseMessage,
              expectedExceptionResult
              );
        }

        [TestMethod, TestCategory("PostClient"), TestCategory("PostAsync"), TestCategory("HTTP.POST")]
        public async Task PostAsyncConflictTest()
        {
            var expectedExceptionResult = JsonConvert.DeserializeObject<ExceptionResult>(genericErrorResponse);
            expectedExceptionResult.HttpStatusCode = HttpStatusCode.Conflict;

            await base.APIExceptionResponseTestAsync(
              (PostClient p) => p.PostAsync(sampleSocialPostRequest),
              conflictHttpResponseMessage,
              expectedExceptionResult
              );
        }

        [TestMethod, TestCategory("PostClient"), TestCategory("PostAsync"), TestCategory("HTTP.POST")]
        public async Task PostAsyncDefaultRequestHeadersTest()
        {
            await base.DefaultRequestHeadersTestAsync(
                (PostClient p) => p.PostAsync(sampleSocialPostRequest)
                );
        }

        [TestMethod, TestCategory("PostClient"), TestCategory("PostAsync"), TestCategory("HTTP.POST")]
        public async Task PostAsyncTargetPostIdValidTest()
        {
            await base.SDKExceptionResponseTestAsync(
                (PostClient p) => p.PostAsync(new SocialPostRequest()
                {
                    RelatedItemId = -1,
                    Content = "Test"
                }),
                new ArgumentException("RelatedItemId must be greater than or equal to 1.")
                );
        }

        [TestMethod, TestCategory("PostClient"), TestCategory("PostRequestCommentToPostAsync"), TestCategory("HTTP.POST")]
        public async Task PostAsyncContentNullTest()
        {
            await base.SDKExceptionResponseTestAsync(
                (PostClient p) => p.PostAsync(new SocialPostRequest()
                {
                    RelatedItemId = 1,
                    Content = null
                }),
                new ArgumentException("Content can not be empty or null.")
                );
        }

        [TestMethod, TestCategory("PostClient"), TestCategory("PostAsync"), TestCategory("HTTP.POST")]
        public async Task PostAsyncRequestParseTest()
        {
            string requestJson = @"{
                'RelatedItemId':'5',
                'Content':'This is a sample comment'
            }";

            await base.RequestParseTestAsync<SocialComment>(
                (PostClient p) => p.PostAsync(new SocialPostRequest()
                    {
                        Content = "This is a sample comment",
                        RelatedItemId = 5
                    })
                    ,requestJson
                    );
        }
        #endregion

        #region DeleteAsync

        [TestMethod, TestCategory("PostClient"), TestCategory("DeleteAsync"), TestCategory("HTTP.DELETE")]
        public async Task DeleteAsyncResponseParseTest()
        {
            await base.ResponseParseTestAsync(
                (PostClient p) => p.DeleteAsync(1),
                    new HttpResponseMessage(HttpStatusCode.Accepted)
                    {
                        Content = new MockedJsonContent(validAPIResponseForGetPostAndDeleteAsync)
                    },
                    validAPIResponseForGetPostAndDeleteAsync,
                    piiUser: piiUser
            );
        }

        [TestMethod, TestCategory("PostClient"), TestCategory("DeleteAsync"), TestCategory("HTTP.DELETE")]
        public async Task DeleteAsyncHttpMethodTest()
        {
            await base.HttpMethodTestAsync(
                (PostClient p) => p.DeleteAsync(1),
                HttpMethod.Delete,
                piiUser: piiUser);
        }

        [TestMethod, TestCategory("PostClient"), TestCategory("DeleteAsync"), TestCategory("HTTP.DELETE")]
        public async Task DeleteAsyncUriCheckTest()
        {
            await base.UriTestAsync(
              (PostClient p) => p.DeleteAsync(1),
              "/social/post/1",
                piiUser: piiUser);
        }

        [TestMethod, TestCategory("PostClient"), TestCategory("DeleteAsync"), TestCategory("HTTP.DELETE")]
        public async Task DeleteAsyncNotFoundTest()
        {
            var expectedExceptionResult = JsonConvert.DeserializeObject<ExceptionResult>(genericErrorResponse);
            expectedExceptionResult.HttpStatusCode = HttpStatusCode.NotFound;

            await base.APIExceptionResponseTestAsync(
              (PostClient p) => p.DeleteAsync(1),
              notFoundHttpResponseMessage,
              expectedExceptionResult,
                piiUser: piiUser);
        }

        [TestMethod, TestCategory("PostClient"), TestCategory("DeleteAsync"), TestCategory("HTTP.DELETE")]
        public async Task DeleteAsyncSDKExceptionTest()
        {
            await base.SDKExceptionResponseTestAsync(
                (PostClient p) => p.DeleteAsync(1),
                new ArgumentException("User/OmniSession")
                );
        }

        [TestMethod, TestCategory("PostClient"), TestCategory("DeleteAsync"), TestCategory("HTTP.DELETE")]
        public async Task DeleteAsyncDefaultRequestHeadersTest()
        {
            await base.DefaultRequestHeadersTestAsync(
                (PostClient p) => p.DeleteAsync(1),
                piiUser: piiUser);
        }

        [TestMethod, TestCategory("PostClient"), TestCategory("DeleteAsync"), TestCategory("HTTP.DELETE")]
        public async Task DeleteAsyncCommentIdValidTest()
        {
            await base.SDKExceptionResponseTestAsync(
                (PostClient p) => p.DeleteAsync(-1),
                new ArgumentException("socialPostId must be greater than or equal to 1."),
                piiUser: piiUser
            );
        }

        #endregion
    }
}
