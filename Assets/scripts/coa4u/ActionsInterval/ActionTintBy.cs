using System;
using System.Collections.Generic;
using UnityEngine;

namespace coa4u
{
    /// <summary>
    /// Tints the target by the given color value. If you're going to change alpha, target shaders should support transparency.
    /// </summary>
    class ActionTintBy : ActionInterval
    {
        protected Vector4 color;
        protected const float coeff = 1F / 255F;

        public ActionTintBy(Vector4 targetColor, float targetDuration)
            : base(targetDuration)
        {
            color = targetColor * coeff;
        }

        public ActionTintBy(Vector3 targetColor, float targetDuration)
            : this(new Vector4(targetColor.x, targetColor.y, targetColor.z), targetDuration)
        {
        }

        public override ActionInstant Clone()
        {
            return new ActionTintBy(color / coeff, duration);
        }

        public override ActionInstant Reverse()
        {
            return new ActionTintBy(-color / coeff, duration);
        }

        public override void Step(float dt)
        {
            float d = dt / duration;
            Vector4 target = color * d;
            Color targetColor = renderer.material.color;
            targetColor[0] += target[0];
            targetColor[1] += target[1];
            targetColor[2] += target[2];
            targetColor[3] += target[3];
            renderer.material.color = targetColor;
        }
    }
}