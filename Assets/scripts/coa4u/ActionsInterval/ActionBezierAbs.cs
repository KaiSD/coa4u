using System;
using System.Collections.Generic;
using UnityEngine;

namespace coa4u
{
    /// <summary>
    /// Moves the target with a cubic Bezier in absolute coordinates (if the target is not in the start point, it'll be positioned there when the action starts).
    /// </summary>
    class ActionBezierAbs : ActionInterval
    {
        protected Vector3 startPoint;
        protected Vector3 endPoint;
        protected Vector3 startControlPoint;
        protected Vector3 endControlPoint;

        public ActionBezierAbs(Vector3 targetStart, Vector3 targetSCP, Vector3 targetECP, Vector3 targetEnd, float targetDuration)
            : base(targetDuration)
        {
            startPoint = targetStart;
            endPoint = targetEnd;
            startControlPoint = targetSCP;
            endControlPoint = targetECP;
        }

        public ActionBezierAbs(Vector2 targetStart, Vector2 targetSCP, Vector2 targetECP, Vector2 targetEnd, float targetDuration)
            : this((Vector3)targetStart, (Vector3)targetSCP, (Vector3)targetECP, (Vector3)targetEnd, targetDuration)
        {
            locks = Axises.z;
        }

        public override ActionInstant Clone()
        {
            return new ActionBezierAbs(startPoint, startControlPoint, endControlPoint, endPoint, duration);
        }

        public override ActionInstant Reverse()
        {
            return new ActionBezierAbs(endPoint, endControlPoint, startControlPoint, startPoint, duration);
        }

        public override void Start()
        {
            base.Start();
            float z = transform.position.z;
            if (locks != Axises.none)
            {
                LockAxises(ref startPoint);
                LockAxises(ref endPoint);
                LockAxises(ref startControlPoint);
                LockAxises(ref endControlPoint);
            }
        }

        public override void Step(float dt)
        {
            float t = timer / duration;
            Vector3 newPosition = (((-startPoint
                + 3 * (startControlPoint - endControlPoint) + endPoint) * t
                + (3 * (startPoint + endControlPoint) - 6 * startControlPoint)) * t +
                3 * (startControlPoint - startPoint)) * t + startPoint;
            transform.position = newPosition;
        }
    }
}