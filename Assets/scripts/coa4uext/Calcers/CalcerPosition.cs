using System;
using System.Collections.Generic;
using UnityEngine;

namespace coa4u
{
    public class CalcerPosition : CalcerVector
    {
        Actor targetActor;
        Transform targetTransform;

        public CalcerPosition(Actor target)
            : base()
        {
            this.targetActor = target;
        }

        public CalcerPosition(Transform target)
            : base()
        {
            this.targetTransform = target;
        }

        public override Vector3 value
        {
            get
            {
                if (targetTransform != null)
                    return (Vector3)targetTransform.position;
                else
                    return (Vector3)targetActor.transformCached.position;
            }
            
        }
    }
}