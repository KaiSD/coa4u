using System;
using System.Collections.Generic;
using UnityEngine;

namespace coa4u
{
    class ActionJumpBy : ActionSequence
    {
        protected Vector3 point;
        float height;
        int jumps;

        public ActionJumpBy(Vector3 tgtPoint, float tgtHeight, int tgtJumps, float tgtDuration)
            : base(new ActionInstant[tgtJumps])
        {
            point = tgtPoint;
            jumps = tgtJumps;
            height = tgtHeight;
            duration = tgtDuration;
        }

        public ActionJumpBy(Vector2 tgtPoint, float tgtHeight, int tgtJumps, float tgtDuration)
            : this((Vector3)tgtPoint, tgtHeight, tgtJumps, tgtDuration)
        {
        }

        public override ActionInstant clone()
        {
            return new ActionJumpBy(point, height, jumps, duration);
        }

        public override ActionInstant reverse()
        {
            return new ActionJumpBy(-point, height, jumps, duration);
        }

        public override void start()
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
            base.start();
        }
    }
}