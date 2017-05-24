using NSubstitute;
using NSubstitute.ExceptionExtensions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Rest.Preview.BulkExports;

namespace Twilio.Tests.Rest.Preview.BulkExports 
{

    [TestFixture]
    public class ExportTest : TwilioTest 
    {
        [Test]
        public void TestFetchRequest()
        {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            var request = new Request(
                HttpMethod.Get,
                Twilio.Rest.Domain.Preview,
                "/BulkExports/Exports/PathResourceType",
                ""
            );
            twilioRestClient.Request(request).Throws(new ApiException("Server Error, no content"));

            try
            {
                ExportResource.Fetch("PathResourceType", client: twilioRestClient);
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
                                         "{\"resource_type\": \"Calls\",\"url\": \"https://preview.twilio.com/BulkExports/Exports/Calls\",\"links\": {\"days\": \"https://preview.twilio.com/BulkExports/Exports/Calls/Days\"}}"
                                     ));

            var response = ExportResource.Fetch("PathResourceType", client: twilioRestClient);
            Assert.NotNull(response);
        }
    }

}