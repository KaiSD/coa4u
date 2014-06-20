using System;
using System.Collections.Generic;
using UnityEngine;

class ActionSetRotation : Action
{
    protected Vector3 value;

    public ActionSetRotation(Vector3 tgtValue)
        : base()
    {
        value = tgtValue;
    }

    public ActionSetRotation(float angle)
        : this(new Vector3(0, 0, angle))
    {
        is2d = true;
    }

    public override Action clone()
    {
        return new ActionSetRotation(value);
    }

    public override void start()
    {
        base.start();
        transform.rotation = Quaternion.Euler(value);

    }
}