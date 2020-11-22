using System;

namespace ValidationAttributes
{
    public class MyRangeAttribute : MyValidationAttribute
    {
        private int _min;
        private int _max;

        public MyRangeAttribute(int min, int max)
        {
            this._min = min;
            this._max = max;
        }
        public override bool IsValid(object obj)
        {
            if (!(obj is int))
            {
                throw new ArgumentException();
            }

            int valueAsInt = (int)obj;

            if (valueAsInt >= _min && valueAsInt <= _max)
            {
                return true;
            }

            return false;
        }
    }
}
