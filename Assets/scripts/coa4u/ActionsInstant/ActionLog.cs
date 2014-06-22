using System;
using System.Collections.Generic;
using UnityEngine;

namespace coa4u
{
    /// <summary>
    /// Prints a message in Unity debug console.
    /// </summary>
    class ActionLog : ActionInstant
    {
        string message;

        public ActionLog(string tgtMessage)
            : base()
        {
            message = tgtMessage;
        }

        /// <summary>
        /// Returns a copy of the action.
        /// </summary>
        public override ActionInstant clone()
        {
            return new ActionLog(message);
        }

        /// <summary>
        /// Returns the reversed version of the action, if it is possible.
        /// </summary>
        public override ActionInstant reverse()
        {
            return new ActionLog(message);
        }

        /// <summary>
        /// This method is called at the action start.
        /// </summary>
        public override void start()
        {
            base.start();
            Debug.Log(message);
        }
    }
}