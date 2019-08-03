using System;
using System.Collections.Generic;
using UnityEngine;

namespace coa4u
{
    public class CalcerVector : Calcer<Vector3>
    {
        private Vector3 internalValue;
        private int dimensions;

        public CalcerVector()
        {
        }

        public CalcerVector(Vector3 value)
        {
            internalValue = value;
            dimensions = 3;
        }

        public CalcerVector(Vector2 value)
        {
            internalValue = value;
            dimensions = 2;
        }

        public override Vector3 value
        {
            get
            {
                switch (dimensions)
                {
                    case 3:
                        return (Vector3)internalValue;
                    case 2:
                        return (Vector2)internalValue;
                    default:
                        return internalValue;
                }
                
            }
        }

        public static implicit operator CalcerVector(Vector3 val)
        {
            return new CalcerVector(val);
        }

        public static implicit operator CalcerVector(Vector2 val)
        {
            return new CalcerVector(val);
        }

        public static implicit operator Vector3(CalcerVector calc)
        {
            return calc.value;
        }

        public static CalcerVector operator +(CalcerVector first, CalcerVector second)
        {
            return new CalcerVectorCalc(first, second, CalcerVectorCalc.Operation.Add);
        }

        public static CalcerVector operator -(CalcerVector first, CalcerVector second)
        {
            return new CalcerVectorCalc(first, second, CalcerVectorCalc.Operation.Sub);
        }
    }
}