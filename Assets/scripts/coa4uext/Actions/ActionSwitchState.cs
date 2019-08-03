using System;
using System.Collections.Generic;
using UnityEngine;

namespace coa4u
{
    class ActionSwitchState : ActionInstant
    {
        string stateName;
        int stateIndex;

        public ActionSwitchState(int targetIndex)
            : base()
        {
            stateIndex = targetIndex;
        }

        public ActionSwitchState(string targetName)
            : base()
        {
            stateName = targetName;
        }

        public override void Start()
        {
            base.Start();
            if (!(target is SeqActor))
            {
                throw new Exception("Target is not capable of switching states.");
            }
            if (stateIndex != null)
            {
                ((SeqActor)target).SetState(stateIndex);
            }
            else
            {
                ((SeqActor)target).SetState(stateName);
            }
        }
    }
}