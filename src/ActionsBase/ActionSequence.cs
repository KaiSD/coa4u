using System;
using System.Collections.Generic;
using UnityEngine;

class ActionSequence : ActionInterval
{
    protected Action[] actions;
    protected int index;

    public ActionSequence(Action action1, Action action2)
        : base(0)
    {
        actions = new Action[] {action1, action2};
    }

    public ActionSequence(Action[] actionsList)
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
        return new ActionSequence(aList);
    }

    public override Action reverse()
    {
        Action[] aList = new Action[actions.Length];
        for (int i = 0; i < actions.Length; i++)
        {
            aList[actions.Length - 1 - i] = actions[i].reverse();
        }
        return new ActionSequence(aList);
    }

    public override void start()
    {
        base.start();
        index = 0;
        actions[0].setActor(target);
        actions[0].start();
        while (!actions[index].isRunning() && index < actions.Length)
        {
            index += 1;
            actions[index].setActor(target);
            actions[index].start();
        }
    }

    public override void step(float dt)
    {
        dt *= timeScale;
        float dtrdata = 0;
        if (actions[index].isRunning())
        {
            actions[index].step(dt);
            if (!actions[index].isRunning())
                dtrdata = actions[index].dtr;
        }
        while (!actions[index].isRunning() && index < actions.Length - 1)
        {
            index += 1;
            actions[index].setActor(target);
            actions[index].start();
            if (actions[index].isRunning() && dtrdata > 0)
                actions[index].step(dtrdata);
        }
        if (!actions[index].isRunning())
        {
            stop();
            dtr = dtrdata;
        }
    }

    public override void stop()
    {
        base.stop();
        for (int i = 0; i < actions.Length; i++)
        {
            actions[i].stop();
        }
    }
}