using System;
using System.Collections.Generic;
using UnityEngine;

class ActionFadeBy : ActionInterval
{
    public float delta;

    public ActionFadeBy(float tgtDelta, float tgtDuration)
        : base(tgtDuration)
    {
        delta = tgtDelta;
    }

    public override Action clone()
    {
        return new ActionFadeBy(delta, duration);
    }

    public override Action reverse()
    {
        return new ActionFadeBy(-delta, duration);
    }

    public override void start()
    {
        base.start();
    }

    public override void stepInterval(float dt)
    {
        float d = dt / duration;
        Color tgtColor = target.gameObject.renderer.material.color;
        tgtColor[3] += delta * d;
        target.gameObject.renderer.material.color = tgtColor;
    }
}