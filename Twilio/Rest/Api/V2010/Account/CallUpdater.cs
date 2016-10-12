using System;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;

#if NET40
using System.Threading.Tasks;
#endif

namespace Twilio.Rest.Api.V2010.Account {

    public class CallUpdater : Updater<CallResource> {
        private string accountSid;
        private string sid;
        private Uri url;
        private Twilio.Http.HttpMethod method;
        private CallResource.Status status;
        private Uri fallbackUrl;
        private Twilio.Http.HttpMethod fallbackMethod;
        private Uri statusCallback;
        private Twilio.Http.HttpMethod statusCallbackMethod;
    
        /// <summary>
        /// Construct a new CallUpdater.
        /// </summary>
        ///
        /// <param name="sid"> Call Sid that uniquely identifies the Call to update </param>
        public CallUpdater(string sid) {
            this.sid = sid;
        }
    
        /// <summary>
        /// Construct a new CallUpdater
        /// </summary>
        ///
        /// <param name="accountSid"> The account_sid </param>
        /// <param name="sid"> Call Sid that uniquely identifies the Call to update </param>
        public CallUpdater(string accountSid, string sid) {
            this.accountSid = accountSid;
            this.sid = sid;
        }
    
        /// <summary>
        /// A valid URL that returns TwiML. Twilio will immediately redirect the call to the new TwiML upon execution.
        /// </summary>
        ///
        /// <param name="url"> URL that returns TwiML </param>
        /// <returns> this </returns> 
        public CallUpdater setUrl(Uri url) {
            this.url = url;
            return this;
        }
    
        /// <summary>
        /// A valid URL that returns TwiML. Twilio will immediately redirect the call to the new TwiML upon execution.
        /// </summary>
        ///
        /// <param name="url"> URL that returns TwiML </param>
        /// <returns> this </returns> 
        public CallUpdater setUrl(string url) {
            return setUrl(Promoter.UriFromString(url));
        }
    
        /// <summary>
        /// The HTTP method Twilio should use when requesting the URL. Defaults to `POST`.
        /// </summary>
        ///
        /// <param name="method"> HTTP method to use to fetch TwiML </param>
        /// <returns> this </returns> 
        public CallUpdater setMethod(Twilio.Http.HttpMethod method) {
            this.method = method;
            return this;
        }
    
        /// <summary>
        /// Either `canceled` or `completed`. Specifying `canceled` will attempt to hangup calls that are queued or ringing but
        /// not affect calls already in progress. Specifying `completed` will attempt to hang up a call even if it's already in
        /// progress.
        /// </summary>
        ///
        /// <param name="status"> Status to update the Call with </param>
        /// <returns> this </returns> 
        public CallUpdater setStatus(CallResource.Status status) {
            this.status = status;
            return this;
        }
    
        /// <summary>
        /// A URL that Twilio will request if an error occurs requesting or executing the TwiML at `Url`.
        /// </summary>
        ///
        /// <param name="fallbackUrl"> Fallback URL in case of error </param>
        /// <returns> this </returns> 
        public CallUpdater setFallbackUrl(Uri fallbackUrl) {
            this.fallbackUrl = fallbackUrl;
            return this;
        }
    
        /// <summary>
        /// A URL that Twilio will request if an error occurs requesting or executing the TwiML at `Url`.
        /// </summary>
        ///
        /// <param name="fallbackUrl"> Fallback URL in case of error </param>
        /// <returns> this </returns> 
        public CallUpdater setFallbackUrl(string fallbackUrl) {
            return setFallbackUrl(Promoter.UriFromString(fallbackUrl));
        }
    
        /// <summary>
        /// The HTTP method that Twilio should use to request the `FallbackUrl`. Must be either `GET` or `POST`. Defaults to
        /// `POST`.
        /// </summary>
        ///
        /// <param name="fallbackMethod"> HTTP Method to use with FallbackUrl </param>
        /// <returns> this </returns> 
        public CallUpdater setFallbackMethod(Twilio.Http.HttpMethod fallbackMethod) {
            this.fallbackMethod = fallbackMethod;
            return this;
        }
    
        /// <summary>
        /// A URL that Twilio will request when the call ends to notify your app.
        /// </summary>
        ///
        /// <param name="statusCallback"> Status Callback URL </param>
        /// <returns> this </returns> 
        public CallUpdater setStatusCallback(Uri statusCallback) {
            this.statusCallback = statusCallback;
            return this;
        }
    
