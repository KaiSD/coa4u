using System;
using System.Collections.Generic;
using UnityEngine;

namespace coa4u
{
    /// <summary>
    /// Skews the object by the given angles.
    /// </summary>
    class ActionSkewBy : ActionInterval
    {
        protected Vector3 skewAngles1;
        protected Vector3 skewAngles2;
        protected Mesh mesh;

        public ActionSkewBy(Vector3 targetAngles1, Vector3 targetAngles2, float targetDuration)
            : base(targetDuration)
        {
            skewAngles1 = targetAngles1;
            skewAngles2 = targetAngles2;
        }

        public override ActionInstant Clone()
        {
            return new ActionSkewBy(skewAngles1, skewAngles2, duration);
        }

        public override ActionInstant Reverse()
        {
            return new ActionSkewBy(-skewAngles1, -skewAngles2, duration);
        }

        public override void Start()
        {
            base.Start();
            if (!(target is Actor))
            {
                throw new Exception("You should use Actor class instead of Actor, if you want to skew your object.");
            }
        }

        public override void Step(float dt)
        {
            float d = dt / duration;
            Vector3 vTarget = skewAngles1 * d;
            ((Actor)target).skewAngles1 += vTarget;
            vTarget = skewAngles2 * d;
            ((Actor)target).skewAngles2 += vTarget;
        }
    }
}