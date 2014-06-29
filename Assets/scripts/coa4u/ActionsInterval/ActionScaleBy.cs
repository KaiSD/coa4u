using System;
using System.Collections.Generic;
using UnityEngine;

namespace coa4u
{
    class ActionScaleBy : ActionInterval
    {
        protected Vector3 delta;
        protected Vector3 path;

        public ActionScaleBy(Vector3 tgtDelta, float tgtDuration)
            : base(tgtDuration)
        {
            delta = tgtDelta;
        }

        public ActionScaleBy(Vector2 tgtValue, float tgtDuration)
            : this((Vector3)tgtValue, tgtDuration)
        {
        }

        public override ActionInstant clone()
        {
            return new ActionScaleBy(delta, duration);
        }

        public override ActionInstant reverse()
        {
            return new ActionScaleBy(delta * -1F, duration);
        }

        public override void start()
        {
            base.start();
            Vector3 scale = transform.localScale;
            scale.x *= delta.x;
            scale.y *= delta.y;
            scale.z *= delta.z;
            path = scale - transform.localScale;
        }

        public override void stepInterval(float dt)
        {
            float d = dt / duration;
            Vector3 tgt = path * d;
            transform.localScale += tgt;
        }

        public override void stop()
        {
            base.stop();
        }
    }
}