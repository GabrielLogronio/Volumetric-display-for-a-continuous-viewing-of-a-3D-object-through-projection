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
    public class GetUsersBuilder
    {     
        private readonly GetUsersRequestBuilder getUsersBuilder;
        
        public GetUsersBuilder(PubNubUnity pn){
            getUsersBuilder = new GetUsersRequestBuilder(pn);
        }
        public GetUsersBuilder Include(PNUserSpaceInclude[] include){
            getUsersBuilder.Include(include);
            return this;
        }

        public GetUsersBuilder Limit(int limit){
            getUsersBuilder.Limit(limit);
            return this;
        }

        public GetUsersBuilder Start(string start){
            getUsersBuilder.Start(start);
            return this;
        }
        public GetUsersBuilder End(string end){
            getUsersBuilder.End(end);
            return this;
        }
        public GetUsersBuilder Count(bool count){
            getUsersBuilder.Count(count);
            return this;
        }
        public GetUsersBuilder QueryParam(Dictionary<string, string> queryParam){
            getUsersBuilder.QueryParam(queryParam);
            return this;
        }

        public void Async(Action<PNGetUsersResult, PNStatus> callback)
        {
            getUsersBuilder.Async(callback);
        }
    }
}