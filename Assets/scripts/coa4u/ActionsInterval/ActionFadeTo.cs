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

        public ActionFadeTo(float tgtValue, float tgtDuration)
            : base(tgtDuration)
        {
            value = tgtValue;
        }

        /// <summary>
        /// Returns a copy of the action.
        /// </summary>
        public override ActionInstant clone()
        {
            return new ActionFadeTo(value, duration);
        }

        /// <summary>
        /// This method is called at the action start.
        /// </summary>
        public override void start()
        {
            base.start();
            delta = value - renderer.material.color.a;
        }

        /// <summary>
        /// This method is called every frame update.
        /// </summary>
        public override void stepInterval(float dt)
        {
            float d = dt / duration;
            Color tgtColor = renderer.material.color;
            tgtColor[3] += delta * d;
            renderer.material.color = tgtColor;
        }
    }
}