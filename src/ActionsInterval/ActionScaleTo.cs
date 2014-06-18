using System;
using System.Collections.Generic;
using UnityEngine;

class ActionScaleTo : ActionInterval
{
    protected Vector3 value;
    protected Vector3 path;

    public ActionScaleTo(Vector3 tgtValue, float tgtDuration)
        : base(tgtDuration)
    {
        value = tgtValue;
    }

    public override Action clone()
    {
        return new ActionScaleTo(value, duration);
    }

    public override void start()
    {
        base.start();
        path = value - transform.localScale;
    }

    public override void stepInterval(float dt)
    {
        float d = dt / duration;
        Vector3 tgt = path * d;
        transform.localScale += tgt;
    }

    public override void stop()
    {
        base.stop();
    }
}