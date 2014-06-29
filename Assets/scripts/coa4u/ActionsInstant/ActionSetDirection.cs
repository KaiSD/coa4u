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

        public ActionSetDirection(Vector3 tgtValue)
            : base()
        {
            value = tgtValue;
        }

        public ActionSetDirection(Vector2 tgtValue)
            : this((Vector3)tgtValue)
        {
            locks = Axises.z;
        }

        public ActionSetDirection(Actor tgtActor)
            : base()
        {
            other = tgtActor;
        }

        /// <summary>
        /// Returns a copy of the action.
        /// </summary>
        public override ActionInstant clone()
        {
            return new ActionSetDirection(value);
        }

        /// <summary>
        /// This method is called at the action start.
        /// </summary>
        public override void start()
        {
            base.start();
            if (other != null)
            {
                value = other.transform.position;
            }
            if (locks != Axises.none)
            {
                value.z = transform.position.z;
            }
            transform.rotation = Quaternion.LookRotation(value - transform.position);
        }
    }
}