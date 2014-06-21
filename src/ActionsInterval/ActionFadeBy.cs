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

        public ActionFadeBy(float tgtDelta, float tgtDuration)
            : base(tgtDuration)
        {
            delta = tgtDelta;
        }

        /// <summary>
        /// Returns a copy of the action.
        /// </summary>
        public override ActionInstant clone()
        {
            return new ActionFadeBy(delta, duration);
        }

        /// <summary>
        /// Returns the reversed version of the action, if it is possible.
        /// </summary>
        public override ActionInstant reverse()
        {
            return new ActionFadeBy(-delta, duration);
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