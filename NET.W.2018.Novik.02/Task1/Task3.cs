using System;
using System.Diagnostics;

namespace Tasks
{
    /// <summary>
    /// Implementation task 3
    /// </summary>
    public class Task3
    {
        #region public methods

        /// <summary>
        /// Return time lead of method <see cref="Task2.FindNextBiggerNumber(int)"/>.
        /// </summary>
        /// <param name="initialNumber">Number.</param>
        /// <returns>The object of type Stopwatch.</returns>
        public static Stopwatch GetLeadTimeFindNextBiggerNumber(int initialNumber)
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();
            Task2.FindNextBiggerNumber(initialNumber);
            timer.Stop();
            return timer;
        }

        #endregion
    }
}
