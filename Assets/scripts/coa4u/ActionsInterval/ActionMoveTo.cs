using System;
using System.Collections.Generic;
using UnityEngine;

namespace coa4u
{
    class ActionMoveTo : ActionInterval
    {
        protected Vector3 value;
        protected Vector3 path;

        public ActionMoveTo(Vector3 tgtValue, float tgtDuration)
            : base(tgtDuration)
        {
            value = tgtValue;
        }

        public ActionMoveTo(Vector2 tgtValue, float tgtDuration)
            : this((Vector3)tgtValue, tgtDuration)
        {
            is2d = true;
        }

        public override ActionInstant clone()
        {
            return new ActionMoveBy(value, duration);
        }

        public override void start()
        {
            base.start();
            if (is2d)
                value.z = transform.position.z;
            path = value - transform.position;
        }

        public override void stepInterval(float dt)
        {
            float d = dt / duration;
            Vector3 tgt = path * d;
            transform.Translate(tgt, Space.World);
        }
    }
}