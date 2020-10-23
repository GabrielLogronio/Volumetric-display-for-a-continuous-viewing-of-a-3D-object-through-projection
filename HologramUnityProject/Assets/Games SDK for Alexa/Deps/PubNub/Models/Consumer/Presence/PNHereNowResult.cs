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
    public class PNHereNowResult: PNResult
    {
        public int TotalChannels  { get; set;}
        public int TotalOccupancy  { get; set;}
        public Dictionary<string, PNHereNowChannelData> Channels { get; set;}
    }

    public class PNHereNowChannelData {
        public string ChannelName {get; set;}
        public int Occupancy {get; set;}
        public List<PNHereNowOccupantData> Occupants {get; set;}
    }

    public class PNHereNowOccupantData {
        public string UUID {get; set;}
        public object State {get; set;}

    }

}