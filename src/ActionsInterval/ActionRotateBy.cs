using System;
using System.Collections.Generic;
using UnityEngine;

class ActionRotateBy : ActionInterval
{
    protected Vector3 delta;

    public ActionRotateBy(Vector3 tgtDelta, float tgtDuration)
        : base(tgtDuration)
    {
        delta = tgtDelta;
    }

    public ActionRotateBy(float angle, float tgtDuration)
        : this(new Vector3(0, 0, angle), tgtDuration)
    {
        is2d = true;
    }

    public override Action clone()
    {
        return new ActionRotateBy(delta, duration);
    }

    public override Action reverse()
    {
        return new ActionRotateBy(delta * -1F, duration);
    }

    public override void stepInterval(float dt)
    {
        float d = dt / duration;
        Vector3 tgt = delta * d;
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + tgt);
    }
}