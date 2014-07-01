using System;
using System.Collections.Generic;
using UnityEngine;

namespace coa4u
{
    /// <summary>
    /// The holder class for the Methods Caching. Use MethodHolder<T> if your method requires the argument of type T.
    /// </summary>
    public class MethodHolder
    {
        protected Action method;
        protected string methodName;

        public MethodHolder()
        {
        }

        public MethodHolder(Action targetMethod)
        {
            method = targetMethod;
            methodName = targetMethod.Method.Name;
        }

        public virtual void Run(object param = null)
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

    /// <summary>
    /// The holder class for the Methods Caching. Use MethodHolder<T> if your method requires the argument of type T.
    /// </summary>
    public class MethodHolder<T> : MethodHolder
    {
        protected Action<T> methodParam;

        public MethodHolder(Action<T> targetMethod)
        {
            methodParam = targetMethod;
            methodName = targetMethod.Method.Name;
        }

        public override void Run(object param)
        {
            if (methodParam != null)
                methodParam.Invoke((T)param);
        }
    }
}