using UnityEngine;
using System.Collections.Generic;
using System.Collections;

namespace coa4u
{
    public class PredicateFalse : Predicate
    {
        public override bool check()
        {
            return false;
        }
    }
}