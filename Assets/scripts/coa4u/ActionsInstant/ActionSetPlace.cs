using System;
using System.Collections.Generic;
using UnityEngine;

namespace coa4u
{
    /// <summary>
    /// Instantly moves the target to the given point.
    /// </summary>
    class ActionSetPlace : ActionInstant
    {
        protected Vector3 value;

        public ActionSetPlace(Vector3 targetPlace)
            : base()
        {
            value = targetPlace;
        }

        public ActionSetPlace(Vector2 targetPlace)
            : this((Vector3)targetPlace)
        {
            locks = Axises.z;
        }

        public override ActionInstant Clone()
        {
            return new ActionSetPlace(value);
        }

        public override void Start()
        {
            base.Start();
            if (locks != Axises.none)
                LockAxises(ref value);
            transform.position = value;
        }
    }
}