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
    public class PNMembershipsResult
    {
        public List<PNMemberships> Data {get; set;}
        public int TotalCount {get; set;}
        public string Next {get; set;}
        public string Prev {get; set;}
    }

    public class PNMemberships
    {
        public string ID { get; set;}
        public PNSpaceResult Space { get; set;}
        public Dictionary<string, object> Custom { get; set;}
        public string Created { get; set;}
        public string Updated { get; set;}
        public string ETag { get; set;}
    }
}