        /// <summary>
        /// A URL that Twilio will request when the call ends to notify your app.
        /// </summary>
        ///
        /// <param name="statusCallback"> Status Callback URL </param>
        /// <returns> this </returns> 
        public CallUpdater setStatusCallback(string statusCallback) {
            return setStatusCallback(Promoter.UriFromString(statusCallback));
        }
    
        /// <summary>
        /// The HTTP method that Twilio should use to request the `StatusCallback`. Defaults to `POST`.
        /// </summary>
        ///
        /// <param name="statusCallbackMethod"> HTTP Method to use with StatusCallback </param>
        /// <returns> this </returns> 
        public CallUpdater setStatusCallbackMethod(Twilio.Http.HttpMethod statusCallbackMethod) {
            this.statusCallbackMethod = statusCallbackMethod;
            return this;
        }
    
        #if NET40
        /// <summary>
        /// Make the request to the Twilio API to perform the update
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> Updated CallResource </returns> 
        public override async Task<CallResource> UpdateAsync(ITwilioRestClient client) {
            var request = new Request(
                Twilio.Http.HttpMethod.POST,
                Domains.API,
                "/2010-04-01/Accounts/" + (accountSid ?? client.GetAccountSid()) + "/Calls/" + this.sid + ".json"
            );
            addPostParams(request);
            
            var response = await client.RequestAsync(request);
            if (response == null)
            {
                throw new ApiConnectionException("CallResource update failed: Unable to connect to server");
            }
            
            if (response.StatusCode < System.Net.HttpStatusCode.OK || response.StatusCode > System.Net.HttpStatusCode.NoContent)
            {
                var restException = RestException.FromJson(response.Content);
                if (restException == null)
                {
                    throw new ApiException("Server Error, no content");
                }
            
                throw new ApiException(
                    restException.Code,
                    (int)response.StatusCode,
                    restException.Message ?? "Unable to update record, " + response.StatusCode,
                    restException.MoreInfo
                );
            }
            
            return CallResource.FromJson(response.Content);
        }
        #endif
    
        /// <summary>
        /// Make the request to the Twilio API to perform the update
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> Updated CallResource </returns> 
        public override CallResource Update(ITwilioRestClient client) {
            var request = new Request(
                Twilio.Http.HttpMethod.POST,
                Domains.API,
                "/2010-04-01/Accounts/" + (accountSid ?? client.GetAccountSid()) + "/Calls/" + this.sid + ".json"
            );
            addPostParams(request);
            
            var response = client.Request(request);
            if (response == null)
            {
                throw new ApiConnectionException("CallResource update failed: Unable to connect to server");
            }
            
            if (response.StatusCode < System.Net.HttpStatusCode.OK || response.StatusCode > System.Net.HttpStatusCode.NoContent)
            {
                var restException = RestException.FromJson(response.Content);
                if (restException == null)
                {
                    throw new ApiException("Server Error, no content");
                }
            
                throw new ApiException(
                    restException.Code,
                    (int)response.StatusCode,
                    restException.Message ?? "Unable to update record, " + response.StatusCode,
                    restException.MoreInfo
                );
            }
            
            return CallResource.FromJson(response.Content);
        }
    
        /// <summary>
        /// Add the requested post parameters to the Request
        /// </summary>
        ///
        /// <param name="request"> Request to add post params to </param>
        private void addPostParams(Request request) {
            if (url != null) {
                request.AddPostParam("Url", url.ToString());
            }
            
            if (method != null) {
                request.AddPostParam("Method", method.ToString());
            }
            
            if (status != null) {
                request.AddPostParam("Status", status.ToString());
            }
            
            if (fallbackUrl != null) {
                request.AddPostParam("FallbackUrl", fallbackUrl.ToString());
            }
            
            if (fallbackMethod != null) {
                request.AddPostParam("FallbackMethod", fallbackMethod.ToString());
            }
            
            if (statusCallback != null) {
                request.AddPostParam("StatusCallback", statusCallback.ToString());
            }
            
            if (statusCallbackMethod != null) {
                request.AddPostParam("StatusCallbackMethod", statusCallbackMethod.ToString());
            }
        }
    }
}