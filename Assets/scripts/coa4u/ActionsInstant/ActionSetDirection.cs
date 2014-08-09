using System;
using System.Collections.Generic;
using UnityEngine;

namespace coa4u
{
    /// <summary>
    /// Instantly rotates the target to face the given point or actor.
    /// </summary>
    class ActionSetDirection : ActionInstant
    {
        protected Vector3 value;
        protected Actor other;

        public ActionSetDirection(Vector3 targetValue)
            : base()
        {
            value = targetValue;
        }

        public ActionSetDirection(Vector2 targetValue)
            : this((Vector3)targetValue)
        {
            locks = Axises.z;
        }

        public ActionSetDirection(Actor targetActor)
            : base()
        {
            other = targetActor;
            value = targetActor.transformCached.position;
        }

        public override ActionInstant Clone()
        {
            return new ActionSetDirection(value);
        }

        public override void Start()
        {
            base.Start();
            if (other != null)
            {
                value = other.transformCached.position;
            }
            if (locks != Axises.none)
                LockAxises(ref value);
            transform.rotation = Quaternion.LookRotation(value - transform.position);
        }
    }
}