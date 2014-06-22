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

        public ActionBezierAbs(Vector3 tgtStart, Vector3 tgtSCP, Vector3 tgtECP, Vector3 tgtEnd, float tgtDuration)
            : base(tgtDuration)
        {
            startPoint = tgtStart;
            endPoint = tgtEnd;
            startControlPoint = tgtSCP;
            endControlPoint = tgtECP;
        }

        public ActionBezierAbs(Vector2 tgtStart, Vector2 tgtSCP, Vector2 tgtECP, Vector2 tgtEnd, float tgtDuration)
            : this((Vector3)tgtStart, (Vector3)tgtSCP, (Vector3)tgtECP, (Vector3)tgtEnd, tgtDuration)
        {
            is2d = true;
        }

        /// <summary>
        /// Returns a copy of the action.
        /// </summary>
        public override ActionInstant clone()
        {
            return new ActionBezierAbs(startPoint, startControlPoint, endControlPoint, endPoint, duration);
        }

        /// <summary>
        /// Returns the reversed version of the action, if it is possible.
        /// </summary>
        public override ActionInstant reverse()
        {
            return new ActionBezierAbs(endPoint, endControlPoint, startControlPoint, startPoint, duration);
        }

        /// <summary>
        /// This method is called at the action start.
        /// </summary>
        public override void start()
        {
            base.start();
            float z = transform.position.z;
            if (is2d)
            {
                startPoint.z = z;
                endPoint.z = z;
                startControlPoint.z = z;
                endControlPoint.z = z;
            }
        }

        /// <summary>
        /// This method is called every frame update.
        /// </summary>
        public override void stepInterval(float dt)
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