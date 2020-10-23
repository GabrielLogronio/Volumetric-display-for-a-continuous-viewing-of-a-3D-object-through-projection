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
    public class HereNowBuilder
    {     
        private readonly HereNowRequestBuilder pubBuilder;
        
        public HereNowBuilder(PubNubUnity pn){
            pubBuilder = new HereNowRequestBuilder(pn);
        }
        
        public HereNowBuilder IncludeUUIDs(bool includeUUIDInHereNow){
            pubBuilder.IncludeUUIDs(includeUUIDInHereNow);
            return this;
        }

        public HereNowBuilder IncludeState(bool includeStateInHereNow){
            pubBuilder.IncludeState(includeStateInHereNow);
            return this;
        }

        public HereNowBuilder Channels(List<string> channelNames){
            pubBuilder.Channels(channelNames);
            return this;
        }

        public HereNowBuilder ChannelGroups(List<string> channelGroupNames){
            pubBuilder.ChannelGroups(channelGroupNames);
            return this;
        }

        public HereNowBuilder QueryParam(Dictionary<string, string> queryParam){
            pubBuilder.QueryParam(queryParam);
            return this;
        }

        public void Async(Action<PNHereNowResult, PNStatus> callback)
        {
            pubBuilder.Async(callback);
        }
    }
}