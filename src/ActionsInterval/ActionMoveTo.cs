using System;
using System.Collections.Generic;
using UnityEngine;

class ActionMoveTo : ActionInterval
{
    protected Vector3 value;
    protected Vector3 path;

    public ActionMoveTo(Vector3 tgtValue, float tgtDuration)
        : base(tgtDuration)
    {
        value = tgtValue;
    }


    public override Action clone()
    {
        return new ActionMoveBy(value, duration);
    }

    public override void start()
    {
        base.start();
        path = value - target.gameObject.transform.position;
    }

    public override void stepInterval(float dt)
    {
        float d = dt / duration;
        Vector3 tgt = path * d;
        target.gameObject.transform.Translate(tgt, Space.World);
    }
}