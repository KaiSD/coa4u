using System;
using System.Collections.Generic;
using UnityEngine;

class ActionScaleBy : ActionInterval
{
    protected Vector3 delta;
    protected Vector3 path;

    public ActionScaleBy(Vector3 tgtDelta, float tgtDuration)
        : base(tgtDuration)
    {
        delta = tgtDelta;
    }

    public override Action clone()
    {
        return new ActionScaleBy(delta, duration);
    }

    public override Action reverse()
    {
        return new ActionScaleBy(delta * -1F, duration);
    }

    public override void start()
    {
        base.start();
        Vector3 scale = transform.localScale;
        scale.x *= delta.x;
        scale.y *= delta.y;
        scale.z *= delta.z;
        path = scale - transform.localScale;
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