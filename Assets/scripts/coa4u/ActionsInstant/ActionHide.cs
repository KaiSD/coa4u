using System;
using System.Collections.Generic;
using UnityEngine;

namespace coa4u
{
    /// <summary>
    /// Instantly hides the target. This action does not require the transparency support in shaders.
    /// </summary>
    class ActionHide : ActionInstant
    {

        public ActionHide()
            : base()
        {
        }

        public override ActionInstant Clone()
        {
            return new ActionHide();
        }

        public override ActionInstant Reverse()
        {
            return new ActionShow();
        }

        public override void Start()
        {
            base.Start();
            renderer.enabled = false;
        }
    }
}