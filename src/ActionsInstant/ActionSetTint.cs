using System;
using System.Collections.Generic;
using UnityEngine;

class ActionSetTint : Action
{
    public Vector4 color;
    protected const float coeff = 1F / 255F;

    public ActionSetTint(Vector4 tgtColor)
        : base()
    {
        color = tgtColor * coeff;
    }

    public override void start()
    {
        base.start();
        target.gameObject.renderer.material.color = new Color(color[0], color[1], color[2], color[3]);
    }
}