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
        target.gameObject.transform.Rotate(Vector3.up, tgt.y);
        target.gameObject.transform.Rotate(Vector3.right, tgt.x);
        target.gameObject.transform.Rotate(Vector3.forward, tgt.z);
    }
}