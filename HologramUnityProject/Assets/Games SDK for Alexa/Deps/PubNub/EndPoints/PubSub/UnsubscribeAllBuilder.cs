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
    public class UnsubscribeAllBuilder
    {     
        private readonly LeaveRequestBuilder pubBuilder;

        public UnsubscribeAllBuilder(PubNubUnity pn){
            pubBuilder = new LeaveRequestBuilder(pn);
        }
        public UnsubscribeAllBuilder QueryParam(Dictionary<string, string> queryParam){
            pubBuilder.QueryParam(queryParam);
            return this;
        }
        public void Async(Action<PNLeaveRequestResult, PNStatus> callback)
        {
            pubBuilder.Async(callback);
        }
    }
}