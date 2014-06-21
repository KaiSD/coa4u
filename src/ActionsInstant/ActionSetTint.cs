using System;
using System.Collections.Generic;
using UnityEngine;

namespace coa4u
{
    /// <summary>
    /// Instantly tints the target to the given color.
    /// </summary>
    class ActionSetTint : ActionInstant
    {
        public Vector4 color;
        protected const float coeff = 1F / 255F;

        public ActionSetTint(Vector4 tgtColor)
            : base()
        {
            color = tgtColor * coeff;
        }

        /// <summary>
        /// Returns a copy of the action.
        /// </summary>
        public override ActionInstant clone()
        {
            return new ActionSetTint(color * 255F);
        }

        /// <summary>
        /// This method is called at the action start.
        /// </summary>
        public override void start()
        {
            base.start();
            renderer.material.color = new Color(color[0], color[1], color[2], color[3]);
        }
    }
}