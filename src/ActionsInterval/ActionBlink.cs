using System;
using System.Collections.Generic;
using UnityEngine;

class ActionBlink : ActionRepeat
{
    protected bool randomDelay;
    protected ActionDelay delay = new ActionDelay(0);
    protected Action[] blinkSeq;

    public ActionBlink(int tgtBlinks, float tgtDuration)
        : base(null, tgtBlinks)
    {
        duration = tgtDuration;
        count = (tgtBlinks) * 2;
        blinkSeq = new Action[]
        {
            new ActionToggleVisibility(),
            new ActionDelay(tgtDuration / tgtBlinks)
        };
        action = new ActionSequence(blinkSeq);
    }

    public override Action clone()
    {
        return new ActionBlink(count / 2 - 1, duration);
    }

    public override Action reverse()
    {
        return new ActionBlink(count / 2 - 1, duration);
    }
}