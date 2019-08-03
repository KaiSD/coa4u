using System;
using System.Collections.Generic;
using UnityEngine;

namespace coa4u
{
    public class CalcerVectorCalc : CalcerVector
    {
        public enum Operation
        {
            Add,
            Sub
        }

        private Operation operation;
        private CalcerVector first;
        private CalcerVector second;

        public CalcerVectorCalc(CalcerVector first, CalcerVector second, Operation operation = Operation.Add)
        {
            this.first = first;
            this.second = second;
            this.operation = operation;
        }

        public override Vector3 value
        {
            get
            {
                switch (operation)
                {
                    case Operation.Add:
                        return first.value + second.value;
                    case Operation.Sub:
                        return first.value - second.value;
                    default:
                        throw new Exception("Operation not found.");
                }
            }
        }
    }
}
