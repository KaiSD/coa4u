using UnityEngine;
using System.Collections.Generic;
using System.Collections;

namespace coa4u
{
    public class State
    {
        public readonly ActionInstant action;
        public readonly Predicate trigger;
        public readonly string name;

        public State(ActionInstant targetAction, string targetName = "")
        {
            action = targetAction;
            name = targetName;
        }

        public State(Predicate targetTrigger, ActionInstant targetAction, string targetName = "")
        {
            trigger = targetTrigger;
            action = targetAction;
            name = targetName;
        }
    }
}