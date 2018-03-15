//-----------------------------------------------------------------------
// <copyright file="Task3.cs" company="Epam training">
//     Copyright (c) Epam training. All rights reserved.
// </copyright>
// <author>Novik Ilya</author>
//-----------------------------------------------------------------------
namespace Tasks
{
    using System;
    using System.Diagnostics;

    /// <summary>
    /// Implementation task 3
    /// </summary>
    public class Task3
    {
        /// <summary>
        /// Return time lead of method Tasks.Task2.FindNextBiggerNumber
        /// </summary>
        /// <param name="initialNumber">Number.</param>
        /// <returns>Object of type Stopwatch</returns>
        public static Stopwatch GetLeadTimeFindNextBiggerNumber(int initialNumber)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            Task2.FindNextBiggerNumber(initialNumber);
            sw.Stop();
            return sw;
        }
    }
}
