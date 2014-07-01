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

        public ActionLog(string targetMessage)
            : base()
        {
            message = targetMessage;
        }

        public override ActionInstant Clone()
        {
            return new ActionLog(message);
        }

        /// <summary>
        /// Returns the reversed version of the action, if it is possible.
        /// </summary>
        public override ActionInstant Reverse()
        {
            return new ActionLog(message);
        }

        public override void Start()
        {
            base.Start();
            Debug.Log(message);
        }
    }
}