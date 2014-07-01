using System;
using System.Collections.Generic;
using UnityEngine;

namespace coa4u
{
    /// <summary>
    /// Runs several actions in a sequence.
    /// </summary>
    class ActionSequence : ActionInterval
    {
        protected ActionInstant[] actions;
        protected int index;

        public ActionSequence(ActionInstant action1, ActionInstant action2)
            : base(0)
        {
            actions = new ActionInstant[] { action1, action2 };
        }

        public ActionSequence(ActionInstant[] actionsList)
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
                aList[actions.Length - 1 - i] = actions[i].Reverse();
            }
            return new ActionSequence(aList);
        }

        public override void Start()
        {
            base.Start();
            index = 0;
            actions[0].SetActor(target);
            actions[0].Start();
            while (!actions[index].running && index < actions.Length)
            {
                index += 1;
                actions[index].SetActor(target);
                actions[index].Start();
            }
        }

        public override void StepTimer(float dt)
        {
            dt *= timeScale;
            float dtrdata = 0;
            if (actions[index].running)
            {
                actions[index].StepTimer(dt);
                if (!actions[index].running)
                    dtrdata = actions[index].dtr;
            }
            while (!actions[index].running && index < actions.Length - 1)
            {
                index += 1;
                actions[index].SetActor(target);
                actions[index].Start();
                if (actions[index].running && dtrdata > 0)
                    actions[index].StepTimer(dtrdata);
            }
            if (!actions[index].running)
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