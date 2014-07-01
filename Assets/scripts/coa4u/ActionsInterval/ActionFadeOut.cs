using System;
using System.Collections.Generic;
using UnityEngine;

namespace coa4u
{
    /// <summary>
    /// Fades out the target. The tartet shaders should support transparency in order to use this action.
    /// </summary>
    class ActionFadeOut : ActionFadeTo
    {

        public ActionFadeOut(float targetDuration)
            : base(0, targetDuration)
        {
        }

        public override ActionInstant Clone()
        {
            return new ActionFadeOut(duration);
        }

        public override ActionInstant Reverse()
        {
            return new ActionFadeIn(duration);
        }
    }
}