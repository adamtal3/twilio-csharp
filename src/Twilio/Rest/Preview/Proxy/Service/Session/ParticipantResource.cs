using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Types;

namespace Twilio.Rest.Preview.Proxy.Service.Session 
{

    /// <summary>
    /// ParticipantResource
    /// </summary>
    public class ParticipantResource : Resource 
    {
        public sealed class ParticipantTypeEnum : StringEnum 
        {
            private ParticipantTypeEnum(string value) : base(value) {}
            public ParticipantTypeEnum() {}

            public static readonly ParticipantTypeEnum Sms = new ParticipantTypeEnum("sms");
            public static readonly ParticipantTypeEnum Voice = new ParticipantTypeEnum("voice");
            public static readonly ParticipantTypeEnum Phone = new ParticipantTypeEnum("phone");
        }

        private static Request BuildFetchRequest(FetchParticipantOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Get,
                Rest.Domain.Preview,
                "/Proxy/Services/" + options.PathServiceSid + "/Sessions/" + options.PathSessionSid + "/Participants/" + options.PathSid + "",
                client.Region,
                queryParams: options.GetParams()
            );
        }

        /// <summary>
        /// Fetch a specific Participant.
        /// </summary>
        ///
        /// <param name="options"> Fetch Participant parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Participant </returns> 
        public static ParticipantResource Fetch(FetchParticipantOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }

        #if !NET35
        /// <summary>
        /// Fetch a specific Participant.
        /// </summary>
        ///
        /// <param name="options"> Fetch Participant parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Participant </returns> 
        public static async System.Threading.Tasks.Task<ParticipantResource> FetchAsync(FetchParticipantOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }
        #endif

        /// <summary>
        /// Fetch a specific Participant.
        /// </summary>
        ///
        /// <param name="pathServiceSid"> Service Sid. </param>
        /// <param name="pathSessionSid"> Session Sid. </param>
        /// <param name="pathSid"> A string that uniquely identifies this Participant. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Participant </returns> 
        public static ParticipantResource Fetch(string pathServiceSid, string pathSessionSid, string pathSid, ITwilioRestClient client = null)
        {
            var options = new FetchParticipantOptions(pathServiceSid, pathSessionSid, pathSid);
            return Fetch(options, client);
        }

        #if !NET35
        /// <summary>
        /// Fetch a specific Participant.
        /// </summary>
        ///
        /// <param name="pathServiceSid"> Service Sid. </param>
        /// <param name="pathSessionSid"> Session Sid. </param>
        /// <param name="pathSid"> A string that uniquely identifies this Participant. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Participant </returns> 
        public static async System.Threading.Tasks.Task<ParticipantResource> FetchAsync(string pathServiceSid, string pathSessionSid, string pathSid, ITwilioRestClient client = null)
        {
            var options = new FetchParticipantOptions(pathServiceSid, pathSessionSid, pathSid);
            return await FetchAsync(options, client);
        }
        #endif

