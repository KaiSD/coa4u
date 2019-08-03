using System;
using System.Collections.Generic;
using UnityEngine;

namespace coa4u
{
    /// <summary>
    /// Creates the and starts the given action instance at Start. If you're using calcers for parameters, they will be also calculated at start.
    /// </summary>
    class ActionHolder<T> : ActionInstant
        where T : ActionInstant
    {
        protected T action;
        protected object[] args;

        public ActionHolder(params object[] args) : base()
        {
            this.args = args;
        }

        public override void Start()
        {
            if (target == null)
                throw new Exception("Can start the action only after it's atached to the actor");
            object[] nargs = new object[args.Length];
            for (int i = 0; i < args.Length; i++)
            {
                if (args[i] is CalcerFloat)
                {
                    nargs[i] = ((CalcerFloat)args[i]).value;
                }
                else if (args[i] is CalcerVector)
                {
                    nargs[i] = ((CalcerVector)args[i]).value;
                }
                else
                {
                    nargs[i] = args[i];
                }
            }

            action = (T)Activator.CreateInstance(typeof(T), nargs);
            action.SetActor(target);
            action.locks = locks;
            action.Start();
            duration = action.duration;
            if (action.running)
                running = true;
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

        public override void Stop()
        {
            if (target == null)
                throw new Exception("Can stop the action only after it's atached to the actor");
            if (action.running)
                action.Stop();
            running = false;
        }

        public override ActionInstant Clone()
        {
            return new ActionHolder<T>(args);
        }
    }
}
