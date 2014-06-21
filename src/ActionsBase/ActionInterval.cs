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

        public ActionInterval(float tgtDuration)
            : base()
        {
            duration = tgtDuration;
            timeScale = 1F;
            dtr = 0;
        }

        /// <summary>
        /// Returns a copy of the action.
        /// </summary>
        public override ActionInstant clone()
        {
            return new ActionInterval(duration);
        }

        /// <summary>
        /// Returns the reversed version of the action, if it is possible.
        /// </summary>
        public override ActionInstant reverse()
        {
            throw new Exception("Can reverse only the reversable interval actions");
        }

        /// <summary>
        /// This method is called at the action start.
        /// </summary>
        public override void start()
        {
            base.start();
            running = true;
            timer = 0F;
        }

        /// <summary>
        /// This method is called after the interval action is stopped.
        /// </summary>
        public override void stop()
        {
            base.stop();
            running = false;
        }

        /// <summary>
        /// This method is called every frame update. Don't override this method, when inheriting, put your code in stepInterval instead.
        /// </summary>
        public override void step(float dt)
        {
            dt *= timeScale;
            base.step(dt);
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
            stepInterval(dt);
            if (timer > duration)
            {
                stop();
                dtr = timer - duration;
            }
        }

        /// <summary>
        /// This method is called every frame update. Put your code here.
        /// </summary>
        public virtual void stepInterval(float dt)
        {
        }

        /// <summary>
        /// Immediately changes the time scale for this action and all nested ones.
        /// </summary>
        public void setTimeScale(float ts)
        {
            timeScale = ts;
        }
    }
}