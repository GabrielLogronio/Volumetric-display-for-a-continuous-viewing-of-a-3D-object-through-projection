#pragma warning disable 0219
#pragma warning disable 0168
#pragma warning disable 0618
#pragma warning disable 0649
#pragma warning disable 0067
#pragma warning disable 0414

#pragma warning disable 0067
#pragma warning disable 0414

using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

namespace PubNubAPI
{
    public class RemoveChannelsFromPushBuilder
    {     
        private readonly RemoveChannelsFromPushRequestBuilder pubBuilder;
        
        public RemoveChannelsFromPushBuilder Channels(List<string> channelNames){
            pubBuilder.Channels(channelNames);
            return this;
        }

        public RemoveChannelsFromPushBuilder DeviceID (string deviceIdForPush){ 
            pubBuilder.DeviceId(deviceIdForPush);
            return this;
        }

        public RemoveChannelsFromPushBuilder PushType(PNPushType pnPushType) {
            pubBuilder.PushType = pnPushType;
            return this;
        }
        public RemoveChannelsFromPushBuilder QueryParam(Dictionary<string, string> queryParam){
            pubBuilder.QueryParam(queryParam);
            return this;
        }
        public RemoveChannelsFromPushBuilder(PubNubUnity pn){
            pubBuilder = new RemoveChannelsFromPushRequestBuilder(pn);
        }
        
        public void Async(Action<PNPushRemoveChannelResult, PNStatus> callback)
        {
            pubBuilder.Async(callback);
        }
    }
}
