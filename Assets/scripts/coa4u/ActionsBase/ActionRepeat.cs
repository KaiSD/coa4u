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

        public ActionRepeat(ActionInterval targetAction, int targetCount)
            : base(0)
        {
            action = targetAction;
            count = targetCount;
            counter = 0;
            forever = false;
        }

        public ActionRepeat(ActionInterval targetAction)
            : base(0)
        {
            action = targetAction;
            count = 0;
            counter = 0;
            forever = true;
        }

        public override ActionInstant Clone()
        {
            return new ActionRepeat((ActionInterval)action.Clone(), count);
        }

        public override ActionInstant Reverse()
        {
            return new ActionRepeat((ActionInterval)action.Reverse(), count);
        }

        public override void Start()
        {
            base.Start();
            action.SetActor(target);
            action.Start();
            counter = 0;
        }

        public override void StepTimer(float dt)
        {
            dt *= timeScale;
            if (action.running)
            {
                action.StepTimer(dt);
            }
            if (!action.running && (forever || counter < count - 1))
            {
                float dtrdata = action.dtr;
                action.Start();
                if (dtrdata > 0)
                    action.StepTimer(dtrdata);
                counter += 1;
            }
            else if (!action.running && counter >= count - 1)
            {
                dtr = action.dtr;
                Stop();
            }
        }
    }
}