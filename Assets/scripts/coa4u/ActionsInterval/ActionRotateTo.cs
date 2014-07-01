using System;
using System.Collections.Generic;
using UnityEngine;

namespace coa4u
{
    /// <summary>
    /// Rotates to the given euler angles.
    /// </summary>
    class ActionRotateTo : ActionInterval
    {
        protected Vector3 value;
        protected Vector3 path;

        public ActionRotateTo(Vector3 targetValue, float targetDuration)
            : base(targetDuration)
        {
            value = targetValue;
        }

        public ActionRotateTo(float angle, float targetDuration)
            : this(new Vector3(0, 0, angle), targetDuration)
        {
            locks = Axises.xy;
        }

        public override ActionInstant Clone()
        {
            return new ActionRotateTo(value, duration);
        }

        public override void Start()
        {
            base.Start();
            path = new Vector3();
            for (int i = 0; i < 3; i++)
            {
                float t = value[i];
                float f = transform.rotation.eulerAngles[i];
                if (Math.Abs(t - f) < Math.Abs(t + 360 - f))
                    path[i] = t - f;
                else
                    path[i] = t + 360 - f;
            }
            if (locks != Axises.none)
                LockAxises(ref path);
        }
        public override void Step(float dt)
        {
            float d = dt / duration;
            Vector3 target = path * d;
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + target);
        }
    }
}