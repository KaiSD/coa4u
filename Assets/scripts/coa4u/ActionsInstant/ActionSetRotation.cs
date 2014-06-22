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

        public ActionSetRotation(Vector3 tgtValue)
            : base()
        {
            value = tgtValue;
        }

        public ActionSetRotation(float angle)
            : this(new Vector3(0, 0, angle))
        {
            is2d = true;
        }

        /// <summary>
        /// Returns a copy of the action.
        /// </summary>
        public override ActionInstant clone()
        {
            return new ActionSetRotation(value);
        }

        /// <summary>
        /// This method is called at the action start.
        /// </summary>
        public override void start()
        {
            base.start();
            transform.rotation = Quaternion.Euler(value);
        }
    }
}