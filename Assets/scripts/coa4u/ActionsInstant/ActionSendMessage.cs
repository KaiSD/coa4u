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

        public ActionSendMessage(string tgtMessage)
            : base()
        {
            message = tgtMessage;
        }

        public ActionSendMessage(string tgtMessage, object tgtParam)
            : base()
        {
            message = tgtMessage;
            param = tgtParam;
        }

        public ActionSendMessage(string tgtMessage, object tgtParam, SendMessageOptions tgtOptions)
            : base()
        {
            message = tgtMessage;
            param = tgtParam;
            options = tgtOptions;
        }

        /// <summary>
        /// Returns a copy of the action.
        /// </summary>
        public override ActionInstant clone()
        {
            return new ActionSendMessage(message, param, options);
        }

        /// <summary>
        /// Returns the reversed version of the action, if it is possible.
        /// </summary>
        public override ActionInstant reverse()
        {
            return new ActionSendMessage(message, param, options);
        }

        /// <summary>
        /// This method is called at the action start.
        /// </summary>
        public override void start()
        {
            base.start();
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