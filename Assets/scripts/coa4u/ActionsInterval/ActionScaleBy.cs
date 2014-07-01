using System;
using System.Collections.Generic;
using UnityEngine;

namespace coa4u
{
    /// <summary>
    /// Scales the object by the given multiplier.
    /// </summary>
    class ActionScaleBy : ActionInterval
    {
        protected Vector3 delta;
        protected Vector3 path;

        public ActionScaleBy(Vector3 targetDelta, float targetDuration)
            : base(targetDuration)
        {
            delta = targetDelta;
        }

        public ActionScaleBy(Vector2 targetValue, float targetDuration)
            : this((Vector3)targetValue, targetDuration)
        {
        }

        public override ActionInstant Clone()
        {
            return new ActionScaleBy(delta, duration);
        }

        public override ActionInstant Reverse()
        {
            return new ActionScaleBy(delta * -1F, duration);
        }

        public override void Start()
        {
            base.Start();
            Vector3 scale = transform.localScale;
            scale.x *= delta.x;
            scale.y *= delta.y;
            scale.z *= delta.z;
            path = scale - transform.localScale;
        }

        public override void Step(float dt)
        {
            float d = dt / duration;
            Vector3 target = path * d;
            transform.localScale += target;
        }

        public override void Stop()
        {
            base.Stop();
        }
    }
}