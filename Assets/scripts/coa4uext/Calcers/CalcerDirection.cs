using System;
using System.Collections.Generic;
using UnityEngine;

namespace coa4u
{
    public class CalcerDirection : CalcerVector
    {
        Actor selfActor;
        Actor targetActor;
        Transform selfTransform;
        Transform targetTransform;

        public CalcerDirection(Actor self, Actor target)
            : base()
        {
            selfActor = self;
            targetActor = target;
        }

        public CalcerDirection(Transform self, Transform target)
            : base()
        {
            selfTransform = self;
            targetTransform = target;
        }

        public override Vector3 value
        {
            get
            {
                if (targetTransform != null)
                {
                    return Quaternion.LookRotation(targetTransform.position - selfTransform.position).eulerAngles;
                }
                else
                {
                    return Quaternion.LookRotation(targetActor.transformCached.position - selfActor.transformCached.position).eulerAngles; 
                }
            }
            
        }
    }
}