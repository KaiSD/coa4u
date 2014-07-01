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

        public ActionDelay(float targetDuration)
            : base(targetDuration)
        {
            durationMin = targetDuration;
            durationMax = targetDuration;
        }

        public ActionDelay(float targetDuration, float targetDurationMax)
            : base(targetDuration)
        {
            durationMin = targetDuration;
            durationMax = targetDurationMax;
        }

        public override void Start()
        {
            base.Start();
            if (durationMax != null)
            {
                duration = UnityEngine.Random.Range(durationMin, durationMax);
            }
        }
    }
}