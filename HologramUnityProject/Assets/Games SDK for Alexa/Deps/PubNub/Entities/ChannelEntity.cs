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
    public class ChannelEntity
    {
        public ChannelIdentity ChannelID {get; set;}
        public ChannelParameters ChannelParams {get; set;}
        public ChannelEntity(ChannelIdentity channelID, ChannelParameters channelParams){
            this.ChannelID = channelID;
            this.ChannelParams = channelParams;
        }
    }
}

