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
    public class DeleteChannelGroupBuilder
    {     
        private readonly DeleteChannelGroupRequestBuilder pubBuilder;
        public DeleteChannelGroupBuilder ChannelGroup(string channelGroupName){
            pubBuilder.ChannelGroup(channelGroupName);
            return this;
        }

        public DeleteChannelGroupBuilder QueryParam(Dictionary<string, string> queryParam){
            pubBuilder.QueryParam(queryParam);
            return this;
        }
        
        public DeleteChannelGroupBuilder(PubNubUnity pn){
            pubBuilder = new DeleteChannelGroupRequestBuilder(pn);
        }
        
        public void Async(Action<PNChannelGroupsDeleteGroupResult, PNStatus> callback)
        {
            pubBuilder.Async(callback);
        }
    }
}