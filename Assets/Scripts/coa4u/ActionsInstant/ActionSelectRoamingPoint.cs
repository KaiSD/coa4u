using System;
using System.Collections.Generic;
using UnityEngine;
using coa4u;

namespace coa4u
{
    /// <summary>
    /// Moves the target to the random point inside the given zone.
    /// </summary>
    class ActionSelectRoamingPoint : ActionInstant
    {
        protected Vector3 radius;
        protected Vector3 pointRef;
        protected float speed;
        protected Vector3 delta;

        public ActionSelectRoamingPoint(Vector3 targetRadius, ref Vector3 point)
            : base()
        {
            radius = targetRadius;
            pointRef = point;
        }

        public override ActionInstant Clone()
        {
            return new ActionSelectRoamingPoint(radius, ref pointRef);
        }

        public override void Start()
        {
            base.Start();
            pointRef.x = UnityEngine.Random.Range(-radius.x, radius.x);
            pointRef.y = UnityEngine.Random.Range(-radius.y, radius.y);
            pointRef.z = UnityEngine.Random.Range(-radius.z, radius.z);
        }
    }
}