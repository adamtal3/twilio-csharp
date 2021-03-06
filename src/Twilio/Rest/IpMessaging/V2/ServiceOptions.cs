using System;
using System.Collections.Generic;
using System.Linq;
using Twilio.Base;

namespace Twilio.Rest.IpMessaging.V2 
{

    /// <summary>
    /// FetchServiceOptions
    /// </summary>
    public class FetchServiceOptions : IOptions<ServiceResource> 
    {
        /// <summary>
        /// The sid
        /// </summary>
        public string PathSid { get; }

        /// <summary>
        /// Construct a new FetchServiceOptions
        /// </summary>
        ///
        /// <param name="pathSid"> The sid </param>
        public FetchServiceOptions(string pathSid)
        {
            PathSid = pathSid;
        }

        /// <summary>
        /// Generate the necessary parameters
        /// </summary>
        public List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();
            return p;
        }
    }

    /// <summary>
    /// DeleteServiceOptions
    /// </summary>
    public class DeleteServiceOptions : IOptions<ServiceResource> 
    {
        /// <summary>
        /// The sid
        /// </summary>
        public string PathSid { get; }

        /// <summary>
        /// Construct a new DeleteServiceOptions
        /// </summary>
        ///
        /// <param name="pathSid"> The sid </param>
        public DeleteServiceOptions(string pathSid)
        {
            PathSid = pathSid;
        }

        /// <summary>
        /// Generate the necessary parameters
        /// </summary>
        public List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();
            return p;
        }
    }

    /// <summary>
    /// CreateServiceOptions
    /// </summary>
    public class CreateServiceOptions : IOptions<ServiceResource> 
    {
        /// <summary>
        /// The friendly_name
        /// </summary>
        public string FriendlyName { get; }

        /// <summary>
        /// Construct a new CreateServiceOptions
        /// </summary>
        ///
        /// <param name="friendlyName"> The friendly_name </param>
        public CreateServiceOptions(string friendlyName)
        {
            FriendlyName = friendlyName;
        }

        /// <summary>
        /// Generate the necessary parameters
        /// </summary>
        public List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();
            if (FriendlyName != null)
            {
                p.Add(new KeyValuePair<string, string>("FriendlyName", FriendlyName));
            }

            return p;
        }
    }

    /// <summary>
    /// ReadServiceOptions
    /// </summary>
    public class ReadServiceOptions : ReadOptions<ServiceResource> 
    {
        /// <summary>
        /// Generate the necessary parameters
        /// </summary>
        public override List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();
            if (PageSize != null)
            {
                p.Add(new KeyValuePair<string, string>("PageSize", PageSize.ToString()));
            }

            return p;
        }
    }

    /// <summary>
    /// UpdateServiceOptions
    /// </summary>
    public class UpdateServiceOptions : IOptions<ServiceResource> 
    {
        /// <summary>
        /// The sid
        /// </summary>
        public string PathSid { get; }
        /// <summary>
        /// The friendly_name
        /// </summary>
        public string FriendlyName { get; set; }
        /// <summary>
        /// The default_service_role_sid
        /// </summary>
        public string DefaultServiceRoleSid { get; set; }
        /// <summary>
        /// The default_channel_role_sid
        /// </summary>
        public string DefaultChannelRoleSid { get; set; }
        /// <summary>
        /// The default_channel_creator_role_sid
        /// </summary>
        public string DefaultChannelCreatorRoleSid { get; set; }
        /// <summary>
        /// The read_status_enabled
        /// </summary>
        public bool? ReadStatusEnabled { get; set; }
        /// <summary>
        /// The reachability_enabled
        /// </summary>
        public bool? ReachabilityEnabled { get; set; }
        /// <summary>
        /// The typing_indicator_timeout
        /// </summary>
        public int? TypingIndicatorTimeout { get; set; }
        /// <summary>
        /// The consumption_report_interval
        /// </summary>
        public int? ConsumptionReportInterval { get; set; }
        /// <summary>
        /// The notifications.new_message.enabled
        /// </summary>
        public bool? NotificationsNewMessageEnabled { get; set; }
        /// <summary>
        /// The notifications.new_message.template
        /// </summary>
        public string NotificationsNewMessageTemplate { get; set; }
        /// <summary>
        /// The notifications.new_message.sound
        /// </summary>
        public string NotificationsNewMessageSound { get; set; }
        /// <summary>
        /// The notifications.new_message.badge_count_enabled
        /// </summary>
        public bool? NotificationsNewMessageBadgeCountEnabled { get; set; }
        /// <summary>
        /// The notifications.added_to_channel.enabled
        /// </summary>
        public bool? NotificationsAddedToChannelEnabled { get; set; }
        /// <summary>
        /// The notifications.added_to_channel.template
        /// </summary>
        public string NotificationsAddedToChannelTemplate { get; set; }
        /// <summary>
        /// The notifications.added_to_channel.sound
        /// </summary>
        public string NotificationsAddedToChannelSound { get; set; }
        /// <summary>
        /// The notifications.removed_from_channel.enabled
        /// </summary>
        public bool? NotificationsRemovedFromChannelEnabled { get; set; }
        /// <summary>
        /// The notifications.removed_from_channel.template
        /// </summary>
        public string NotificationsRemovedFromChannelTemplate { get; set; }
        /// <summary>
        /// The notifications.removed_from_channel.sound
        /// </summary>
        public string NotificationsRemovedFromChannelSound { get; set; }
        /// <summary>
        /// The notifications.invited_to_channel.enabled
        /// </summary>
        public bool? NotificationsInvitedToChannelEnabled { get; set; }
        /// <summary>
        /// The notifications.invited_to_channel.template
        /// </summary>
        public string NotificationsInvitedToChannelTemplate { get; set; }
        /// <summary>
        /// The notifications.invited_to_channel.sound
        /// </summary>
        public string NotificationsInvitedToChannelSound { get; set; }
        /// <summary>
        /// The pre_webhook_url
        /// </summary>
        public Uri PreWebhookUrl { get; set; }
        /// <summary>
        /// The post_webhook_url
        /// </summary>
        public Uri PostWebhookUrl { get; set; }
        /// <summary>
        /// The webhook_method
        /// </summary>
        public Twilio.Http.HttpMethod WebhookMethod { get; set; }
        /// <summary>
        /// The webhook_filters
        /// </summary>
        public List<string> WebhookFilters { get; set; }
        /// <summary>
        /// The limits.channel_members
        /// </summary>
        public int? LimitsChannelMembers { get; set; }
        /// <summary>
        /// The limits.user_channels
        /// </summary>
        public int? LimitsUserChannels { get; set; }

        /// <summary>
        /// Construct a new UpdateServiceOptions
        /// </summary>
        ///
        /// <param name="pathSid"> The sid </param>
        public UpdateServiceOptions(string pathSid)
        {
            PathSid = pathSid;
            WebhookFilters = new List<string>();
        }

        /// <summary>
        /// Generate the necessary parameters
        /// </summary>
        public List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();
            if (FriendlyName != null)
            {
                p.Add(new KeyValuePair<string, string>("FriendlyName", FriendlyName));
            }

            if (DefaultServiceRoleSid != null)
            {
                p.Add(new KeyValuePair<string, string>("DefaultServiceRoleSid", DefaultServiceRoleSid.ToString()));
            }

            if (DefaultChannelRoleSid != null)
            {
                p.Add(new KeyValuePair<string, string>("DefaultChannelRoleSid", DefaultChannelRoleSid.ToString()));
            }

            if (DefaultChannelCreatorRoleSid != null)
            {
                p.Add(new KeyValuePair<string, string>("DefaultChannelCreatorRoleSid", DefaultChannelCreatorRoleSid.ToString()));
            }

            if (ReadStatusEnabled != null)
            {
                p.Add(new KeyValuePair<string, string>("ReadStatusEnabled", ReadStatusEnabled.Value.ToString()));
            }

            if (ReachabilityEnabled != null)
            {
                p.Add(new KeyValuePair<string, string>("ReachabilityEnabled", ReachabilityEnabled.Value.ToString()));
            }

            if (TypingIndicatorTimeout != null)
            {
                p.Add(new KeyValuePair<string, string>("TypingIndicatorTimeout", TypingIndicatorTimeout.Value.ToString()));
            }

            if (ConsumptionReportInterval != null)
            {
                p.Add(new KeyValuePair<string, string>("ConsumptionReportInterval", ConsumptionReportInterval.Value.ToString()));
            }

            if (NotificationsNewMessageEnabled != null)
            {
                p.Add(new KeyValuePair<string, string>("Notifications.NewMessage.Enabled", NotificationsNewMessageEnabled.Value.ToString()));
            }

            if (NotificationsNewMessageTemplate != null)
            {
                p.Add(new KeyValuePair<string, string>("Notifications.NewMessage.Template", NotificationsNewMessageTemplate));
            }

            if (NotificationsNewMessageSound != null)
            {
                p.Add(new KeyValuePair<string, string>("Notifications.NewMessage.Sound", NotificationsNewMessageSound));
            }

            if (NotificationsNewMessageBadgeCountEnabled != null)
            {
                p.Add(new KeyValuePair<string, string>("Notifications.NewMessage.BadgeCountEnabled", NotificationsNewMessageBadgeCountEnabled.Value.ToString()));
            }

            if (NotificationsAddedToChannelEnabled != null)
            {
                p.Add(new KeyValuePair<string, string>("Notifications.AddedToChannel.Enabled", NotificationsAddedToChannelEnabled.Value.ToString()));
            }

            if (NotificationsAddedToChannelTemplate != null)
            {
                p.Add(new KeyValuePair<string, string>("Notifications.AddedToChannel.Template", NotificationsAddedToChannelTemplate));
            }

            if (NotificationsAddedToChannelSound != null)
            {
                p.Add(new KeyValuePair<string, string>("Notifications.AddedToChannel.Sound", NotificationsAddedToChannelSound));
            }

            if (NotificationsRemovedFromChannelEnabled != null)
            {
                p.Add(new KeyValuePair<string, string>("Notifications.RemovedFromChannel.Enabled", NotificationsRemovedFromChannelEnabled.Value.ToString()));
            }

            if (NotificationsRemovedFromChannelTemplate != null)
            {
                p.Add(new KeyValuePair<string, string>("Notifications.RemovedFromChannel.Template", NotificationsRemovedFromChannelTemplate));
            }

            if (NotificationsRemovedFromChannelSound != null)
            {
                p.Add(new KeyValuePair<string, string>("Notifications.RemovedFromChannel.Sound", NotificationsRemovedFromChannelSound));
            }

            if (NotificationsInvitedToChannelEnabled != null)
            {
                p.Add(new KeyValuePair<string, string>("Notifications.InvitedToChannel.Enabled", NotificationsInvitedToChannelEnabled.Value.ToString()));
            }

            if (NotificationsInvitedToChannelTemplate != null)
            {
                p.Add(new KeyValuePair<string, string>("Notifications.InvitedToChannel.Template", NotificationsInvitedToChannelTemplate));
            }

            if (NotificationsInvitedToChannelSound != null)
            {
                p.Add(new KeyValuePair<string, string>("Notifications.InvitedToChannel.Sound", NotificationsInvitedToChannelSound));
            }

            if (PreWebhookUrl != null)
            {
                p.Add(new KeyValuePair<string, string>("PreWebhookUrl", PreWebhookUrl.ToString()));
            }

            if (PostWebhookUrl != null)
            {
                p.Add(new KeyValuePair<string, string>("PostWebhookUrl", PostWebhookUrl.ToString()));
            }

            if (WebhookMethod != null)
            {
                p.Add(new KeyValuePair<string, string>("WebhookMethod", WebhookMethod.ToString()));
            }

            if (WebhookFilters != null)
            {
                p.AddRange(WebhookFilters.Select(prop => new KeyValuePair<string, string>("WebhookFilters", prop)));
            }

            if (LimitsChannelMembers != null)
            {
                p.Add(new KeyValuePair<string, string>("Limits.ChannelMembers", LimitsChannelMembers.Value.ToString()));
            }

            if (LimitsUserChannels != null)
            {
                p.Add(new KeyValuePair<string, string>("Limits.UserChannels", LimitsUserChannels.Value.ToString()));
            }

            return p;
        }
    }

}