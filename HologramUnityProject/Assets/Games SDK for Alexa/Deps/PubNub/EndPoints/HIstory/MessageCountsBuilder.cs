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
    public class MessageCountsBuilder
    {     
        private readonly MessageCountsRequestBuilder pubBuilder;
        
        public MessageCountsBuilder Channels(List<string> channelNames){
            pubBuilder.Channels(channelNames);
            return this;
        }

        public MessageCountsBuilder ChannelsTimetoken(List<long> channelsTimetoken){
            pubBuilder.ChannelsTimetoken(channelsTimetoken);
            return this;
        }

        [Obsolete("Use ChannelsTimetoken instead, pass one value in ChannelsTimetoken to achieve the same results.")]    
        public MessageCountsBuilder Timetoken(string timetoken){
            pubBuilder.Timetoken(timetoken);
            return this;
        }

        public MessageCountsBuilder QueryParam(Dictionary<string, string> queryParam){
            pubBuilder.QueryParam(queryParam);
            return this;
        }

        public MessageCountsBuilder(PubNubUnity pn){
            pubBuilder = new MessageCountsRequestBuilder(pn);

        }

        public void Async(Action<PNMessageCountsResult, PNStatus> callback)
        {
            pubBuilder.Async(callback);
        }
    }
}
