using System;
using System.Collections.Generic;
using UnityEngine;

namespace coa4u
{
    /// <summary>
    /// Interval action class for subclassing.
    /// </summary>
    public class ActionInterval : ActionInstant
    {
        protected float timer;
        protected float timeScale;
        private float dtrdata;

        public ActionInterval(float targetDuration)
            : base()
        {
            duration = targetDuration;
            timeScale = 1F;
            dtr = 0;
        }

        /// <summary>
        /// Returns a copy of the action.
        /// </summary>
        public override ActionInstant Clone()
        {
            return new ActionInterval(duration);
        }

        /// <summary>
        /// Returns the reversed version of the action, if it is possible.
        /// </summary>
        public override ActionInstant Reverse()
        {
            throw new Exception("Can reverse only the reversable interval actions");
        }

        /// <summary>
        /// This method is called at the action start.
        /// </summary>
        public override void Start()
        {
            base.Start();
            running = true;
            timer = 0F;
        }

        /// <summary>
        /// This method is called after the interval action is stopped.
        /// </summary>
        public override void Stop()
        {
            base.Stop();
            running = false;
        }

        /// <summary>
        /// This method is called every frame update. Don't override this method, when inheriting, put your code in Step() instead.
        /// </summary>
        public override void StepTimer(float dt)
        {
            dt *= timeScale;
            base.StepTimer(dt);
            if (timer + dt > duration)
            {
                float odt = dt;
                dt = duration - timer;
                timer += odt;
            }
            else
            {
                timer += dt;
            }
            Step(dt);
            if (timer > duration)
            {
                Stop();
                dtr = timer - duration;
            }
        }

        /// <summary>
        /// This method is called every frame update. Put your code here.
        /// </summary>
        public virtual void Step(float dt)
        {
        }

        /// <summary>
        /// Immediately changes the time scale for this action and all nested ones.
        /// </summary>
        public void SetTimeScale(float ts)
        {
            timeScale = ts;
        }
    }
}