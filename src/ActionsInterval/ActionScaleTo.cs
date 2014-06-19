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

    public ActionScaleTo(Vector2 tgtValue, float tgtDuration)
        : this((Vector3) tgtValue, tgtDuration)
    {
        is2d = true;
    }

    public override Action clone()
    {
        return new ActionScaleTo(value, duration);
    }

    public override void start()
    {
        base.start();
        if (is2d)
            value.z = transform.localScale.z;
        path = value - transform.localScale;
    }

    public override void stepInterval(float dt)
    {
        float d = dt / duration;
        Vector3 tgt = path * d;
        transform.localScale += tgt;
    }
}