        private static Request BuildReadRequest(ReadParticipantOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Get,
                Rest.Domain.Preview,
                "/Proxy/Services/" + options.PathServiceSid + "/Sessions/" + options.PathSessionSid + "/Participants",
                client.Region,
                queryParams: options.GetParams()
            );
        }

        /// <summary>
        /// Retrieve a list of all Participants in this Session.
        /// </summary>
        ///
        /// <param name="options"> Read Participant parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Participant </returns> 
        public static ResourceSet<ParticipantResource> Read(ReadParticipantOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildReadRequest(options, client));

            var page = Page<ParticipantResource>.FromJson("participants", response.Content);
            return new ResourceSet<ParticipantResource>(page, options, client);
        }

        #if !NET35
        /// <summary>
        /// Retrieve a list of all Participants in this Session.
        /// </summary>
        ///
        /// <param name="options"> Read Participant parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Participant </returns> 
        public static async System.Threading.Tasks.Task<ResourceSet<ParticipantResource>> ReadAsync(ReadParticipantOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildReadRequest(options, client));

            var page = Page<ParticipantResource>.FromJson("participants", response.Content);
            return new ResourceSet<ParticipantResource>(page, options, client);
        }
        #endif

        /// <summary>
        /// Retrieve a list of all Participants in this Session.
        /// </summary>
        ///
        /// <param name="pathServiceSid"> Service Sid. </param>
        /// <param name="pathSessionSid"> Session Sid. </param>
        /// <param name="identifier"> The Participant's contact identifier, normally a phone number. </param>
        /// <param name="participantType"> The Type of this Participant </param>
        /// <param name="pageSize"> Page size </param>
        /// <param name="limit"> Record limit </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Participant </returns> 
        public static ResourceSet<ParticipantResource> Read(string pathServiceSid, string pathSessionSid, string identifier = null, ParticipantResource.ParticipantTypeEnum participantType = null, int? pageSize = null, long? limit = null, ITwilioRestClient client = null)
        {
            var options = new ReadParticipantOptions(pathServiceSid, pathSessionSid){Identifier = identifier, ParticipantType = participantType, PageSize = pageSize, Limit = limit};
            return Read(options, client);
        }

        #if !NET35
        /// <summary>
        /// Retrieve a list of all Participants in this Session.
        /// </summary>
        ///
        /// <param name="pathServiceSid"> Service Sid. </param>
        /// <param name="pathSessionSid"> Session Sid. </param>
        /// <param name="identifier"> The Participant's contact identifier, normally a phone number. </param>
        /// <param name="participantType"> The Type of this Participant </param>
        /// <param name="pageSize"> Page size </param>
        /// <param name="limit"> Record limit </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Participant </returns> 
        public static async System.Threading.Tasks.Task<ResourceSet<ParticipantResource>> ReadAsync(string pathServiceSid, string pathSessionSid, string identifier = null, ParticipantResource.ParticipantTypeEnum participantType = null, int? pageSize = null, long? limit = null, ITwilioRestClient client = null)
        {
            var options = new ReadParticipantOptions(pathServiceSid, pathSessionSid){Identifier = identifier, ParticipantType = participantType, PageSize = pageSize, Limit = limit};
            return await ReadAsync(options, client);
        }
        #endif

        /// <summary>
        /// Fetch the next page of records
        /// </summary>
        ///
        /// <param name="page"> current page of records </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> The next page of records </returns> 
        public static Page<ParticipantResource> NextPage(Page<ParticipantResource> page, ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.Get,
                page.GetNextPageUrl(
                    Rest.Domain.Preview,
                    client.Region
                )
            );

            var response = client.Request(request);
            return Page<ParticipantResource>.FromJson("participants", response.Content);
        }

        private static Request BuildCreateRequest(CreateParticipantOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Post,
                Rest.Domain.Preview,
                "/Proxy/Services/" + options.PathServiceSid + "/Sessions/" + options.PathSessionSid + "/Participants",
                client.Region,
                postParams: options.GetParams()
            );
        }

        /// <summary>
        /// Create a new Participant in this Session.
        /// </summary>
        ///
        /// <param name="options"> Create Participant parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Participant </returns> 
        public static ParticipantResource Create(CreateParticipantOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildCreateRequest(options, client));
            return FromJson(response.Content);
        }

        #if !NET35
        /// <summary>
        /// Create a new Participant in this Session.
        /// </summary>
        ///
        /// <param name="options"> Create Participant parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Participant </returns> 
        public static async System.Threading.Tasks.Task<ParticipantResource> CreateAsync(CreateParticipantOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildCreateRequest(options, client));
            return FromJson(response.Content);
        }
        #endif

        /// <summary>
        /// Create a new Participant in this Session.
        /// </summary>
        ///
        /// <param name="pathServiceSid"> Service Sid. </param>
        /// <param name="pathSessionSid"> Session Sid. </param>
        /// <param name="identifier"> The Participant's contact identifier, normally a phone number. </param>
        /// <param name="friendlyName"> A human readable description of this resource </param>
        /// <param name="participantType"> The Type of this Participant </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Participant </returns> 
        public static ParticipantResource Create(string pathServiceSid, string pathSessionSid, string identifier, string friendlyName = null, ParticipantResource.ParticipantTypeEnum participantType = null, ITwilioRestClient client = null)
        {
            var options = new CreateParticipantOptions(pathServiceSid, pathSessionSid, identifier){FriendlyName = friendlyName, ParticipantType = participantType};
            return Create(options, client);
        }

        #if !NET35
        /// <summary>
        /// Create a new Participant in this Session.
        /// </summary>
        ///
        /// <param name="pathServiceSid"> Service Sid. </param>
        /// <param name="pathSessionSid"> Session Sid. </param>
        /// <param name="identifier"> The Participant's contact identifier, normally a phone number. </param>
        /// <param name="friendlyName"> A human readable description of this resource </param>
        /// <param name="participantType"> The Type of this Participant </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Participant </returns> 
        public static async System.Threading.Tasks.Task<ParticipantResource> CreateAsync(string pathServiceSid, string pathSessionSid, string identifier, string friendlyName = null, ParticipantResource.ParticipantTypeEnum participantType = null, ITwilioRestClient client = null)
        {
            var options = new CreateParticipantOptions(pathServiceSid, pathSessionSid, identifier){FriendlyName = friendlyName, ParticipantType = participantType};
            return await CreateAsync(options, client);
        }
        #endif

        private static Request BuildDeleteRequest(DeleteParticipantOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Delete,
                Rest.Domain.Preview,
                "/Proxy/Services/" + options.PathServiceSid + "/Sessions/" + options.PathSessionSid + "/Participants/" + options.PathSid + "",
                client.Region,
                queryParams: options.GetParams()
            );
        }

        /// <summary>
        /// Delete a specific Participant.
        /// </summary>
        ///
        /// <param name="options"> Delete Participant parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Participant </returns> 
        public static bool Delete(DeleteParticipantOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildDeleteRequest(options, client));
            return response.StatusCode == System.Net.HttpStatusCode.NoContent;
        }

        #if !NET35
        /// <summary>
        /// Delete a specific Participant.
        /// </summary>
        ///
        /// <param name="options"> Delete Participant parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Participant </returns> 
        public static async System.Threading.Tasks.Task<bool> DeleteAsync(DeleteParticipantOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildDeleteRequest(options, client));
            return response.StatusCode == System.Net.HttpStatusCode.NoContent;
        }
        #endif

        /// <summary>
        /// Delete a specific Participant.
        /// </summary>
        ///
        /// <param name="pathServiceSid"> Service Sid. </param>
        /// <param name="pathSessionSid"> Session Sid. </param>
        /// <param name="pathSid"> A string that uniquely identifies this Participant. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Participant </returns> 
        public static bool Delete(string pathServiceSid, string pathSessionSid, string pathSid, ITwilioRestClient client = null)
        {
            var options = new DeleteParticipantOptions(pathServiceSid, pathSessionSid, pathSid);
            return Delete(options, client);
        }

        #if !NET35
        /// <summary>
        /// Delete a specific Participant.
        /// </summary>
        ///
        /// <param name="pathServiceSid"> Service Sid. </param>
        /// <param name="pathSessionSid"> Session Sid. </param>
        /// <param name="pathSid"> A string that uniquely identifies this Participant. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Participant </returns> 
        public static async System.Threading.Tasks.Task<bool> DeleteAsync(string pathServiceSid, string pathSessionSid, string pathSid, ITwilioRestClient client = null)
        {
            var options = new DeleteParticipantOptions(pathServiceSid, pathSessionSid, pathSid);
            return await DeleteAsync(options, client);
        }
        #endif

        private static Request BuildUpdateRequest(UpdateParticipantOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Post,
                Rest.Domain.Preview,
                "/Proxy/Services/" + options.PathServiceSid + "/Sessions/" + options.PathSessionSid + "/Participants/" + options.PathSid + "",
                client.Region,
                postParams: options.GetParams()
            );
        }

        /// <summary>
        /// Update an s access to a specific Sync List.
        /// </summary>
        ///
        /// <param name="options"> Update Participant parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Participant </returns> 
        public static ParticipantResource Update(UpdateParticipantOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildUpdateRequest(options, client));
            return FromJson(response.Content);
        }

        #if !NET35
        /// <summary>
        /// Update an s access to a specific Sync List.
        /// </summary>
        ///
        /// <param name="options"> Update Participant parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Participant </returns> 
        public static async System.Threading.Tasks.Task<ParticipantResource> UpdateAsync(UpdateParticipantOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildUpdateRequest(options, client));
            return FromJson(response.Content);
        }
        #endif

        /// <summary>
        /// Update an s access to a specific Sync List.
        /// </summary>
        ///
        /// <param name="pathServiceSid"> Service Sid. </param>
        /// <param name="pathSessionSid"> Session Sid. </param>
        /// <param name="pathSid"> A string that uniquely identifies this Participant. </param>
        /// <param name="participantType"> The Type of this Participant </param>
        /// <param name="identifier"> The Participant's contact identifier, normally a phone number. </param>
        /// <param name="friendlyName"> A human readable description of this resource </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Participant </returns> 
        public static ParticipantResource Update(string pathServiceSid, string pathSessionSid, string pathSid, ParticipantResource.ParticipantTypeEnum participantType = null, string identifier = null, string friendlyName = null, ITwilioRestClient client = null)
        {
            var options = new UpdateParticipantOptions(pathServiceSid, pathSessionSid, pathSid){ParticipantType = participantType, Identifier = identifier, FriendlyName = friendlyName};
            return Update(options, client);
        }

        #if !NET35
        /// <summary>
        /// Update an s access to a specific Sync List.
        /// </summary>
        ///
        /// <param name="pathServiceSid"> Service Sid. </param>
        /// <param name="pathSessionSid"> Session Sid. </param>
        /// <param name="pathSid"> A string that uniquely identifies this Participant. </param>
        /// <param name="participantType"> The Type of this Participant </param>
        /// <param name="identifier"> The Participant's contact identifier, normally a phone number. </param>
        /// <param name="friendlyName"> A human readable description of this resource </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Participant </returns> 
        public static async System.Threading.Tasks.Task<ParticipantResource> UpdateAsync(string pathServiceSid, string pathSessionSid, string pathSid, ParticipantResource.ParticipantTypeEnum participantType = null, string identifier = null, string friendlyName = null, ITwilioRestClient client = null)
        {
            var options = new UpdateParticipantOptions(pathServiceSid, pathSessionSid, pathSid){ParticipantType = participantType, Identifier = identifier, FriendlyName = friendlyName};
            return await UpdateAsync(options, client);
        }
        #endif

        /// <summary>
        /// Converts a JSON string into a ParticipantResource object
        /// </summary>
        ///
        /// <param name="json"> Raw JSON string </param>
        /// <returns> ParticipantResource object represented by the provided JSON </returns> 
        public static ParticipantResource FromJson(string json)
        {
            // Convert all checked exceptions to Runtime
            try
            {
                return JsonConvert.DeserializeObject<ParticipantResource>(json);
            }
            catch (JsonException e)
            {
                throw new ApiException(e.Message, e);
            }
        }

        /// <summary>
        /// A string that uniquely identifies this Participant.
        /// </summary>
        [JsonProperty("sid")]
        public string Sid { get; private set; }
        /// <summary>
        /// Session Sid.
        /// </summary>
        [JsonProperty("session_sid")]
        public string SessionSid { get; private set; }
        /// <summary>
        /// Service Sid.
        /// </summary>
        [JsonProperty("service_sid")]
        public string ServiceSid { get; private set; }
        /// <summary>
        /// Account Sid.
        /// </summary>
        [JsonProperty("account_sid")]
        public string AccountSid { get; private set; }
        /// <summary>
        /// A human readable description of this resource
        /// </summary>
        [JsonProperty("friendly_name")]
        public string FriendlyName { get; private set; }
        /// <summary>
        /// The Type of this Participant
        /// </summary>
        [JsonProperty("participant_type")]
        [JsonConverter(typeof(StringEnumConverter))]
        public ParticipantResource.ParticipantTypeEnum ParticipantType { get; private set; }
        /// <summary>
        /// The Participant's contact identifier, normally a phone number.
        /// </summary>
        [JsonProperty("identifier")]
        public string Identifier { get; private set; }
        /// <summary>
        /// What this Participant communicates with, normally a phone number.
        /// </summary>
        [JsonProperty("proxy_identifier")]
        public string ProxyIdentifier { get; private set; }
        /// <summary>
        /// The date this Participant was created
        /// </summary>
        [JsonProperty("date_created")]
        public DateTime? DateCreated { get; private set; }
        /// <summary>
        /// The date this Participant was updated
        /// </summary>
        [JsonProperty("date_updated")]
        public DateTime? DateUpdated { get; private set; }
        /// <summary>
        /// The URL of this resource.
        /// </summary>
        [JsonProperty("url")]
        public Uri Url { get; private set; }
        /// <summary>
        /// Nested resource URLs.
        /// </summary>
        [JsonProperty("links")]
        public Dictionary<string, string> Links { get; private set; }

        private ParticipantResource()
        {

        }
    }

}