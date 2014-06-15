using System;
using System.Collections.Generic;
using UnityEngine;

class ActionDelay : ActionInterval
{
    protected float durationMin;
    protected float durationMax;

    public ActionDelay(float tgtDuration)
        : base(tgtDuration)
    {
        durationMin = tgtDuration;
        durationMax = tgtDuration;
    }

    public ActionDelay(float tgtDuration, float tgtDurationMax)
        : base(tgtDuration)
    {
        durationMin = tgtDuration;
        durationMax = tgtDurationMax;
    }

    public override void start()
    {
        base.start();
        if (durationMax != null)
        {
            duration = UnityEngine.Random.Range(durationMin, durationMax);
        }
    }
}