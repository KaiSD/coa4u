using System;
using System.Collections.Generic;
using UnityEngine;

class ActionRepeat : ActionInterval
{
    protected ActionInterval action;
    protected int count;
    protected int counter;
    protected bool forever;

    public ActionRepeat(ActionInterval tgtAction, int tgtCount)
        : base(0)
    {
        action = tgtAction;
        count = tgtCount;
        counter = 0;
        forever = false;
    }

    public ActionRepeat(ActionInterval tgtAction)
        : base(0)
    {
        action = tgtAction;
        count = 0;
        counter = 0;
        forever = true;
    }

    public override Action clone()
    {
        return new ActionRepeat((ActionInterval) action.clone(), count);
    }

    public override Action reverse()
    {
        return new ActionRepeat((ActionInterval) action.reverse(), count);
    }

    public override void start()
    {
        base.start();
        action.setActor(target);
        action.start();
        counter = 0;
    }

    public override void step(float dt)
    {
        dt *= timeScale;
        if (action.isRunning())
        {
            action.step(dt);
        }
        if (!action.isRunning() && (forever || counter < count - 1))
        {
            float dtrdata = action.dtr;
            action.start();
            if (dtrdata > 0)
                action.step(dtrdata);
            counter += 1;
        }
        else if (!action.isRunning() && counter >= count - 1)
        {
            dtr = action.dtr;
            stop();
        }
    }
}