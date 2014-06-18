using System;
using System.Collections.Generic;
using UnityEngine;

class ActionMoveBy : ActionInterval
{
    protected Vector3 delta;

    public ActionMoveBy(Vector3 tgtDelta, float tgtDuration)
        : base(tgtDuration)
    {
        delta = tgtDelta;
    }

    public override Action clone()
    {
        return new ActionMoveBy(delta, duration);
    }

    public override Action reverse()
    {
        return new ActionMoveBy(delta * -1F, duration);
    }

    public override void stepInterval(float dt)
    {
        float d = dt / duration;
        Vector3 tgt = delta * d;
        transform.Translate(tgt, Space.World);
    }
}