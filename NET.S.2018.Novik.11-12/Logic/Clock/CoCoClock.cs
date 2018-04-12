using System;
using System.Threading;
using System.Threading.Tasks;

namespace Logic.Clock
{
    /// <summary>
    /// Provides methods for work with timer.
    /// </summary>
    public class CoCoClock
    {
        #region Private fields

        private bool isWork;

        #endregion

        #region Constuctors

        /// <summary>
        /// Initializes a new instance of the <see cref="CoCoClock"/> class.
        /// </summary>
        public CoCoClock()
        {
        }

        #endregion

        #region Events

        public event EventHandler<RingEventArgs> Ring;

        #endregion

        #region Public methods

        /// <summary>
        /// Running this clock.
        /// </summary>
        /// <param name="time">The instance of <see cref="TimeSpan"/> to countdown the time.</param>
        /// <param name="message">The string that will pass to all of subscribe <see cref="Ring"/>.</param>
        public void Set(TimeSpan time, string message = "co-coooo-cooooooo")
        {
            this.Start(time);
            this.OnRing(new RingEventArgs(time, message));
        }

        #endregion

        #region Protected methods

        protected virtual void OnRing(RingEventArgs ringEventArgs)
        {
            this.Ring?.Invoke(this, ringEventArgs);
        }

        #endregion

        #region Private methods

        private void Start(TimeSpan time)
        {
            this.isWork = true;

            int milisecond = time.Milliseconds;
            Thread.Sleep(milisecond);

            this.isWork = false;
        }

        #endregion
    }
}
