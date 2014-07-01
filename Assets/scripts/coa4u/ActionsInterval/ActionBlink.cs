using System;
using System.Collections.Generic;
using UnityEngine;

namespace coa4u
{
    /// <summary>
    /// Blinks the target.
    /// </summary>
    class ActionBlink : ActionRepeat
    {
        protected bool randomDelay;
        protected ActionDelay delay = new ActionDelay(0);
        protected ActionInstant[] blinkSeq;
        protected float durationMin;
        protected float durationMax;

        public ActionBlink(int targetBlinks, float targetDuration)
            : base(null, 0)
        {
            durationMin = targetDuration;
            durationMax = targetDuration;
            count = (targetBlinks) * 2;
            blinkSeq = new ActionInstant[]
        {
            new ActionToggleVisibility(),
            new ActionDelay(targetDuration / targetBlinks)
        };
            action = new ActionSequence(blinkSeq);
        }

        public ActionBlink(int targetBlinks, float targetDurationMin, float targetDurationMax)
            : base(null, 0)
        {
            durationMin = targetDurationMin;
            durationMax = targetDurationMax;
            count = (targetBlinks) * 2;
            blinkSeq = new ActionInstant[]
        {
            new ActionToggleVisibility(),
            new ActionDelay(targetDurationMin / targetBlinks, targetDurationMax / targetBlinks)
        };
            action = new ActionSequence(blinkSeq);
        }

        public override ActionInstant Clone()
        {
            return new ActionBlink(count / 2 - 1, durationMin, durationMax);
        }

        public override ActionInstant Reverse()
        {
            return new ActionBlink(count / 2 - 1, durationMin, durationMax);
        }
    }
}