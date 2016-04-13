using NSubstitute;
using NUnit.Framework;
using System;
using Twilio;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Resources.Trunking.V1.Trunk;

namespace Twilio.Tests.Trunking.V1.Trunk {

    [TestFixture]
    public class OriginationUrlTest : TwilioTest {
        [SetUp]
        public void SetUp() {
        }
    
        [TestCase]
        public void TestFetchRequest() {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            Request request = new Request(System.Net.Http.HttpMethod.Get,
                                          Domains.TRUNKING,
                                          "/v1/Trunks/TRaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/OriginationUrls/OUaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
            
            
            twilioRestClient.Request(request)
                            .Returns(new Response(System.Net.HttpStatusCode.OK, null));
            
            try {
                OriginationUrlResource.Fetch("TRaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "OUaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa").ExecuteAsync(twilioRestClient);
                Assert.Fail("Expected TwilioException to be thrown for 500");
            } catch (TwilioException e) {}
            twilioRestClient.Received().Request(request);
        }
    
        [Test]
        public void TestFetchResponse() {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            twilioRestClient.Request(Arg.Any<Request>())
                            .Returns(new Response(System.Net.HttpStatusCode.OK,
                                     "{\"weight\": 1,\"date_updated\": \"2015-01-02T11:23:45Z\",\"enabled\": true,\"friendly_name\": \"friendly_name\",\"account_sid\": \"ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"priority\": 1,\"sip_url\": \"sip://sip-box.com:1234\",\"sid\": \"OUaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"date_created\": \"2015-01-02T11:23:45Z\",\"trunk_sid\": \"TRaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"url\": \"https://trunking.twilio.com/v1/Trunks/TRaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/OriginationUrls/OUaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\"}"));
            
            Assert.NotNull(OriginationUrlResource.Fetch("TRaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "OUaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa")
                  .ExecuteAsync(twilioRestClient));
        }
    
        [TestCase]
        public void TestDeleteRequest() {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            Request request = new Request(System.Net.Http.HttpMethod.Delete,
                                          Domains.TRUNKING,
                                          "/v1/Trunks/TRaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/OriginationUrls/OUaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
            
            
            twilioRestClient.Request(request)
                            .Returns(new Response(System.Net.HttpStatusCode.OK, null));
            
            try {
                OriginationUrlResource.Delete("TRaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "OUaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa").ExecuteAsync(twilioRestClient);
                Assert.Fail("Expected TwilioException to be thrown for 500");
            } catch (TwilioException e) {}
            twilioRestClient.Received().Request(request);
        }
    
        [Test]
        public void TestDeleteResponse() {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            twilioRestClient.Request(Arg.Any<Request>())
                            .Returns(new Response(System.Net.HttpStatusCode.NoContent,
                                     "null"));
            
            OriginationUrlResource.Delete("TRaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "OUaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa").ExecuteAsync(twilioRestClient);
        }
    
        [TestCase]
        public void TestCreateRequest() {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
                        Request request = new Request(System.Net.Http.HttpMethod.Post,
                                                      Domains.TRUNKING,
                                                      "/v1/Trunks/TRaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/OriginationUrls");
                        request.AddPostParam("Weight", Serialize(1));
            request.AddPostParam("Priority", Serialize(1));
            request.AddPostParam("Enabled", Serialize(true));
            request.AddPostParam("FriendlyName", Serialize("friendlyName"));
            request.AddPostParam("SipUrl", Serialize(new Uri("https://example.com")));
                        
                        twilioRestClient.Request(request)
                                        .Returns(new Response(System.Net.HttpStatusCode.OK, null));
            
            try {
                OriginationUrlResource.Create("TRaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", 1, 1, true, "friendlyName", new Uri("https://example.com")).ExecuteAsync(twilioRestClient);
                Assert.Fail("Expected TwilioException to be thrown for 500");
            } catch (TwilioException e) {}
            twilioRestClient.Received().Request(request);
        }
    
        [Test]
        public void TestCreateResponse() {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            twilioRestClient.Request(Arg.Any<Request>())
                            .Returns(new Response(System.Net.HttpStatusCode.Created,
                                     "{\"weight\": 1,\"date_updated\": \"2015-01-02T11:23:45Z\",\"enabled\": true,\"friendly_name\": \"friendly_name\",\"account_sid\": \"ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"priority\": 1,\"sip_url\": \"sip://sip-box.com:1234\",\"sid\": \"OUaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"date_created\": \"2015-01-02T11:23:45Z\",\"trunk_sid\": \"TRaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"url\": \"https://trunking.twilio.com/v1/Trunks/TRaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/OriginationUrls/OUaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\"}"));
            
            OriginationUrlResource.Create("TRaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", 1, 1, true, "friendlyName", new Uri("https://example.com")).ExecuteAsync(twilioRestClient);
        }
    
        [TestCase]
        public void TestReadRequest() {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            Request request = new Request(System.Net.Http.HttpMethod.Get,
                                          Domains.TRUNKING,
                                          "/v1/Trunks/TRaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/OriginationUrls");
            
            request.AddQueryParam("PageSize", "50");
            twilioRestClient.Request(request)
                            .Returns(new Response(System.Net.HttpStatusCode.OK, null));
            
            try {
                OriginationUrlResource.Read("TRaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa").ExecuteAsync(twilioRestClient);
                Assert.Fail("Expected TwilioException to be thrown for 500");
            } catch (TwilioException e) {}
            twilioRestClient.Received().Request(request);
        }
    
        [Test]
        public void TestReadFullResponse() {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            twilioRestClient.Request(Arg.Any<Request>())
                            .Returns(new Response(System.Net.HttpStatusCode.OK,
                                     "{\"meta\": {\"first_page_url\": \"https://trunking.twilio.com/v1/Trunks/TRaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/OriginationUrls?PageSize=1&Page=0\",\"key\": \"origination_urls\",\"next_page_url\": null,\"page\": 0,\"page_size\": 1,\"previous_page_url\": null,\"url\": \"https://trunking.twilio.com/v1/Trunks/TRaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/OriginationUrls?PageSize=1&Page=0\"},\"origination_urls\": [{\"weight\": 1,\"date_updated\": \"2015-01-02T11:23:45Z\",\"enabled\": true,\"friendly_name\": \"friendly_name\",\"account_sid\": \"ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"priority\": 1,\"sip_url\": \"sip://sip-box.com:1234\",\"sid\": \"OUaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"date_created\": \"2015-01-02T11:23:45Z\",\"trunk_sid\": \"TRaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"url\": \"https://trunking.twilio.com/v1/Trunks/TRaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/OriginationUrls/OUaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\"}]}"));
            
            Assert.NotNull(OriginationUrlResource.Read("TRaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa")
                  .ExecuteAsync(twilioRestClient));
        }
    
        [Test]
        public void TestReadEmptyResponse() {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            twilioRestClient.Request(Arg.Any<Request>())
                            .Returns(new Response(System.Net.HttpStatusCode.OK,
                                     "{\"meta\": {\"first_page_url\": \"https://trunking.twilio.com/v1/Trunks/TRaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/OriginationUrls?PageSize=1&Page=0\",\"key\": \"origination_urls\",\"next_page_url\": null,\"page\": 0,\"page_size\": 1,\"previous_page_url\": null,\"url\": \"https://trunking.twilio.com/v1/Trunks/TRaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/OriginationUrls?PageSize=1&Page=0\"},\"origination_urls\": []}"));
            
            Assert.NotNull(OriginationUrlResource.Read("TRaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa")
                  .ExecuteAsync(twilioRestClient));
        }
    
        [TestCase]
        public void TestUpdateRequest() {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            Request request = new Request(System.Net.Http.HttpMethod.Post,
                                          Domains.TRUNKING,
                                          "/v1/Trunks/TRaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/OriginationUrls/OUaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
            
            
            twilioRestClient.Request(request)
                            .Returns(new Response(System.Net.HttpStatusCode.OK, null));
            
            try {
                OriginationUrlResource.Update("TRaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "OUaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa").ExecuteAsync(twilioRestClient);
                Assert.Fail("Expected TwilioException to be thrown for 500");
            } catch (TwilioException e) {}
            twilioRestClient.Received().Request(request);
        }
    
        [Test]
        public void TestUpdateResponse() {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            twilioRestClient.Request(Arg.Any<Request>())
                            .Returns(new Response(System.Net.HttpStatusCode.OK,
                                     "{\"weight\": 2,\"date_updated\": \"2015-01-02T11:23:45Z\",\"enabled\": false,\"friendly_name\": \"updated_name\",\"account_sid\": \"ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"priority\": 2,\"sip_url\": \"sip://sip-updated.com:4321\",\"sid\": \"OUaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"date_created\": \"2015-01-02T11:23:45Z\",\"trunk_sid\": \"TRaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"url\": \"https://trunking.twilio.com/v1/Trunks/TRaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/OriginationUrls/OUaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\"}"));
            
            OriginationUrlResource.Update("TRaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "OUaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa").ExecuteAsync(twilioRestClient);
        }
    }
}