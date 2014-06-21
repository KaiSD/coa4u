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

        public ActionBlink(int tgtBlinks, float tgtDuration)
            : base(null, 0)
        {
            durationMin = tgtDuration;
            durationMax = tgtDuration;
            count = (tgtBlinks) * 2;
            blinkSeq = new ActionInstant[]
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
            blinkSeq = new ActionInstant[]
        {
            new ActionToggleVisibility(),
            new ActionDelay(tgtDurationMin / tgtBlinks, tgtDurationMax / tgtBlinks)
        };
            action = new ActionSequence(blinkSeq);
        }

        /// <summary>
        /// Returns a copy of the action.
        /// </summary>
        public override ActionInstant clone()
        {
            return new ActionBlink(count / 2 - 1, durationMin, durationMax);
        }

        /// <summary>
        /// Returns the reversed version of the action, if it is possible.
        /// </summary>
        public override ActionInstant reverse()
        {
            return new ActionBlink(count / 2 - 1, durationMin, durationMax);
        }
    }
}