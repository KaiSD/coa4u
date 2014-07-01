using System;
using System.Collections.Generic;
using UnityEngine;

namespace coa4u
{
    /// <summary>
    /// Moves the target with a cubic Bezier in relative coordinates.
    /// </summary>
    class ActionBezierRel : ActionInterval
    {
        protected Vector3 ep;
        protected Vector3 cp1;
        protected Vector3 cp2;
        protected Vector3 startPoint;
        protected Vector3 endPoint;
        protected Vector3 startControlPoint;
        protected Vector3 endControlPoint;

        public ActionBezierRel(Vector3 targetSCP, Vector3 targetECP, Vector3 targetEnd, float targetDuration)
            : base(targetDuration)
        {
            ep = targetEnd;
            cp1 = targetSCP;
            cp2 = targetECP;
        }

        public ActionBezierRel(Vector2 targetSCP, Vector2 targetECP, Vector2 targetEnd, float targetDuration)
            : this((Vector3)targetSCP, (Vector3)targetECP, (Vector3)targetEnd, targetDuration)
        {
        }

        public override ActionInstant Clone()
        {
            return new ActionBezierRel(startControlPoint, endControlPoint, endPoint, duration);
        }

        public override ActionInstant Reverse()
        {
            return new ActionBezierRel(-startControlPoint, -endControlPoint, -endPoint, duration);
        }

        public override void Start()
        {
            base.Start();
            startPoint = target.transform.position;
            endPoint = startPoint + ep;
            startControlPoint = startPoint + cp1;
            endControlPoint = startControlPoint + cp2;
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