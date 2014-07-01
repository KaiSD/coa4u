using System;
using System.Collections.Generic;
using UnityEngine;

namespace coa4u
{
    /// <summary>
    /// Rotates to the given value.
    /// </summary>
    class ActionScaleTo : ActionInterval
    {
        protected Vector3 value;
        protected Vector3 path;

        public ActionScaleTo(Vector3 targetValue, float targetDuration)
            : base(targetDuration)
        {
            value = targetValue;
        }

        public ActionScaleTo(Vector2 targetValue, float targetDuration)
            : this((Vector3)targetValue, targetDuration)
        {
            locks = Axises.z;
        }

        public override ActionInstant Clone()
        {
            return new ActionScaleTo(value, duration);
        }

        public override void Start()
        {
            base.Start();
            if (locks != Axises.none)
                LockAxises(ref value);
            path = value - transform.localScale;
        }

        public override void Step(float dt)
        {
            float d = dt / duration;
            Vector3 target = path * d;
            transform.localScale += target;
        }
    }
}