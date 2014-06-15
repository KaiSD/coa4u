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
            path[i] = value[i] - target.gameObject.transform.rotation.eulerAngles[i];
        }
        target.gameObject.transform.Rotate(Vector3.up, path.y);
        target.gameObject.transform.Rotate(Vector3.right, path.x);
        target.gameObject.transform.Rotate(Vector3.forward, path.z);
    }
}