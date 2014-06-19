using System;
using System.Collections.Generic;
using UnityEngine;

class ActionSetPlace : Action
{
    protected Vector3 value;

    public ActionSetPlace(Vector3 tgtPlace)
        : base()
    {
        value = tgtPlace;
    }

    public ActionSetPlace(Vector2 tgtPlace)
        : this((Vector3) tgtPlace)
    {
        is2d = true;
    }

    public override Action clone()
    {
        return new ActionSetPlace(value);
    }

    public override void start()
    {
        base.start();
        if (is2d)
            value.z = transform.position.z;
        transform.position = value;
    }
}