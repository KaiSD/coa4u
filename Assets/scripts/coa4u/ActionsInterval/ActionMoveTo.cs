using System;
using System.Collections.Generic;
using UnityEngine;

namespace coa4u
{
    /// <summary>
    /// Moves to the given point for the given amount of seconds.
    /// </summary>
    class ActionMoveTo : ActionInterval
    {
        protected Vector3 value;
        protected Vector3 path;

        public ActionMoveTo(Vector3 targetValue, float targetDuration)
            : base(targetDuration)
        {
            value = targetValue;
        }

        public ActionMoveTo(Vector2 targetValue, float targetDuration)
            : this((Vector3)targetValue, targetDuration)
        {
            locks = Axises.z;
        }

        public override ActionInstant Clone()
        {
            return new ActionMoveBy(value, duration);
        }

        public override void Start()
        {
            base.Start();
            if (locks != Axises.none)
                LockAxises(ref value);
            path = value - transform.position;
        }

        public override void Step(float dt)
        {
            float d = dt / duration;
            Vector3 target = path * d;
            transform.Translate(target, Space.World);
        }
    }
}