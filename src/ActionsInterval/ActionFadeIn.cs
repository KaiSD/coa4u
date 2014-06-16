using System;
using System.Collections.Generic;
using UnityEngine;

class ActionFadeIn : ActionFadeTo
{

    public ActionFadeIn(float tgtDuration)
        : base(1, tgtDuration)
    {
    }

    public override Action clone()
    {
        return new ActionFadeIn(duration);
    }

    public override Action reverse()
    {
        return new ActionFadeIn(duration);
    }
}