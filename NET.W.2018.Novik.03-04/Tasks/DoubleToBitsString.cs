//-----------------------------------------------------------------------
// <copyright file="DoubleToBitsString.cs" company="Epam training">
//     Copyright (c) Epam training. All rights reserved.
// </copyright>
// <author>Novik Ilya</author>
//-----------------------------------------------------------------------

using System;

namespace Tasks
{
    /// <summary>
    /// Implementation task 1
    /// </summary>
    public static class DoubleToBitsString
    {
        #region private fields

        private const int LengthDoubleOrder = 11;
        private const int LengthDoubleMantissa = 52;
        private const int OffsetDouble = 1023;
        private const int ReverseOffsetDouble = -1022;

        #endregion // private fields

        #region public methods

        /// <summary>
        /// Converts the value of the specified double type to its equivalent
        /// binary representation by IEEE 754.
        /// </summary>
        /// <param name="value">The double value to convert.</param>
        /// <returns>The string value.</returns>
        public static string ToBitsString(this double value)
        {
            string result = string.Empty;

            int sign = GetSignBit(value);
            value = sign == 1 ? Math.Abs(value) : value;
            int order = GetOrder(value);
            int[] orderBinary = IntToBinaryArray(order, LengthDoubleOrder);
            int[] mantissaBinary = GetMantissaBinaryArray(GetMantissa(value, order));

            result = string.Concat(sign, string.Concat(orderBinary), string.Concat(mantissaBinary));
            return result;
        }

        #endregion // public methods

        #region private methods

        private static double GetMantissa(double value, int order)
        {
            if (double.IsNaN(value))
            {
                return Math.Pow(2, LengthDoubleMantissa);
            }

            order -= OffsetDouble;
            double mantissa = 0;

            if (order <= -OffsetDouble)
            {
                mantissa = value / Math.Pow(2, ReverseOffsetDouble);
            }
            else
            {
                mantissa = (value / Math.Pow(2, order)) - 1;
            }

            return mantissa;
        }

        private static int[] GetMantissaBinaryArray(double value)
        {
            int[] result = new int[LengthDoubleMantissa];
            const int positiveBit = 1;
            const int negativeBit = 0;

            for (int i = 0; i < result.Length; i++)
            {
                value *= 2;
                if (value >= 1)
                {
                    result[i] = positiveBit;
                    value -= 1;
                }
                else
                {
                    result[i] = negativeBit;
                }
            }

            return result;
        }

        private static int GetOrder(double value)
        {
            if (double.IsNaN(value))
            {
                return (int)Math.Pow(2, LengthDoubleOrder) - 1;
            }

            int order = 0;
            double fraction = (value / Math.Pow(2, order)) - 1;

            while ((fraction < 0) || (fraction >= 1))
            {
                order = fraction < 1.0 ? --order : ++order;
                fraction = (value / Math.Pow(2, order)) - 1;
            }

            order += OffsetDouble;
            order = order < 0 ? 0 : order;

            return order;
        }

        private static int GetSignBit(double value)
        {
            int bit = 0;

            if (double.IsNegativeInfinity(1.0 / value) || value < 0.0)
            {
                bit = 1;
            }

            return bit;
        }

        private static int[] IntToBinaryArray(int value, int capacity)
        {
            const int positiveBit = 1;
            const int negativeBit = 0;

            string valueStr = string.Empty;
            int[] result = new int[capacity];

            for (int i = 0; value != 0; value >>= 1, i++)
            {
                int bit = ((value & 1) == 1) ? positiveBit : negativeBit;
                result[result.Length - i - 1] = bit;
            }

            return result;
        }

        #endregion // private methods
    }
}
