#pragma warning disable 0219
#pragma warning disable 0168
#pragma warning disable 0618
#pragma warning disable 0649
#pragma warning disable 0067
#pragma warning disable 0414

#pragma warning disable 0067
#pragma warning disable 0414

using System;

namespace PubNubAPI
{
    public class PNSignalEventResult
    {
        public object Payload { get; set;} 
        public string Subscription { get; set;} 
        public string Channel { get; set;} 
        public long Timetoken { get; set;} 
        public long OriginatingTimetoken { get; set;} 
        public object UserMetadata { get; set;} 
        public string IssuingClientId { get; set;} 

        public PNSignalEventResult(string subscribedChannel, string actualchannel, object payload,
            long timetoken, long originatingTimetoken, object userMetadata, string issuingClientId){
            this.Subscription = subscribedChannel;// change to channel group
            this.Channel = actualchannel; // change to channel
            this.Payload = payload;
            this.Timetoken = timetoken;
            this.OriginatingTimetoken = originatingTimetoken;
            this.UserMetadata = userMetadata;
            this.IssuingClientId = issuingClientId;
        }
    }   
}

