using System;
using System.Collections.Generic;
using UnityEngine;

namespace coa4u
{
    /// <summary>
    /// Fades the target to the given alpha value. The tartet shaders should support transparency in order to use this action.
    /// </summary>
    class ActionFadeTo : ActionInterval
    {
        protected float value;
        protected float delta;

        public ActionFadeTo(float targetValue, float targetDuration)
            : base(targetDuration)
        {
            value = targetValue;
        }

        public override ActionInstant Clone()
        {
            return new ActionFadeTo(value, duration);
        }

        public override void Start()
        {
            base.Start();
            delta = value - renderer.material.color.a;
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