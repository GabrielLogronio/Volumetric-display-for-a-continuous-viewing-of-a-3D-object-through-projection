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
    public class GetStateBuilder
    {     
        private readonly GetStateRequestBuilder pubBuilder;
        
        public GetStateBuilder(PubNubUnity pn){
            pubBuilder = new GetStateRequestBuilder(pn);

        }
        
        public GetStateBuilder UUID(string uuidForState){
            pubBuilder.UUID(uuidForState);
            return this;
        }

        public GetStateBuilder Channels(List<string> channelNames){
            pubBuilder.Channels(channelNames);
            return this;
        }

        public GetStateBuilder ChannelGroups(List<string> channelGroupNames){
            pubBuilder.ChannelGroups(channelGroupNames);
            return this;
        }

        public GetStateBuilder QueryParam(Dictionary<string, string> queryParam){
            pubBuilder.QueryParam(queryParam);
            return this;
        }

        public void Async(Action<PNGetStateResult, PNStatus> callback)
        {
            pubBuilder.Async(callback);
        }
    }
}