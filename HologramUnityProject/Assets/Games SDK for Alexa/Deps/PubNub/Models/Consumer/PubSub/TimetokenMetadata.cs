#pragma warning disable 0219
#pragma warning disable 0168
#pragma warning disable 0618
#pragma warning disable 0649
#pragma warning disable 0067
#pragma warning disable 0414

#pragma warning disable 0067
#pragma warning disable 0414

﻿using System;

namespace PubNubAPI
{
    public class TimetokenMetadata
    {
        private long t { get; set;} //JSON timetoken;
        private string r { get; set;} //JSON region;

        internal TimetokenMetadata(long timetoken, string region)
        {
            t = timetoken;
            r = region;
        }

        public long Timetoken { 
            get{
                return t;
            }
        }
        public string Region {
            get {
                return r;
            }
        }
    }
}

