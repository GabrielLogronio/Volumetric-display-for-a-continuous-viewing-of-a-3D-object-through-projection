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
    public struct ChannelIdentity
    {
        public string ChannelOrChannelGroupName {get; set;}
        public bool IsChannelGroup {get; set;}
        public bool IsPresenceChannel {get; set;}

        public ChannelIdentity(string channelOrChannelGroupName, bool isChannelGroup, bool isPresenceChannel){
            ChannelOrChannelGroupName = channelOrChannelGroupName;
            IsChannelGroup = isChannelGroup;
            IsPresenceChannel = isPresenceChannel;
        }
    }
}

