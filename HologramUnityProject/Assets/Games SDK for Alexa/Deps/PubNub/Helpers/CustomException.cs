#pragma warning disable 0219
#pragma warning disable 0168
#pragma warning disable 0618
#pragma warning disable 0649
#pragma warning disable 0067
#pragma warning disable 0414

#pragma warning disable 0067
#pragma warning disable 0414

using System;

namespace PubNubAPI
{
    public class PubNubException : System.Exception
    {
        public PubNubException() { }
        public PubNubException(string message) : base(message) { }
        public PubNubException(string message, System.Exception inner) : base(message, inner) { }
    }
    public class PubNubUserException : System.Exception
    {
        public PubNubUserException() { }
        public PubNubUserException(string message) : base(message) { }
        public PubNubUserException(string message, System.Exception inner) : base(message, inner) { }
    }
}   