using Twilio.Base;
using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Rest.Taskrouter.V1.Workspace 
{

    public class TaskCreator : Creator<TaskResource> 
    {
        public string WorkspaceSid { get; }
        public string Attributes { get; }
        public string WorkflowSid { get; }
        public int? Timeout { get; set; }
        public int? Priority { get; set; }
        public string TaskChannel { get; set; }
    
        /// <summary>
        /// Construct a new TaskCreator
        /// </summary>
        ///
        /// <param name="workspaceSid"> The workspace_sid </param>
        /// <param name="attributes"> The attributes </param>
        /// <param name="workflowSid"> The workflow_sid </param>
        public TaskCreator(string workspaceSid, string attributes, string workflowSid)
        {
            WorkspaceSid = workspaceSid;
            Attributes = attributes;
            WorkflowSid = workflowSid;
        }
    
        #if NET40
        /// <summary>
        /// Make the request to the Twilio API to perform the create
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> Created TaskResource </returns> 
        public override async System.Threading.Tasks.Task<TaskResource> CreateAsync(ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.Post,
                Rest.Domain.Taskrouter,
                "/v1/Workspaces/" + WorkspaceSid + "/Tasks",
                client.Region
            );
            
            AddPostParams(request);
            var response = await client.RequestAsync(request);
            if (response == null)
            {
                throw new ApiConnectionException("TaskResource creation failed: Unable to connect to server");
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
                    restException.Message ?? "Unable to create record, " + response.StatusCode,
                    restException.MoreInfo
                );
            }
            
            return TaskResource.FromJson(response.Content);
        }
        #endif
    
        /// <summary>
        /// Make the request to the Twilio API to perform the create
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> Created TaskResource </returns> 
        public override TaskResource Create(ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.Post,
                Rest.Domain.Taskrouter,
                "/v1/Workspaces/" + WorkspaceSid + "/Tasks",
                client.Region
            );
            
            AddPostParams(request);
            var response = client.Request(request);
            if (response == null)
            {
                throw new ApiConnectionException("TaskResource creation failed: Unable to connect to server");
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
                    restException.Message ?? "Unable to create record, " + response.StatusCode,
                    restException.MoreInfo
                );
            }
            
            return TaskResource.FromJson(response.Content);
        }
    
        /// <summary>
        /// Add the requested post parameters to the Request
        /// </summary>
        ///
        /// <param name="request"> Request to add post params to </param>
        private void AddPostParams(Request request)
        {
            if (Attributes != null)
            {
                request.AddPostParam("Attributes", Attributes);
            }
            
            if (WorkflowSid != null)
            {
                request.AddPostParam("WorkflowSid", WorkflowSid);
            }
            
            if (Timeout != null)
            {
                request.AddPostParam("Timeout", Timeout.ToString());
            }
            
            if (Priority != null)
            {
                request.AddPostParam("Priority", Priority.ToString());
            }
            
            if (TaskChannel != null)
            {
                request.AddPostParam("TaskChannel", TaskChannel);
            }
        }
    }
}