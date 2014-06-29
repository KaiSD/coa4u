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

        public ActionSetPlace(Vector3 tgtPlace)
            : base()
        {
            value = tgtPlace;
        }

        public ActionSetPlace(Vector2 tgtPlace)
            : this((Vector3)tgtPlace)
        {
            locks = Axises.z;
        }

        /// <summary>
        /// Returns a copy of the action.
        /// </summary>
        public override ActionInstant clone()
        {
            return new ActionSetPlace(value);
        }

        /// <summary>
        /// This method is called at the action start.
        /// </summary>
        public override void start()
        {
            base.start();
            if (locks != Axises.none)
                lockAxises(ref value);
            transform.position = value;
        }
    }
}