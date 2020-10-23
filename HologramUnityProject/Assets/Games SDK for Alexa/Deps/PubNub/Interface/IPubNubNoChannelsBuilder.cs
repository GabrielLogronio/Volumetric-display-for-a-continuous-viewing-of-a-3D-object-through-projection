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
    internal interface IPubNubNonSubscribeBuilder<U, V>
    {
        void Async(Action<V, PNStatus> callback);

    }
}

