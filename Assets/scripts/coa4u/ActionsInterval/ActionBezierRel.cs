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

        public ActionBezierRel(Vector3 tgtSCP, Vector3 tgtECP, Vector3 tgtEnd, float tgtDuration)
            : base(tgtDuration)
        {
            ep = tgtEnd;
            cp1 = tgtSCP;
            cp2 = tgtECP;
        }

        public ActionBezierRel(Vector2 tgtSCP, Vector2 tgtECP, Vector2 tgtEnd, float tgtDuration)
            : this((Vector3)tgtSCP, (Vector3)tgtECP, (Vector3)tgtEnd, tgtDuration)
        {
        }

        /// <summary>
        /// Returns a copy of the action.
        /// </summary>
        public override ActionInstant clone()
        {
            return new ActionBezierRel(startControlPoint, endControlPoint, endPoint, duration);
        }

        /// <summary>
        /// Returns the reversed version of the action, if it is possible.
        /// </summary>
        public override ActionInstant reverse()
        {
            return new ActionBezierRel(-startControlPoint, -endControlPoint, -endPoint, duration);
        }

        /// <summary>
        /// This method is called at the action start.
        /// </summary>
        public override void start()
        {
            base.start();
            startPoint = target.transform.position;
            endPoint = startPoint + ep;
            startControlPoint = startPoint + cp1;
            endControlPoint = startControlPoint + cp2;
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