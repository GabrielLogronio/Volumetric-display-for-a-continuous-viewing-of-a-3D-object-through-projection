#pragma warning disable 0219
#pragma warning disable 0168
#pragma warning disable 0618
#pragma warning disable 0649
#pragma warning disable 0067
#pragma warning disable 0414

#pragma warning disable 0067
#pragma warning disable 0414

﻿using System;
using System.Collections.Generic;

namespace PubNubAPI
{
    public class SubscribeEnvelope
    {
        private List<SubscribeMessage> m { get; set;} //JSON messages;
        private TimetokenMetadata t { get; set;} //JSON subscribeMetadata;

        public List<SubscribeMessage> Messages{
            get{
                return m;
            }
            set {
                m = value;
            }
        }

        public TimetokenMetadata TimetokenMeta{
            get{
                return t;
            }
            set {
                t = value;
            }
        }
    }
}

