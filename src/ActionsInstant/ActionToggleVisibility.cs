using System;
using System.Collections.Generic;
using UnityEngine;

class ActionToggleVisibility : Action
{

    public ActionToggleVisibility()
        : base()
    {
    }

    public override void start()
    {
        base.start();
        target.gameObject.renderer.enabled = !target.gameObject.renderer.enabled;
    }
}