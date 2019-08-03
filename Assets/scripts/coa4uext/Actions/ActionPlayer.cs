using System;
using System.Collections.Generic;
using UnityEngine;

namespace coa4u
{
    /// <summary>
    /// Plays the action on another actor;
    /// </summary>
    class ActionPlayer : ActionInterval
    {
        protected ActionInstant action;
        protected Actor actor;

        public ActionPlayer(ActionInstant targetAction, Actor targetActor)
            : base(0)
        {
            action = targetAction;
            actor = targetActor;
        }

        public override ActionInstant Clone()
        {
            return new ActionPlayer(action, actor);
        }

        public override void Start()
        {
            base.Start();
            actor.AttachAction(action);
            if (!action.running)
                running = false;
        }

        public override void StepTimer(float dt)
        {
            if (target == null)
                throw new Exception("Can update the action only after it's atached to the actor");
            action.StepTimer(dt);
            if (!action.running)
            {
                dtr = action.dtr;
                Stop();
            }
        }

        public override void Step(float dt)
        {
            if (!action.running)
                running = false;
        }
    }
}
