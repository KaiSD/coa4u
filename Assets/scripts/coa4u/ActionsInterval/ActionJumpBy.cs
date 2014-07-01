using System;
using System.Collections.Generic;
using UnityEngine;

namespace coa4u
{
    /// <summary>
    /// Jumps given number of times in the given direction for the given amount of seconds.
    /// </summary>
    class ActionJumpBy : ActionSequence
    {
        protected Vector3 point;
        float height;
        int jumps;

        public ActionJumpBy(Vector3 targetPoint, float targetHeight, int targetJumps, float targetDuration)
            : base(new ActionInstant[targetJumps])
        {
            point = targetPoint;
            jumps = targetJumps;
            height = targetHeight;
            duration = targetDuration;
        }

        public ActionJumpBy(Vector2 targetPoint, float targetHeight, int targetJumps, float targetDuration)
            : this((Vector3)targetPoint, targetHeight, targetJumps, targetDuration)
        {
        }

        public override ActionInstant Clone()
        {
            return new ActionJumpBy(point, height, jumps, duration);
        }

        public override ActionInstant Reverse()
        {
            return new ActionJumpBy(-point, height, jumps, duration);
        }

        public override void Start()
        {
            float coeff = 1F / jumps;
            Vector3 end = point * coeff;
            Vector3 cp1 = Vector3.up * height;
            Vector3 cp2 = end + cp1;
            ActionBezierRel singleJump = new ActionBezierRel(cp1, cp2, end, duration * coeff);
            for (int i = 0; i < jumps; i++)
            {
                actions[i] = singleJump;
            }
            base.Start();
        }
    }
}