using System;
using System.Collections.Generic;
using UnityEngine;

namespace coa4u
{
    /// <summary>
    /// Instantly shows the hidden target. This action does not require the transparency support in shaders.
    /// </summary>
    class ActionShow : ActionInstant
    {

        public ActionShow()
            : base()
        {
        }

        /// <summary>
        /// Returns a copy of the action.
        /// </summary>
        public override ActionInstant clone()
        {
            return new ActionShow();
        }

        /// <summary>
        /// Returns the reversed version of the action, if it is possible.
        /// </summary>
        public override ActionInstant reverse()
        {
            return new ActionHide();
        }

        /// <summary>
        /// This method is called at the action start.
        /// </summary>
        public override void start()
        {
            base.start();
            renderer.enabled = true;
        }
    }
}