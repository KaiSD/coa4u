using System;
using System.Collections.Generic;
using UnityEngine;

namespace coa4u
{
    class ActionTintBy : ActionInterval
    {
        protected Vector4 color;
        protected const float coeff = 1F / 255F;

        public ActionTintBy(Vector4 tgtColor, float tgtDuration)
            : base(tgtDuration)
        {
            color = tgtColor * coeff;
        }

        public ActionTintBy(Vector3 tgtColor, float tgtDuration)
            : this(new Vector4(tgtColor.x, tgtColor.y, tgtColor.z), tgtDuration)
        {
        }

        public override ActionInstant clone()
        {
            return new ActionTintBy(color / coeff, duration);
        }

        public override ActionInstant reverse()
        {
            return new ActionTintBy(-color / coeff, duration);
        }

        public override void stepInterval(float dt)
        {
            float d = dt / duration;
            Vector4 tgt = color * d;
            Color tgtColor = renderer.material.color;
            tgtColor[0] += tgt[0];
            tgtColor[1] += tgt[1];
            tgtColor[2] += tgt[2];
            tgtColor[3] += tgt[3];
            renderer.material.color = tgtColor;
        }
    }
}