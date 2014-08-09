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
            locks = Axises.rxy;
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
                if ((f - t) <= 180 && (f - t) >= -180)
                {
                    path[i] = t - f;
                }
                else if ((f - t) > 180)
                {
                    path[i] = t - f + 360;
                }
                else if ((f - t) < -180)
                {
                    path[i] = t - f - 360;
                }
            }
            if (locks != Axises.none)
                LockAxises(ref path);
        }
        public override void Step(float dt)
        {
            float d = dt / duration;
            Vector3 rotation = path * d;
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + rotation);
        }
    }
}