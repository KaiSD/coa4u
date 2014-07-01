using System;
using System.Collections.Generic;
using UnityEngine;

namespace coa4u
{
    /// <summary>
    /// Sends the message to the current target. First, it checks the Actor's methods cache.
    /// If the receiving method found in cache, it will be called directly without passing the message to the GameObject.
    /// If there's no listener in cache, message will be sent GameObject (and Unity does it VERY slow).
    /// </summary>
    class ActionSendMessage : ActionInstant
    {
        protected string message;
        protected object param;
        protected SendMessageOptions options = SendMessageOptions.DontRequireReceiver;

        public ActionSendMessage(string targetMessage)
            : base()
        {
            message = targetMessage;
        }

        public ActionSendMessage(string targetMessage, object targetParam)
            : base()
        {
            message = targetMessage;
            param = targetParam;
        }

        public ActionSendMessage(string targetMessage, object targetParam, SendMessageOptions targetOptions)
            : base()
        {
            message = targetMessage;
            param = targetParam;
            options = targetOptions;
        }

        public override ActionInstant Clone()
        {
            return new ActionSendMessage(message, param, options);
        }

        public override ActionInstant Reverse()
        {
            return new ActionSendMessage(message, param, options);
        }

        public override void Start()
        {
            base.Start();
            if (param != null)
            {
                target.ReceiveMessage(message, param, options);
            }
            else
            {
                target.ReceiveMessage(message, options);
            }
        }
    }
}