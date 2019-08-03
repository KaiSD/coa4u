using System;
using System.Collections.Generic;
using UnityEngine;
using coa4u;

[System.Serializable]
public class SeqTest : SeqActor
{
    public Actor enemy;
    Vector3 startPosition;

    void Start()
    {
        startPosition = transformCached.position;
        CalcerVector endPosition = new CalcerPosition(enemy) + new CalcerVector(new Vector3(-2F, transformCached.position.y, 0F));

        ActionInstant stateDefault = new ActionSequence(
            new ActionInstant[]
            {
                new ActionDelay(3),
                new ActionSwitchState(1)
            });
        
        ActionInstant stateRoam = new ActionSequence(
            new ActionInstant[] {
                new ActionHolder<ActionSetDirection>(new CalcerPosition(enemy)),
                new ActionHolder<ActionJumpTo>(endPosition, 5, 1, 1),
				new ActionDelay(0.5F),
                new ActionHolder<ActionMoveTo>(new CalcerPosition(enemy), 0.1F),
				new ActionHolder<ActionMoveTo>(endPosition, 0.1F),
				new ActionDelay(0.5F),
                new ActionJumpTo(startPosition, 5, 1, 1),
                new ActionSwitchState(0)
            });
        
        states = new State[]
        {
            new State(stateDefault, "wait"),
            new State(stateRoam, "attack")
        };

        SetState(0);
    }
}
