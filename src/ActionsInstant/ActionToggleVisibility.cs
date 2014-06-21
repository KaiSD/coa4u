using System;
using System.Collections.Generic;
using UnityEngine;

namespace coa4u
{
    /// <summary>
    /// Instantly hides the target or showes it, if it's hidden. This action does not require the transparency support in shaders.
    /// </summary>
    class ActionToggleVisibility : ActionInstant
    {

        public ActionToggleVisibility()
            : base()
        {
        }

        /// <summary>
        /// Returns a copy of the action.
        /// </summary>
        public override ActionInstant clone()
        {
            return new ActionToggleVisibility();
        }

        /// <summary>
        /// Returns the reversed version of the action, if it is possible.
        /// </summary>
        public override ActionInstant reverse()
        {
            return new ActionToggleVisibility();
        }

        /// <summary>
        /// This method is called at the action start.
        /// </summary>
        public override void start()
        {
            base.start();
            renderer.enabled = !renderer.enabled;
        }
    }
}