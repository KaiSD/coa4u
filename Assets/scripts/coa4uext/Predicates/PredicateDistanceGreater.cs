using UnityEngine;
using System.Collections.Generic;
using System.Collections;

namespace coa4u
{
    public class PredicateDistanceGreater : Predicate
    {
        protected CalcerVector first;
        protected CalcerVector second;
        protected float distance;

        public PredicateDistanceGreater(CalcerVector one, CalcerVector other, float dist)
            : base()
        {
            first = one;
            second = other;
            distance = dist;
        }

        public override bool check()
        {
            if (Vector3.Distance(first.value, second.value) > distance)
                return true;
            else
                return false;
        }
    }
}