using System;
using System.Collections.Generic;
using UnityEngine;

namespace coa4u
{
    /// <summary>
    /// Runs one random action from the given list.
    /// </summary>
    class ActionRandom : ActionInterval
    {

        protected ActionInstant[] actions;
        protected int index;

        public ActionRandom(ActionInstant action1, ActionInstant action2)
            : base(0)
        {
            actions = new ActionInstant[] { action1, action2 };
        }

        public ActionRandom(ActionInstant[] actionsList)
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
            return new ActionRandom(aList);
        }

        public override ActionInstant Reverse()
        {
            ActionInstant[] aList = new ActionInstant[actions.Length];
            for (int i = 0; i < actions.Length; i++)
            {
                aList[i] = actions[i].Reverse();
            }
            return new ActionRandom(aList);
        }

        public override void Start()
        {
            base.Start();
            index = UnityEngine.Random.Range(0, actions.Length);
            actions[index].SetActor(target);
            actions[index].Start();
        }

        public override void StepTimer(float dt)
        {
            dt *= timeScale;
            if (actions[index].running)
                actions[index].StepTimer(dt);
            if (!actions[index].running)
            {
                Stop();
                dtr = actions[index].dtr;
            }
        }

        /// <summary>
        /// This method is called after the interval action is stopped.
        /// </summary>
        public override void Stop()
        {
            base.Stop();
            actions[index].Stop();
        }
    }
}