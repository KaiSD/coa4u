using System;
using System.Collections.Generic;
using UnityEngine;

class ActionBlink : ActionRepeat
{
    protected bool randomDelay;
    protected ActionDelay delay = new ActionDelay(0);
    protected Action[] blinkSeq;
    protected float durationMin;
    protected float durationMax;

    public ActionBlink(int tgtBlinks, float tgtDuration)
        : base(null, 0)
    {
        durationMin = tgtDuration;
        durationMax = tgtDuration;
        count = (tgtBlinks) * 2;
        blinkSeq = new Action[]
        {
            new ActionToggleVisibility(),
            new ActionDelay(tgtDuration / tgtBlinks)
        };
        action = new ActionSequence(blinkSeq);
    }

    public ActionBlink(int tgtBlinks, float tgtDurationMin, float tgtDurationMax)
        : base(null, 0)
    {
        durationMin = tgtDurationMin;
        durationMax = tgtDurationMax;
        count = (tgtBlinks) * 2;
        blinkSeq = new Action[]
        {
            new ActionToggleVisibility(),
            new ActionDelay(tgtDurationMin / tgtBlinks, tgtDurationMax / tgtBlinks)
        };
        action = new ActionSequence(blinkSeq);
    }

    public override Action clone()
    {
        return new ActionBlink(count / 2 - 1, durationMin, durationMax);
    }

    public override Action reverse()
    {
        return new ActionBlink(count / 2 - 1, durationMin, durationMax);
    }
}