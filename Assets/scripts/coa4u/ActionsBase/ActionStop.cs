using System;
using System.Collections.Generic;
using UnityEngine;

namespace coa4u
{
    /// <summary>
    /// This action stops all actions for the current target.
    /// </summary>
    class ActionStop : ActionInstant
    {
        public ActionStop()
            : base()
        {
        }

        /// <summary>
        /// Returns a copy of the action.
        /// </summary>
        public override ActionInstant clone()
        {
            return new ActionStop();
        }

        /// <summary>
        /// This method is called at the action start.
        /// </summary>
        public override void start()
        {
            base.start();
            target.StopAction();
        }
    }
}