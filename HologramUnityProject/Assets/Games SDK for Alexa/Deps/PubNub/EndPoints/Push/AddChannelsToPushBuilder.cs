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
    public class AddChannelsToPushBuilder
    {     
        private readonly AddChannelsToPushRequestBuilder pubBuilder;
        
        public AddChannelsToPushBuilder Channels(List<string> channelNames){
            pubBuilder.Channels(channelNames);
            return this;
        }
        
        public AddChannelsToPushBuilder DeviceID (string deviceIdForPush){ 
            pubBuilder.DeviceId(deviceIdForPush);
            return this;
        }
        public AddChannelsToPushBuilder QueryParam(Dictionary<string, string> queryParam){
            pubBuilder.QueryParam(queryParam);
            return this;
        }

        public AddChannelsToPushBuilder PushType(PNPushType pnPushType) {
            pubBuilder.PushType = pnPushType;
            return this;
        }

        public AddChannelsToPushBuilder(PubNubUnity pn){
            pubBuilder = new AddChannelsToPushRequestBuilder(pn);
        }
        public void Async(Action<PNPushAddChannelResult, PNStatus> callback)
        {
            pubBuilder.Async(callback);
        }
    }
}
