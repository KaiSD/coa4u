using System;
using System.Collections.Generic;
using UnityEngine;

namespace coa4u
{
    /// <summary>
    /// Instantly rotates the target.
    /// </summary>
    class ActionSetRotation : ActionInstant
    {
        protected Vector3 value;

        public ActionSetRotation(Vector3 targetValue)
            : base()
        {
            value = targetValue;
        }

        public ActionSetRotation(float angle)
            : this(new Vector3(0, 0, angle))
        {
            locks = Axises.rxy;
        }

        public override ActionInstant Clone()
        {
            return new ActionSetRotation(value);
        }

        public override void Start()
        {
            base.Start();
            if (locks != Axises.none)
                LockAxises(ref value);
            transform.rotation = Quaternion.Euler(value);
        }
    }
}