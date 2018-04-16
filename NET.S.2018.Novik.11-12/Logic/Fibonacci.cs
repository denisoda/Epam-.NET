using System;
using System.Collections.Generic;

namespace Logic
{
    /// <summary>
    /// Provides method for generate a sequence of numbers of fibonacci.
    /// </summary>
    public class Fibonacci
    {
        /// <summary>
        /// Generates a sequence of numbers of fibonacci.
        /// </summary>
        /// <returns>A sequence of numbers of fibonacci.</returns>
        public static IEnumerable<int> GetFibonacci()
        {
            int first = 0;
            int second = 1;

            while (first <= int.MaxValue - second)
            {
                yield return first;

                var nextNumber = first + second;
                first = second;
                second = nextNumber;
            }
        }
    }
}
