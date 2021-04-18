﻿using System;

namespace Temporal.Net.Common.Helpers
{
    /// <summary>
    /// Used by <see cref="{PingAsync}"/> to measure the response time.
    /// </summary>
    public sealed class Stopwatch
    {
        private long _elapsed;
        private bool _isRunning;
        private long _startTick;

        /// <summary>
        /// Gets a value indicating whether the instance is currently recording.
        /// </summary>
        public bool IsRunning
        {
            get { return _isRunning; }
        }

        /// <summary>
        /// Gets the Elapsed time as a Timespan.
        /// </summary>
        public TimeSpan Elapsed
        {
            get { return TimeSpan.FromMilliseconds(ElapsedMilliseconds); }
        }

        /// <summary>
        /// Gets the Elapsed time as the total number of milliseconds.
        /// </summary>
        public long ElapsedMilliseconds
        {
            get { return GetCurrentElapsedTicks() / TimeSpan.TicksPerMillisecond; }
        }

        /// <summary>
        /// Gets the Elapsed time as the total number of ticks (which is faked
        /// as Silverlight doesn't have a way to get at the actual "Ticks")
        /// </summary>
        public long ElapsedTicks
        {
            get { return GetCurrentElapsedTicks(); }
        }

        /// <summary>
        /// Creates a new instance of the class and starts the watch immediately.
        /// </summary>
        /// <returns>An instance of Stopwatch, running.</returns>
        public static Stopwatch StartNew()
        {
            var sw = new Stopwatch();
            sw.Start();
            return sw;
        }

        /// <summary>
        /// Completely resets and deactivates the timer.
        /// </summary>
        public void Reset()
        {
            _elapsed = 0;
            _isRunning = false;
            _startTick = 0;
        }

        /// <summary>
        /// Begins the timer.
        /// </summary>
        public void Start()
        {
            if (!_isRunning)
            {
                _startTick = GetCurrentTicks();
                _isRunning = true;
            }
        }

        /// <summary>
        /// Stops the current timer.
        /// </summary>
        public void Stop()
        {
            if (_isRunning)
            {
                _elapsed += GetCurrentTicks() - _startTick;
                _isRunning = false;
            }
        }

        private long GetCurrentElapsedTicks()
        {
            return _elapsed + (IsRunning ? (GetCurrentTicks() - _startTick) : 0);
        }

        private long GetCurrentTicks()
        {
            // TickCount: Gets the number of milliseconds elapsed since the system started.
            return Environment.TickCount * TimeSpan.TicksPerMillisecond;
        }
    }
}