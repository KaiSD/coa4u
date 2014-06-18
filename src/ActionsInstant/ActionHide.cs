using System;
using System.Collections.Generic;
using UnityEngine;

class ActionHide : Action
{

    public ActionHide()
        : base()
    {
    }

    public override Action clone()
    {
        return new ActionHide();
    }

    public override void start()
    {
        base.start();
        renderer.enabled = false;
    }
}