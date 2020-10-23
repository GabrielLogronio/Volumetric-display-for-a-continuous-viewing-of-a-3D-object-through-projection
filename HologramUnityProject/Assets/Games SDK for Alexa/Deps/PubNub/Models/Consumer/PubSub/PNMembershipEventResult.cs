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
    public class PNMembershipEventResult
    {
        public PNObjectsEvent ObjectsEvent { get; set;} 
        public string SpaceID { get; set;}
        public string UserID { get; set;}
        public string Description { get; set;}
        public Dictionary<string, object> Custom { get; set;}
        public string Subscription { get; set;} 
        public string Channel { get; set;} 
        public string Timestamp { get; set;} 
    }
}