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
    public class TimeBuilder
    {     
        private readonly TimeRequestBuilder pubBuilder;
        
        public TimeBuilder(PubNubUnity pn){
            pubBuilder = new TimeRequestBuilder(pn);
        }

        public TimeBuilder QueryParam(Dictionary<string, string> queryParam){
            pubBuilder.QueryParam(queryParam);
            return this;
        }

        public void Async(Action<PNTimeResult, PNStatus> callback)
        {
            pubBuilder.Async(callback);
        }
    }
}