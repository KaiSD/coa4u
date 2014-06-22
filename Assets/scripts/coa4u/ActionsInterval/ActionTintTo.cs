using System;
using System.Collections.Generic;
using UnityEngine;

namespace coa4u
{
    class ActionTintTo : ActionInterval
    {
        protected Vector4 color;
        protected Vector4 path;
        protected const float coeff = 1F / 255F;

        public ActionTintTo(Vector4 tgtColor, float tgtDuration)
            : base(tgtDuration)
        {
            color = tgtColor * coeff;
            path = Vector4.zero;
        }

        public ActionTintTo(Vector3 tgtColor, float tgtDuration)
            : this(new Vector4(tgtColor.x, tgtColor.y, tgtColor.z), tgtDuration)
        {
        }

        public override ActionInstant clone()
        {
            return new ActionTintTo(color / coeff, duration);
        }

        public override void start()
        {
            base.start();
            Color tgtColor = renderer.material.color;
            path[0] = color[0] - tgtColor[0];
            path[1] = color[1] - tgtColor[1];
            path[2] = color[2] - tgtColor[2];
            path[3] = color[3] - tgtColor[3];
        }

        public override void stepInterval(float dt)
        {
            float d = dt / duration;
            Vector4 tgt = path * d;
            Color tgtColor = renderer.material.color;
            tgtColor[0] += tgt[0];
            tgtColor[1] += tgt[1];
            tgtColor[2] += tgt[2];
            tgtColor[3] += tgt[3];
            renderer.material.color = tgtColor;
        }
    }
}