using System;
using System.Collections.Generic;
using UnityEngine;

namespace coa4u
{
    /// <summary>
    /// Fades the target by the given alpha value. The tartet shaders should support transparency in order to use this action.
    /// </summary>
    class ActionFadeBy : ActionInterval
    {
        protected float delta;

        public ActionFadeBy(float targetDelta, float targetDuration)
            : base(targetDuration)
        {
            delta = targetDelta;
        }

        public override ActionInstant Clone()
        {
            return new ActionFadeBy(delta, duration);
        }

        public override ActionInstant Reverse()
        {
            return new ActionFadeBy(-delta, duration);
        }

        public override void Step(float dt)
        {
            float d = dt / duration;
            Color targetColor = renderer.material.color;
            targetColor[3] += delta * d;
            renderer.material.color = targetColor;
        }
    }
}