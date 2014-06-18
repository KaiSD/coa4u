using System;
using System.Collections.Generic;
using UnityEngine;

class ActionShow : Action
{

    public ActionShow()
        : base()
    {
    }

    public override Action clone()
    {
        return new ActionShow();
    }

    public override void start()
    {
        base.start();
        renderer.enabled = true;
    }
}