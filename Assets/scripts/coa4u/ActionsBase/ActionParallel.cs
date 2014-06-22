using System;
using System.Collections.Generic;
using UnityEngine;

namespace coa4u
{
    /// <summary>
    /// Runs several actions at the same time.
    /// </summary>
    public class ActionParallel : ActionInterval
    {
        protected ActionInstant[] actions;

        public ActionParallel(ActionInstant action1, ActionInstant action2)
            : base(0)
        {
            actions = new ActionInstant[] { action1, action2 };
        }

        public ActionParallel(ActionInstant[] actionsList)
            : base(0)
        {
            actions = actionsList;

        }

        /// <summary>
        /// Returns a copy of the action.
        /// </summary>
        public override ActionInstant clone()
        {
            ActionInstant[] aList = new ActionInstant[actions.Length];
            for (int i = 0; i < actions.Length; i++)
            {
                aList[i] = actions[i].clone();
            }
            return new ActionSequence(aList);
        }

        /// <summary>
        /// Returns the reversed version of the action, if it is possible.
        /// </summary>
        public override ActionInstant reverse()
        {
            ActionInstant[] aList = new ActionInstant[actions.Length];
            for (int i = 0; i < actions.Length; i++)
            {
                aList[i] = actions[i].reverse();
            }
            return new ActionSequence(aList);
        }

        /// <summary>
        /// This method is called at the action start.
        /// </summary>
        public override void start()
        {
            base.start();
            for (int i = 0; i < actions.Length; i++)
            {
                actions[i].setActor(target);
                actions[i].start();
            }
        }

        /// <summary>
        /// This method is called every frame update.
        /// </summary>
        public override void step(float dt)
        {
            dt *= timeScale;
            for (int i = 0; i < actions.Length; i++)
            {
                if (actions[i].running)
                    actions[i].step(dt);
            }
            bool canStopNow = true;
            float dtrdata = 0;
            for (int i = 0; i < actions.Length; i++)
            {
                if (actions[i].running)
                {
                    canStopNow = false;
                    dtrdata = Math.Max(actions[i].dtr, dtrdata);
                }
            }
            if (canStopNow)
            {
                stop();
                dtr = dtrdata;
            }
        }

        /// <summary>
        /// This method is called after the interval action is stopped.
        /// </summary>
        public override void stop()
        {
            base.stop();
            for (int i = 0; i < actions.Length; i++)
            {
                actions[i].stop();
            }
        }
    }
}