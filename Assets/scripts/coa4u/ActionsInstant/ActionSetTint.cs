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

        public ActionSetTint(Vector4 targetColor)
            : base()
        {
            color = targetColor * coeff;
        }

        public override ActionInstant Clone()
        {
            return new ActionSetTint(color * 255F);
        }

        public override void Start()
        {
            base.Start();
            renderer.material.color = new Color(color[0], color[1], color[2], color[3]);
        }
    }
}