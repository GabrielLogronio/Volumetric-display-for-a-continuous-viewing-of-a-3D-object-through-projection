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
    public class CustomEventArgs : EventArgs
    {
        public string Message {get; set;}
        public RequestState PubNubRequestState {get; set;}
        public bool IsError {get; set;}
        public bool IsTimeout {get; set;}
        public PNCurrentRequestType CurrRequestType {get; set;}
    }

    internal class CurrentRequestTypeEventArgs : EventArgs
    {
        internal UnityWebRequestWrapper WebRequestWrapper {get; set;}
        internal bool IsTimeout {get; set;}
    }

}

