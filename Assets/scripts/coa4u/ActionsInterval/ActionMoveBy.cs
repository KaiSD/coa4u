using System;
using System.Collections.Generic;
using UnityEngine;

namespace coa4u
{
    class ActionMoveBy : ActionInterval
    {
        protected Vector3 delta;

        public ActionMoveBy(Vector3 tgtDelta, float tgtDuration)
            : base(tgtDuration)
        {
            delta = tgtDelta;
        }

        public ActionMoveBy(Vector2 tgtValue, float tgtDuration)
            : this((Vector3)tgtValue, tgtDuration)
        {
        }

        public override ActionInstant clone()
        {
            return new ActionMoveBy(delta, duration);
        }

        public override ActionInstant reverse()
        {
            return new ActionMoveBy(delta * -1F, duration);
        }

        public override void stepInterval(float dt)
        {
            float d = dt / duration;
            Vector3 tgt = delta * d;
            transform.Translate(tgt, Space.World);
        }
    }
}