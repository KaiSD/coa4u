using System;
using System.Collections.Generic;
using UnityEngine;

namespace coa4u
{
    /// <summary>
    /// Tints the target to the given color value. If you're going to change alpha, target shaders should support transparency.
    /// </summary>
    class ActionTintTo : ActionInterval
    {
        protected Vector4 color;
        protected Vector4 path;
        protected const float coeff = 1F / 255F;

        public ActionTintTo(Vector4 targetColor, float targetDuration)
            : base(targetDuration)
        {
            color = targetColor * coeff;
            path = Vector4.zero;
        }

        public ActionTintTo(Vector3 targetColor, float targetDuration)
            : this(new Vector4(targetColor.x, targetColor.y, targetColor.z), targetDuration)
        {
        }

        public override ActionInstant Clone()
        {
            return new ActionTintTo(color / coeff, duration);
        }

        public override void Start()
        {
            base.Start();
            Color targetColor = renderer.material.color;
            path[0] = color[0] - targetColor[0];
            path[1] = color[1] - targetColor[1];
            path[2] = color[2] - targetColor[2];
            path[3] = color[3] - targetColor[3];
        }

        public override void Step(float dt)
        {
            float d = dt / duration;
            Vector4 target = path * d;
            Color targetColor = renderer.material.color;
            targetColor[0] += target[0];
            targetColor[1] += target[1];
            targetColor[2] += target[2];
            targetColor[3] += target[3];
            renderer.material.color = targetColor;
        }
    }
}