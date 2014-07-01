using System;
using System.Collections.Generic;
using UnityEngine;

namespace coa4u
{
    /// <summary>
    /// Jumps to the given point for the given amount of seconds in the given amounts of jumps.
    /// </summary>
    class ActionJumpTo : ActionSequence
    {
        protected Vector3 point;
        float height;
        int jumps;

        public ActionJumpTo(Vector3 targetPoint, float targetHeight, int targetJumps, float targetDuration)
            : base(new ActionInstant[targetJumps])
        {
            point = targetPoint;
            jumps = targetJumps;
            height = targetHeight;
            duration = targetDuration;
        }

        public ActionJumpTo(Vector2 targetPoint, float targetHeight, int targetJumps, float targetDuration)
            : this((Vector3)targetPoint, targetHeight, targetJumps, targetDuration)
        {
            locks = Axises.z;
        }

        public override ActionInstant Clone()
        {
            return new ActionJumpTo(point, height, jumps, duration);
        }

        public override void Start()
        {
            float coeff = 1F / jumps;
            if (locks != Axises.none)
                LockAxises(ref point);
            Vector3 start = target.gameObject.transform.position;
            Vector3 end = (point - start) * coeff;
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