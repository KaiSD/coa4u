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

        public override ActionInstant Clone()
        {
            ActionInstant[] aList = new ActionInstant[actions.Length];
            for (int i = 0; i < actions.Length; i++)
            {
                aList[i] = actions[i].Clone();
            }
            return new ActionSequence(aList);
        }

        public override ActionInstant Reverse()
        {
            ActionInstant[] aList = new ActionInstant[actions.Length];
            for (int i = 0; i < actions.Length; i++)
            {
                aList[i] = actions[i].Reverse();
            }
            return new ActionSequence(aList);
        }

        public override void Start()
        {
            base.Start();
            for (int i = 0; i < actions.Length; i++)
            {
                actions[i].SetActor(target);
                actions[i].Start();
            }
        }

        public override void StepTimer(float dt)
        {
            dt *= timeScale;
            for (int i = 0; i < actions.Length; i++)
            {
                if (actions[i].running)
                    actions[i].StepTimer(dt);
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
                Stop();
                dtr = dtrdata;
            }
        }

        /// <summary>
        /// This method is called after the interval action is stopped.
        /// </summary>
        public override void Stop()
        {
            base.Stop();
            for (int i = 0; i < actions.Length; i++)
            {
                actions[i].Stop();
            }
        }
    }
}