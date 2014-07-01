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

        public override ActionInstant Clone()
        {
            return new ActionToggleVisibility();
        }

        public override ActionInstant Reverse()
        {
            return new ActionToggleVisibility();
        }

        public override void Start()
        {
            base.Start();
            renderer.enabled = !renderer.enabled;
        }
    }
}