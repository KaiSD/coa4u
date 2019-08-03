using System;
using System.Collections.Generic;
using UnityEngine;

namespace coa4u
{
    public class CalcerFloatCalc : CalcerFloat
    {
        public enum Operation
        {
            Add,
            Sub,
            Mul,
            Div
        }

        private Operation operation;
        private CalcerFloat first;
        private CalcerFloat second;

        public CalcerFloatCalc(CalcerFloat first, CalcerFloat second, Operation operation = Operation.Add)
        {
            this.first = first;
            this.second = second;
            this.operation = operation;
        }

        public float value
        {
            get
            {
                switch (operation)
                {
                    case Operation.Add:
                        return first.value + second.value;
                    case Operation.Sub:
                        return first.value - second.value;
                    case Operation.Mul:
                        return first.value * second.value;
                    case Operation.Div:
                        return first.value / second.value;
                    default:
                        throw new Exception("Operation not found.");
                }
            }
        }
    }
}
