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
                aList[actions.Length - 1 - i] = actions[i].reverse();
            }
            return new ActionSequence(aList);
        }

        /// <summary>
        /// This method is called at the action start.
        /// </summary>
        public override void start()
        {
            base.start();
            index = 0;
            actions[0].setActor(target);
            actions[0].start();
            while (!actions[index].running && index < actions.Length)
            {
                index += 1;
                actions[index].setActor(target);
                actions[index].start();
            }
        }

        /// <summary>
        /// This method is called every frame update.
        /// </summary>
        public override void step(float dt)
        {
            dt *= timeScale;
            float dtrdata = 0;
            if (actions[index].running)
            {
                actions[index].step(dt);
                if (!actions[index].running)
                    dtrdata = actions[index].dtr;
            }
            while (!actions[index].running && index < actions.Length - 1)
            {
                index += 1;
                actions[index].setActor(target);
                actions[index].start();
                if (actions[index].running && dtrdata > 0)
                    actions[index].step(dtrdata);
            }
            if (!actions[index].running)
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