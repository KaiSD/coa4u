using System;
using System.Collections.Generic;
using UnityEngine;

namespace coa4u
{
    /// <summary>
    /// Moves in the given direction for the given amount of seconds.
    /// </summary>
    class ActionMoveBy : ActionInterval
    {
        protected Vector3 delta;
        protected Vector3 referencePoint;

        public ActionMoveBy(Vector3 targetDelta, float targetDuration)
            : base(targetDuration)
        {
            delta = targetDelta;
        }

        public ActionMoveBy(Vector2 targetValue, float targetDuration)
            : this((Vector3)targetValue, targetDuration)
        {
        }

        public ActionMoveBy(ref Vector3 refPoint, float targetDuration)
            : this(Vector3.zero, targetDuration)
        {
            referencePoint = refPoint;
        }

        public override ActionInstant Clone()
        {
            return new ActionMoveBy(delta, duration);
        }

        public override ActionInstant Reverse()
        {
            return new ActionMoveBy(delta * -1F, duration);
        }

        public override void Start()
        {
            base.Start();
            if (referencePoint != null)
            {
                delta = referencePoint;
            }
        }

        public override void Step(float dt)
        {
            float d = dt / duration;
            Vector3 target = delta * d;
            transform.Translate(target, Space.World);
        }
    }
}