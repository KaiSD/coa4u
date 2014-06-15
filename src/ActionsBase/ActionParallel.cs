using System;
using System.Collections.Generic;
using UnityEngine;

class ActionParallel : ActionInterval
{
    protected Action[] actions;

    public ActionParallel(Action action1, Action action2)
        : base(0)
    {
        actions = new Action[] {action1, action2};
    }

    public ActionParallel(Action[] actionsList)
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
            aList[i] = actions[i].reverse();
        }
        return new ActionSequence(aList);
    }

    public override void start()
    {
        base.start();
        for (int i = 0; i < actions.Length; i++)
        {
            actions[i].setActor(target);
            actions[i].start();
        }
    }

    public override void step(float dt)
    {
        dt *= timeScale;
        for (int i = 0; i < actions.Length; i++)
        {
            if (actions[i].isRunning())
                actions[i].step(dt);
        }
        bool canStopNow = true;
        float dtrdata = 0;
        for (int i = 0; i < actions.Length; i++)
        {
            if (actions[i].isRunning())
            {
                canStopNow = false;
                dtrdata = Math.Max(actions[i].dtr, dtrdata);
            }
        }
        if (canStopNow)
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