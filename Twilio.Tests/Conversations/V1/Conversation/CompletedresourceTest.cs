using NSubstitute;
using NUnit.Framework;
using System;
using Twilio;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Resources.Conversations.V1.Conversation;

namespace Twilio.Tests.Conversations.V1.Conversation {

    [TestFixture]
    public class CompletedTest : TwilioTest {
        [SetUp]
        public void SetUp() {
        }
    
        [TestCase]
        public void TestReadRequest() {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            Request request = new Request(System.Net.Http.HttpMethod.Get,
                                          Domains.CONVERSATIONS,
                                          "/v1/Conversations/Completed");
            
            request.AddQueryParam("PageSize", "50");
            twilioRestClient.Request(request)
                            .Returns(new Response(System.Net.HttpStatusCode.OK, null));
            
            try {
                CompletedResource.Read().ExecuteAsync(twilioRestClient);
                Assert.Fail("Expected TwilioException to be thrown for 500");
            } catch (TwilioException e) {}
            twilioRestClient.Received().Request(request);
        }
    
        [Test]
        public void TestReadFullResponse() {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            twilioRestClient.Request(Arg.Any<Request>())
                            .Returns(new Response(System.Net.HttpStatusCode.OK,
                                     "{\"conversations\": [{\"account_sid\": \"ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"date_created\": \"2015-05-12T21:08:50Z\",\"duration\": 60,\"end_time\": \"2015-05-12T21:09:50Z\",\"links\": {\"participants\": \"https://conversations.twilio.com/v1/Conversations/CVaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Participants\"},\"sid\": \"CVaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"start_time\": \"2015-05-12T21:08:50Z\",\"status\": \"completed\",\"url\": \"https://conversations.twilio.com/v1/Conversations/CVaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\"}],\"meta\": {\"first_page_url\": \"https://conversations.twilio.com/v1/Conversations/Completed?PageSize=50&Page=0\",\"key\": \"conversations\",\"next_page_url\": null,\"page\": 0,\"page_size\": 50,\"previous_page_url\": null,\"url\": \"https://conversations.twilio.com/v1/Conversations/Completed?PageSize=50&Page=0\"}}"));
            
            Assert.NotNull(CompletedResource.Read()
                  .ExecuteAsync(twilioRestClient));
        }
    
        [Test]
        public void TestReadEmptyResponse() {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            twilioRestClient.Request(Arg.Any<Request>())
                            .Returns(new Response(System.Net.HttpStatusCode.OK,
                                     "{\"conversations\": [],\"meta\": {\"first_page_url\": \"https://conversations.twilio.com/v1/Conversations/Completed?PageSize=50&Page=0\",\"key\": \"conversations\",\"next_page_url\": null,\"page\": 0,\"page_size\": 50,\"previous_page_url\": null,\"url\": \"https://conversations.twilio.com/v1/Conversations/Completed?PageSize=50&Page=0\"}}"));
            
            Assert.NotNull(CompletedResource.Read()
                  .ExecuteAsync(twilioRestClient));
        }
    }
}