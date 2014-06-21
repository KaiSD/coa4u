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

        public ActionFadeOut(float tgtDuration)
            : base(0, tgtDuration)
        {
        }

        /// <summary>
        /// Returns a copy of the action.
        /// </summary>
        public override ActionInstant clone()
        {
            return new ActionFadeOut(duration);
        }

        /// <summary>
        /// Returns the reversed version of the action, if it is possible.
        /// </summary>
        public override ActionInstant reverse()
        {
            return new ActionFadeIn(duration);
        }
    }
}