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
    public class DeleteUserBuilder
    {     
        private readonly DeleteUserRequestBuilder deleteUserBuilder;
        
        public DeleteUserBuilder(PubNubUnity pn){
            deleteUserBuilder = new DeleteUserRequestBuilder(pn);
        }

        public DeleteUserBuilder ID(string id){
            deleteUserBuilder.ID(id);
            return this;
        }

        public DeleteUserBuilder QueryParam(Dictionary<string, string> queryParam){
            deleteUserBuilder.QueryParam(queryParam);
            return this;
        }

        public void Async(Action<PNDeleteUserResult, PNStatus> callback)
        {
            deleteUserBuilder.Async(callback);
        }
    }
}