using NSubstitute;
using NSubstitute.ExceptionExtensions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Rest.Preview.Proxy.Service.Session;

namespace Twilio.Tests.Rest.Preview.Proxy.Service.Session 
{

    [TestFixture]
    public class ParticipantTest : TwilioTest 
    {
        [Test]
        public void TestFetchRequest()
        {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            var request = new Request(
                HttpMethod.Get,
                Twilio.Rest.Domain.Preview,
                "/Proxy/Services/KSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Sessions/KCaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Participants/KPaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa",
                ""
            );
            twilioRestClient.Request(request).Throws(new ApiException("Server Error, no content"));

            try
            {
                ParticipantResource.Fetch("KSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "KCaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "KPaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", client: twilioRestClient);
                Assert.Fail("Expected TwilioException to be thrown for 500");
            }
            catch (ApiException) {}
            twilioRestClient.Received().Request(request);
        }

        [Test]
        public void TestFetchResponse()
        {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            twilioRestClient.AccountSid.Returns("ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
            twilioRestClient.Request(Arg.Any<Request>())
                            .Returns(new Response(
                                         System.Net.HttpStatusCode.OK,
                                         "{\"service_sid\": \"KSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"participant_type\": \"sms\",\"identifier\": \"identifier\",\"date_updated\": \"2015-07-30T20:00:00Z\",\"proxy_identifier\": \"proxy_identifier\",\"friendly_name\": \"friendly_name\",\"date_created\": \"2015-07-30T20:00:00Z\",\"url\": \"https://preview.twilio.com/Proxy/Services/KSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Sessions/KCaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Participants/KPaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"links\": {\"message_interactions\": \"https://preview.twilio.com/Proxy/Services/KSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Sessions/KCaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Participants/KPaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/MessageInteractions\"},\"sid\": \"KPaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"account_sid\": \"ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"session_sid\": \"KCaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\"}"
                                     ));

            var response = ParticipantResource.Fetch("KSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "KCaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "KPaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", client: twilioRestClient);
            Assert.NotNull(response);
        }

        [Test]
        public void TestReadRequest()
        {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            var request = new Request(
                HttpMethod.Get,
                Twilio.Rest.Domain.Preview,
                "/Proxy/Services/KSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Sessions/KCaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Participants",
                ""
            );
            twilioRestClient.Request(request).Throws(new ApiException("Server Error, no content"));

            try
            {
                ParticipantResource.Read("KSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "KCaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", client: twilioRestClient);
                Assert.Fail("Expected TwilioException to be thrown for 500");
            }
            catch (ApiException) {}
            twilioRestClient.Received().Request(request);
        }

        [Test]
        public void TestReadEmptyResponse()
        {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            twilioRestClient.AccountSid.Returns("ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
            twilioRestClient.Request(Arg.Any<Request>())
                            .Returns(new Response(
                                         System.Net.HttpStatusCode.OK,
                                         "{\"meta\": {\"previous_page_url\": null,\"next_page_url\": null,\"url\": \"https://preview.twilio.com/Proxy/Services/KSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Sessions/KCaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Participants?PageSize=50&Page=0\",\"page\": 0,\"first_page_url\": \"https://preview.twilio.com/Proxy/Services/KSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Sessions/KCaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Participants?PageSize=50&Page=0\",\"page_size\": 50,\"key\": \"participants\"},\"participants\": []}"
                                     ));

            var response = ParticipantResource.Read("KSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "KCaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", client: twilioRestClient);
            Assert.NotNull(response);
        }

        [Test]
        public void TestCreateRequest()
        {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            var request = new Request(
                HttpMethod.Post,
                Twilio.Rest.Domain.Preview,
                "/Proxy/Services/KSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Sessions/KCaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Participants",
                ""
            );
            request.AddPostParam("Identifier", Serialize("Identifier"));
            twilioRestClient.Request(request).Throws(new ApiException("Server Error, no content"));

            try
            {
                ParticipantResource.Create("KSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "KCaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "Identifier", client: twilioRestClient);
                Assert.Fail("Expected TwilioException to be thrown for 500");
            }
            catch (ApiException) {}
            twilioRestClient.Received().Request(request);
        }

        [Test]
        public void TestCreateResponse()
        {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            twilioRestClient.AccountSid.Returns("ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
            twilioRestClient.Request(Arg.Any<Request>())
                            .Returns(new Response(
                                         System.Net.HttpStatusCode.Created,
                                         "{\"service_sid\": \"KSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"participant_type\": \"sms\",\"identifier\": \"identifier\",\"date_updated\": \"2015-07-30T20:00:00Z\",\"proxy_identifier\": \"proxy_identifier\",\"friendly_name\": \"friendly_name\",\"date_created\": \"2015-07-30T20:00:00Z\",\"url\": \"https://preview.twilio.com/Proxy/Services/KSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Sessions/KCaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Participants/KPaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"links\": {\"message_interactions\": \"https://preview.twilio.com/Proxy/Services/KSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Sessions/KCaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Participants/KPaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/MessageInteractions\"},\"sid\": \"KPaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"account_sid\": \"ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"session_sid\": \"KCaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\"}"
                                     ));

            var response = ParticipantResource.Create("KSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "KCaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "Identifier", client: twilioRestClient);
            Assert.NotNull(response);
        }

        [Test]
        public void TestDeleteRequest()
        {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            var request = new Request(
                HttpMethod.Delete,
                Twilio.Rest.Domain.Preview,
                "/Proxy/Services/KSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Sessions/KCaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Participants/KPaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa",
                ""
            );
            twilioRestClient.Request(request).Throws(new ApiException("Server Error, no content"));

            try
            {
                ParticipantResource.Delete("KSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "KCaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "KPaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", client: twilioRestClient);
                Assert.Fail("Expected TwilioException to be thrown for 500");
            }
            catch (ApiException) {}
            twilioRestClient.Received().Request(request);
        }

        [Test]
        public void TestDeleteResponse()
        {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            twilioRestClient.AccountSid.Returns("ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
            twilioRestClient.Request(Arg.Any<Request>())
                            .Returns(new Response(
                                         System.Net.HttpStatusCode.NoContent,
                                         "null"
                                     ));

            var response = ParticipantResource.Delete("KSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "KCaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "KPaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", client: twilioRestClient);
            Assert.NotNull(response);
        }

        [Test]
        public void TestUpdateRequest()
        {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            var request = new Request(
                HttpMethod.Post,
                Twilio.Rest.Domain.Preview,
                "/Proxy/Services/KSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Sessions/KCaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Participants/KPaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa",
                ""
            );
            twilioRestClient.Request(request).Throws(new ApiException("Server Error, no content"));

            try
            {
                ParticipantResource.Update("KSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "KCaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "KPaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", client: twilioRestClient);
                Assert.Fail("Expected TwilioException to be thrown for 500");
            }
            catch (ApiException) {}
            twilioRestClient.Received().Request(request);
        }

        [Test]
        public void TestUpdateResponse()
        {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            twilioRestClient.AccountSid.Returns("ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
            twilioRestClient.Request(Arg.Any<Request>())
                            .Returns(new Response(
                                         System.Net.HttpStatusCode.OK,
                                         "{\"service_sid\": \"KSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"participant_type\": \"sms\",\"identifier\": \"identifier\",\"date_updated\": \"2015-07-30T20:00:00Z\",\"proxy_identifier\": \"proxy_identifier\",\"friendly_name\": \"friendly_name\",\"date_created\": \"2015-07-30T20:00:00Z\",\"url\": \"https://preview.twilio.com/Proxy/Services/KSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Sessions/KCaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Participants/KPaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"links\": {\"message_interactions\": \"https://preview.twilio.com/Proxy/Services/KSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Sessions/KCaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Participants/KPaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/MessageInteractions\"},\"sid\": \"KPaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"account_sid\": \"ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"session_sid\": \"KCaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\"}"
                                     ));

            var response = ParticipantResource.Update("KSaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "KCaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "KPaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", client: twilioRestClient);
            Assert.NotNull(response);
        }
    }

}