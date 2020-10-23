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
    public class GetAllChannelsForGroupBuilder
    {     
        private readonly GetAllChannelsForGroupRequestBuilder pubBuilder;
        
        public GetAllChannelsForGroupBuilder ChannelGroup(string channelGroupName){
            pubBuilder.ChannelGroup(channelGroupName);
            return this;
        }

        public GetAllChannelsForGroupBuilder QueryParam(Dictionary<string, string> queryParam){
            pubBuilder.QueryParam(queryParam);
            return this;
        }
        
        public GetAllChannelsForGroupBuilder(PubNubUnity pn){
            pubBuilder = new GetAllChannelsForGroupRequestBuilder(pn);
        }
        
        public void Async(Action<PNChannelGroupsAllChannelsResult, PNStatus> callback)
        {
            pubBuilder.Async(callback);
        }
    }
}