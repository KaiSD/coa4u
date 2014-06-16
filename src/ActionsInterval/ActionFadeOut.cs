using System;
using System.Collections.Generic;
using UnityEngine;

class ActionFadeOut : ActionFadeTo
{

    public ActionFadeOut(float tgtDuration)
        : base(0, tgtDuration)
    {
    }

    public override Action clone()
    {
        return new ActionFadeOut(duration);
    }

    public override Action reverse()
    {
        return new ActionFadeOut(duration);
    }
}