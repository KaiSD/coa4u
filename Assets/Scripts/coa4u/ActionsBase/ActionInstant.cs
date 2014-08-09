using System;
using System.Collections.Generic;
using UnityEngine;

namespace coa4u
{
    /// <summary>
    /// Basic action class for subclassing. To inherit interval actions, consider using the ActionInterval as the base class.
    /// </summary>
    public class ActionInstant
    {
        /// <summary>
        /// Axis locks - the action will try to preserve tha values of these axises when moving or rotating the target.
        /// </summary>
        public Axises locks = Axises.none;
        /// <summary>
        /// Sets if the action should stop when the actor's StopAllActions method is called.
        /// </summary>
        public bool unstopable = false;

        protected Actor target;
        protected Transform transform;
        protected Renderer renderer;
        private float durationValue = 0;
        private float dtrValue = 0;
        private bool isRunning = false;

        public ActionInstant()
        {
        }

        /// <summary>
        /// Returns a copy of the action.
        /// </summary>
        public virtual ActionInstant Clone()
        {
            return new ActionInstant();
        }

        /// <summary>
        /// Returns the reversed version of the action, if it is possible.
        /// </summary>
        public virtual ActionInstant Reverse()
        {
            throw new Exception("Can reverse only the reversable interval actions");
        }

        /// <summary>
        /// This method is called at the action start. Usable for instant and interval actions.
        /// </summary>
        public virtual void Start()
        {
            if (target == null)
                throw new Exception("Can start the action only after it's atached to the actor");
            transform = target.transformCached;
            renderer = target.rendererCached;
        }

        /// <summary>
        /// This method is called at every frame update. Not usable for instant actions.
        /// </summary>
        public virtual void StepTimer(float dt)
        {
            if (target == null)
                throw new Exception("Can update the action only after it's atached to the actor");
        }

        /// <summary>
        /// This method is called after the interval action is stopped. Not usable for instant actions.
        /// </summary>
        public virtual void Stop()
        {
            if (target == null)
                throw new Exception("Can stop the action only after it's atached to the actor");
        }

        /// <summary>
        /// This method sets the actor for the action.
        /// </summary>
        public void SetActor(Actor actor)
        {
            target = actor;
        }

        /// <summary>
        /// This method modifies the given vector to keep the locked axises untouched.
        /// </summary>
        protected void LockAxises(ref Vector3 point)
        {
            {
                if (target == null)
                    throw new Exception("Can calculate axises only after the action is atached to the actor");
            }

            switch (locks)
            {
                case Axises.x:
                    point.x = transform.position.x;
                    break;
                case Axises.y:
                    point.y = transform.position.y;
                    break;
                case Axises.z:
                    point.z = transform.position.z;
                    break;
                case Axises.xy:
                    point.x = transform.position.x;
                    point.y = transform.position.y;
                    break;
                case Axises.xz:
                    point.x = transform.position.x;
                    point.z = transform.position.z;
                    break;
                case Axises.yz:
                    point.y = transform.position.y;
                    point.z = transform.position.z;
                    break;
                case Axises.xyz:
                    point.x = transform.position.x;
                    point.y = transform.position.y;
                    point.z = transform.position.z;
                    break;
                case Axises.rx:
                    point.x = transform.rotation.eulerAngles.x;
                    break;
                case Axises.ry:
                    point.y = transform.rotation.eulerAngles.y;
                    break;
                case Axises.rz:
                    point.z = transform.rotation.eulerAngles.z;
                    break;
                case Axises.rxy:
                    point.x = transform.rotation.eulerAngles.x;
                    point.y = transform.rotation.eulerAngles.y;
                    break;
                case Axises.rxz:
                    point.x = transform.rotation.eulerAngles.x;
                    point.z = transform.rotation.eulerAngles.z;
                    break;
                case Axises.ryz:
                    point.y = transform.rotation.eulerAngles.y;
                    point.z = transform.rotation.eulerAngles.z;
                    break;
                case Axises.rxyz:
                    point.x = transform.rotation.eulerAngles.x;
                    point.y = transform.rotation.eulerAngles.y;
                    point.z = transform.rotation.eulerAngles.z;
                    break;
            }
        }

        /// <summary>
        /// Readonly property. Shows the remaining time of the action.
        /// </summary>
        public float duration
        {
            get
            {
                return durationValue;
            }

            protected set
            {
                durationValue = value;
            }
        }

        /// <summary>
        /// Readonly property. Shows if the action is running or not.
        /// </summary>
        public bool running
        {
            get
            {
                return isRunning;
            }

            protected set
            {
                isRunning = value;
            }
        }

        /// <summary>
        /// Readonly property. Contains the remaining tick time after action finished.
        /// </summary>
        public float dtr
        {
            get
            {
                return dtrValue;
            }

            protected set
            {
                dtrValue = value;
            }
        }
    }
}