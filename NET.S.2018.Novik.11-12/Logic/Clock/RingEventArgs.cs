using System;

namespace Logic.Clock
{
    /// <summary>
    /// Provides data for the <see cref="CoCoClock.Ring"/> events.
    /// </summary>
    public class RingEventArgs
    {
        public readonly TimeSpan Time;
        public readonly string Message;

        public RingEventArgs(TimeSpan time, string message)
        {
            this.Time = time;
            this.Message = message;
        }
    }
}
