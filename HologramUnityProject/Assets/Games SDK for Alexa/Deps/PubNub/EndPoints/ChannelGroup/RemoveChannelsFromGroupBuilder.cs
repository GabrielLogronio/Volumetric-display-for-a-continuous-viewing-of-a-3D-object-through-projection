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
    public class RemoveChannelsFromGroupBuilder
    {     
        private readonly RemoveChannelsFromGroupRequestBuilder pubBuilder;
        public RemoveChannelsFromGroupBuilder Channels(List<string> channelNames){
            pubBuilder.Channels(channelNames);
            return this;
        }

        public RemoveChannelsFromGroupBuilder ChannelGroup(string channelGroupNames){
            pubBuilder.ChannelGroup(channelGroupNames);
            return this;
        }

        public RemoveChannelsFromGroupBuilder QueryParam(Dictionary<string, string> queryParam){
            pubBuilder.QueryParam(queryParam);
            return this;
        }

        public RemoveChannelsFromGroupBuilder(PubNubUnity pn){
            pubBuilder = new RemoveChannelsFromGroupRequestBuilder(pn);
        }

        public void Async(Action<PNChannelGroupsRemoveChannelResult, PNStatus> callback)
        {
            pubBuilder.Async(callback);
        }
    }
}
