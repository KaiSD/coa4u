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

        public ActionFadeIn(float tgtDuration)
            : base(1, tgtDuration)
        {
        }

        /// <summary>
        /// Returns a copy of the action.
        /// </summary>
        public override ActionInstant clone()
        {
            return new ActionFadeIn(duration);
        }

        /// <summary>
        /// Returns the reversed version of the action, if it is possible.
        /// </summary>
        public override ActionInstant reverse()
        {
            return new ActionFadeOut(duration);
        }
    }
}