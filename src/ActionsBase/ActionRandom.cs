using System;
using System.Collections.Generic;
using UnityEngine;

class ActionRandom : ActionInterval
{

    protected Action[] actions;
    protected int index;

    public ActionRandom(Action action1, Action action2)
        : base(0)
    {
        actions = new Action[] {action1, action2};
    }

    public ActionRandom(Action[] actionsList)
        : base(0)
    {
        actions = actionsList;

    }

    public override Action clone()
    {
        Action[] aList = new Action[actions.Length];
        for (int i = 0; i < actions.Length; i++)
        {
            aList[i] = actions[i].clone();
        }
        return new ActionRandom(aList);
    }

    public override Action reverse()
    {
        Action[] aList = new Action[actions.Length];
        for (int i = 0; i < actions.Length; i++)
        {
            aList[i] = actions[i].reverse();
        }
        return new ActionRandom(aList);
    }

    public override void start()
    {
        base.start();
        index = UnityEngine.Random.Range(0, actions.Length);
        actions[index].setActor(target);
        actions[index].start();
    }

    public override void step(float dt)
    {
        dt *= timeScale;
        if (actions[index].isRunning())
            actions[index].step(dt);
        if (!actions[index].isRunning())
        {
            stop();
            dtr = actions[index].dtr;
        }
    }

    public override void stop()
    {
        base.stop();
        actions[index].stop();
    }
}