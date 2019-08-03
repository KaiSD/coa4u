using System;
using System.Collections.Generic;
using UnityEngine;

namespace coa4u
{
    class ActionIf : ActionInterval
    {
        protected ActionInstant action;
        protected Predicate predicate;
        protected bool started;

        public ActionIf(Predicate targetPredicate, ActionInstant targetAction)
            : base(0)
        {
            action = targetAction;
            predicate = targetPredicate;
        }

        public override ActionInstant Clone()
        {
            return new ActionIf(predicate, action);
        }

        public override ActionInstant Reverse()
        {
            return new ActionIf(predicate, action.Reverse());
        }

        public override void Start()
        {
            base.Start();
            if (predicate.check())
            {
                started = true;
                action.SetActor(target);
                action.Start();
                duration = action.duration;
            }
            else
            {
                running = false;
            }
        }

        public override void StepTimer(float dt)
        {
            if (!started)
                return;
            dt *= timeScale;
            if (action.running)
                action.StepTimer(dt);
            if (!action.running)
            {
                Stop();
                dtr = action.dtr;
            }
        }

        public override void Stop()
        {
            base.Stop();
            action.Stop();
        }
    }
}