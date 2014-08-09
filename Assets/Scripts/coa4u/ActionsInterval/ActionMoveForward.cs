using System;
using System.Collections.Generic;
using UnityEngine;

namespace coa4u
{
    /// <summary>
    /// Moves in the given direction for the given amount of seconds.
    /// </summary>
    class ActionMoveForward : ActionInterval
    {
        protected float speed;
        protected Vector3 delta;

        public ActionMoveForward(float targetSpeed, float targetDuration)
            : base(targetDuration)
        {
            speed = targetSpeed;
        }

        public override ActionInstant Clone()
        {
            return new ActionMoveForward(speed, duration);
        }

        public override ActionInstant Reverse()
        {
            return new ActionMoveForward(speed * -1F, duration);
        }

        public override void Start()
        {
            base.Start();
            delta = speed * transform.forward;
        }

        public override void Step(float dt)
        {
            float d = dt / duration;
            transform.Translate(delta * d, Space.World);
        }
    }
}