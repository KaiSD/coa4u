using System;
using System.Collections.Generic;
using UnityEngine;

class ActionSetPlace : Action
{
    protected Vector3 place;

    public ActionSetPlace(Vector3 tgtPlace)
        : base()
    {
        place = tgtPlace;
    }

    public override Action clone()
    {
        return new ActionSetPlace(place);
    }

    public override void start()
    {
        base.start();
        transform.position = place;
    }
}