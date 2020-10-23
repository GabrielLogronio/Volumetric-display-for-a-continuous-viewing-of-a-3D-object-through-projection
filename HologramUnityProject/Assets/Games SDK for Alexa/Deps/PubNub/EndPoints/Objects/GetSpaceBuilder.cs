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

namespace PubNubAPI
{
    public class GetSpaceBuilder
    {
        private readonly GetSpaceRequestBuilder getSpaceBuilder;

        public GetSpaceBuilder(PubNubUnity pn)
        {
            getSpaceBuilder = new GetSpaceRequestBuilder(pn);
        }
        public GetSpaceBuilder Include(PNUserSpaceInclude[] include)
        {
            getSpaceBuilder.Include(include);
            return this;
        }

        public GetSpaceBuilder ID(string id)
        {
            getSpaceBuilder.ID(id);
            return this;
        }

        public GetSpaceBuilder QueryParam(Dictionary<string, string> queryParam)
        {
            getSpaceBuilder.QueryParam(queryParam);
            return this;
        }

        public void Async(Action<PNSpaceResult, PNStatus> callback)
        {
            getSpaceBuilder.Async(callback);
        }
    }
}