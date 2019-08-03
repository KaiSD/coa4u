using System;
using System.Collections.Generic;
using UnityEngine;

namespace coa4u
{
    public abstract class Calcer
    {
    }

    public abstract class Calcer<T> : Calcer
    {
        public abstract T value {get;}
    }
}
