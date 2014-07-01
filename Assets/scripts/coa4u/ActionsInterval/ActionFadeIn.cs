using System;
using System.Collections.Generic;
using UnityEngine;

namespace coa4u
{
    /// <summary>
    /// Fades in the target. The tartet shaders should support transparency in order to use this action.
    /// </summary>
    class ActionFadeIn : ActionFadeTo
    {

        public ActionFadeIn(float targetDuration)
            : base(1, targetDuration)
        {
        }

        public override ActionInstant Clone()
        {
            return new ActionFadeIn(duration);
        }

        public override ActionInstant Reverse()
        {
            return new ActionFadeOut(duration);
        }
    }
}