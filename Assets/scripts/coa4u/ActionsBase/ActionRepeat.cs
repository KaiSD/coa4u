using System;
using System.Collections.Generic;
using UnityEngine;

namespace coa4u
{
    /// <summary>
    /// Runs the given action the several times. Also can repeat the action forever.
    /// </summary>
    class ActionRepeat : ActionInterval
    {
        protected ActionInterval action;
        protected int count;
        protected int counter;
        protected bool forever;

        public ActionRepeat(ActionInterval tgtAction, int tgtCount)
            : base(0)
        {
            action = tgtAction;
            count = tgtCount;
            counter = 0;
            forever = false;
        }

        public ActionRepeat(ActionInterval tgtAction)
            : base(0)
        {
            action = tgtAction;
            count = 0;
            counter = 0;
            forever = true;
        }

        /// <summary>
        /// Returns a copy of the action.
        /// </summary>
        public override ActionInstant clone()
        {
            return new ActionRepeat((ActionInterval)action.clone(), count);
        }

        /// <summary>
        /// Returns the reversed version of the action, if it is possible.
        /// </summary>
        public override ActionInstant reverse()
        {
            return new ActionRepeat((ActionInterval)action.reverse(), count);
        }

        /// <summary>
        /// This method is called at the action start.
        /// </summary>
        public override void start()
        {
            base.start();
            action.setActor(target);
            action.start();
            counter = 0;
        }

        /// <summary>
        /// This method is called every frame update.
        /// </summary>
        public override void step(float dt)
        {
            dt *= timeScale;
            if (action.running)
            {
                action.step(dt);
            }
            if (!action.running && (forever || counter < count - 1))
            {
                float dtrdata = action.dtr;
                action.start();
                if (dtrdata > 0)
                    action.step(dtrdata);
                counter += 1;
            }
            else if (!action.running && counter >= count - 1)
            {
                dtr = action.dtr;
                stop();
            }
        }
    }
}