using System;
using System.Collections.Generic;
using UnityEngine;

namespace coa4u
{
    class ActionSkewBy : ActionInterval
    {
        protected Vector3 skewAngles1;
        protected Vector3 skewAngles2;
        protected Mesh mesh;

        public ActionSkewBy(Vector3 tgtAngles1, Vector3 tgtAngles2, float tgtDuration)
            : base(tgtDuration)
        {
            skewAngles1 = tgtAngles1;
            skewAngles2 = tgtAngles2;
        }

        public override ActionInstant clone()
        {
            return new ActionSkewBy(skewAngles1, skewAngles2, duration);
        }

        public override ActionInstant reverse()
        {
            return new ActionSkewBy(-skewAngles1, -skewAngles2, duration);
        }

        public override void start()
        {
            base.start();
            if (!(target is Actor))
            {
                throw new Exception("You should use Actor class instead of Actor, if you want to skew your object.");
            }
        }

        public override void stepInterval(float dt)
        {
            float d = dt / duration;
            Vector3 tgt = skewAngles1 * d;
            ((Actor)target).skewAngles1 += tgt;
            tgt = skewAngles2 * d;
            ((Actor)target).skewAngles2 += tgt;
        }
    }
}