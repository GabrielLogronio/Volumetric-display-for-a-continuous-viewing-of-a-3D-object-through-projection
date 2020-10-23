#pragma warning disable 0219
#pragma warning disable 0168
#pragma warning disable 0618
#pragma warning disable 0649
#pragma warning disable 0067
#pragma warning disable 0414

#pragma warning disable 0067
#pragma warning disable 0414

using System;

using System.Collections.Generic;
using UnityEngine;

namespace PubNubAPI
{
    public class GetChannelGroupsRequestBuilder: PubNubNonSubBuilder<GetChannelGroupsRequestBuilder, PNChannelGroupsListAllResult>, IPubNubNonSubscribeBuilder<GetChannelGroupsRequestBuilder, PNChannelGroupsListAllResult>
    {      
        public GetChannelGroupsRequestBuilder(PubNubUnity pn):base(pn, PNOperationType.PNChannelGroupsOperation){

        }
        
        #region IPubNubBuilder implementation

        public void Async(Action<PNChannelGroupsListAllResult, PNStatus> callback)
        {
            this.Callback = callback;
            base.Async(this);
        }
        #endregion

        protected override void RunWebRequest(QueueManager qm){
            RequestState requestState = new RequestState ();
            requestState.OperationType = OperationType;
            
        }

        //Removed
        protected override void CreatePubNubResponse(object deSerializedResult, RequestState requestState){
            throw new NotImplementedException();
        }
        
    }
}
