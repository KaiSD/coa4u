using System;
using System.Collections.Generic;
using UnityEngine;

namespace coa4u
{
    public class MethodHolder
    {
        protected Action method;
        protected string methodName;

        public MethodHolder()
        {
        }

        public MethodHolder(Action tgtMethod)
        {
            method = tgtMethod;
            methodName = tgtMethod.Method.Name;
        }

        public virtual void run(object param = null)
        {
            if (method != null)
                method.Invoke();
        }

        public string name
        {
            get
            {
                return methodName;
            }
        }
    }

    public class MethodHolder<T> : MethodHolder
    {
        protected Action<T> methodParam;

        public MethodHolder(Action<T> tgtMethod)
        {
            methodParam = tgtMethod;
            methodName = tgtMethod.Method.Name;
        }

        public override void run(object param)
        {
            if (methodParam != null)
                methodParam.Invoke((T)param);
        }
    }
}