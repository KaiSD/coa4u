using System;
using System.Collections.Generic;
using UnityEngine;

class ActionInterval : Action
{
    protected float timer;
    protected float timeScale;
    protected bool running;
    private float dtrdata;

    public ActionInterval(float tgtDuration)
        : base()
    {
        duration = tgtDuration;
        timeScale = 1F;
        dtr = 0;
    }

    public override Action clone()
    {
        return new ActionInterval(duration);
    }

    public override Action reverse()
    {
        throw new Exception("Can reverse only the reversable interval actions");
    }

    public override bool isRunning()
    {
        return running;
    }

    public override void start()
    {
        base.start();
        running = true;
        timer = 0F;
    }

    public override void stop()
    {
        base.stop();
        running = false;
    }

    /// <summary>
    /// Step method for interval actions. Don't override this method, when inheriting, put your code in stepInterval instead.
    /// </summary>
    public override void step(float dt)
    {
        dt *= timeScale;
        base.step(dt);
        if (timer + dt > duration)
        {
            float odt = dt;
            dt = duration - timer;
            timer += odt;
        }
        else
        {
            timer += dt;
        }
        stepInterval(dt);
        if (timer > duration)
        {
            stop();
            dtr = timer - duration;
        }
    }

    /// <summary>
    /// Step method for interval actions. Put your code here.
    /// </summary>
    public virtual void stepInterval(float dt)
    {
    }

    /// <summary>
    /// Property to get the remaining tick time after the action has ended.
    /// </summary>
    public override float dtr
    {
        get
        {
            return dtrdata;
        }

        protected set
        {
            dtrdata = value;
        }
    }

    /// <summary>
    /// Immediately changes the time scale for this action and all nested ones.
    /// </summary>
    public void setTimeScale(float ts)
    {
        timeScale = ts;
    }
}