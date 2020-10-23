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
    internal class QueueStorage
    {
        internal object Callback { get; set;}
        internal PNOperationType OperationType { get; set;} 
        internal object OperationParams { get; set;}
        internal PubNubUnity PubNubInstance { get; set;}

        public QueueStorage (object callback, PNOperationType operationType, object operationParams, PubNubUnity pn)
        {
            this.Callback = callback;
            this.OperationType = operationType;
            this.OperationParams = operationParams;
            this.PubNubInstance = pn;

        }
    }
}

