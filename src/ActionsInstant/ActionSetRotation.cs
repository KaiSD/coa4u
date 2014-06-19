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
        Vector3 path = new Vector3();
        for (int i = 0; i < 3; i++)
        {
            path[i] = value[i] - transform.rotation.eulerAngles[i];
        }
        transform.Rotate(Vector3.up, path.y);
        transform.Rotate(Vector3.right, path.x);
        transform.Rotate(Vector3.forward, path.z);
    }
}