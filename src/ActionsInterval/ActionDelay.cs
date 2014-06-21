using System;
using System.Collections.Generic;
using UnityEngine;

namespace coa4u
{
    /// <summary>
    /// Delays the action for the given amount of seconds.
    /// </summary>
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

        /// <summary>
        /// This method is called at the action start.
        /// </summary>
        public override void start()
        {
            base.start();
            if (durationMax != null)
            {
                duration = UnityEngine.Random.Range(durationMin, durationMax);
            }
        }
    }
}