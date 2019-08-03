using System;
using System.Collections.Generic;
using UnityEngine;

namespace coa4u
{
    public class CalcerFloat : Calcer<float>
    {
        private float internalValue;

        public CalcerFloat()
        {
        }

        public CalcerFloat(float value)
        {
            internalValue = value;
        }

        public CalcerFloat(int value)
        {
            internalValue = (float)value;
        }

        public CalcerFloat(double value)
        {
            internalValue = (float)value;
        }

        public override float value
        {
            get
            {
                return internalValue;
            }
        }

        public static implicit operator CalcerFloat(float val)
        {
            return new CalcerFloat(val);
        }

        public static implicit operator float(CalcerFloat calc)
        {
            return calc.value;
        }

        public static CalcerFloat operator +(CalcerFloat first, CalcerFloat second)
        {
            return new CalcerFloatCalc(first, second, CalcerFloatCalc.Operation.Add);
        }

        public static CalcerFloat operator -(CalcerFloat first, CalcerFloat second)
        {
            return new CalcerFloatCalc(first, second, CalcerFloatCalc.Operation.Sub);
        }

        public static CalcerFloat operator *(CalcerFloat first, CalcerFloat second)
        {
            return new CalcerFloatCalc(first, second, CalcerFloatCalc.Operation.Mul);
        }

        public static CalcerFloat operator /(CalcerFloat first, CalcerFloat second)
        {
            return new CalcerFloatCalc(first, second, CalcerFloatCalc.Operation.Div);
        }
    }
}