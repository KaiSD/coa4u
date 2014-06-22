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
            return new ActionRandom(aList);
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
            return new ActionRandom(aList);
        }

        /// <summary>
        /// This method is called at the action start.
        /// </summary>
        public override void start()
        {
            base.start();
            index = UnityEngine.Random.Range(0, actions.Length);
            actions[index].setActor(target);
            actions[index].start();
        }

        /// <summary>
        /// This method is called every frame update.
        /// </summary>
        public override void step(float dt)
        {
            dt *= timeScale;
            if (actions[index].running)
                actions[index].step(dt);
            if (!actions[index].running)
            {
                stop();
                dtr = actions[index].dtr;
            }
        }

        /// <summary>
        /// This method is called after the interval action is stopped.
        /// </summary>
        public override void stop()
        {
            base.stop();
            actions[index].stop();
        }
    }
}