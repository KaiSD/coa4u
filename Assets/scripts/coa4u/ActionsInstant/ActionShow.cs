using System;
using System.Collections.Generic;
using UnityEngine;

namespace coa4u
{
    /// <summary>
    /// Instantly shows the hidden target. This action does not require the transparency support in shaders.
    /// </summary>
    class ActionShow : ActionInstant
    {

        public ActionShow()
            : base()
        {
        }

        public override ActionInstant Clone()
        {
            return new ActionShow();
        }

        public override ActionInstant Reverse()
        {
            return new ActionHide();
        }

        public override void Start()
        {
            base.Start();
            renderer.enabled = true;
        }
    }
}