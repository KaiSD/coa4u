using System;
using System.Collections.Generic;
using UnityEngine;

namespace coa4u
{
    class ActionScaleTo : ActionInterval
    {
        protected Vector3 value;
        protected Vector3 path;

        public ActionScaleTo(Vector3 tgtValue, float tgtDuration)
            : base(tgtDuration)
        {
            value = tgtValue;
        }

        public ActionScaleTo(Vector2 tgtValue, float tgtDuration)
            : this((Vector3)tgtValue, tgtDuration)
        {
            locks = Axises.z;
        }

        public override ActionInstant clone()
        {
            return new ActionScaleTo(value, duration);
        }

        public override void start()
        {
            base.start();
            if (locks != Axises.none)
                lockAxises(ref value);
            path = value - transform.localScale;
        }

        public override void stepInterval(float dt)
        {
            float d = dt / duration;
            Vector3 tgt = path * d;
            transform.localScale += tgt;
        }
    }
}