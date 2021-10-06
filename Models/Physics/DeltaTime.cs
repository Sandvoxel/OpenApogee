using System;
using System.Diagnostics;
using JetBrains.Annotations;

namespace OpenApogee.Models.Physics {
    public class DeltaTime {
        private Stopwatch _stopwatch;

        private double lastTime;

        public DeltaTime() {
            _stopwatch = Stopwatch.StartNew();
            lastTime = _stopwatch.ElapsedMilliseconds;
        }
        /// <summary>
        /// Gets TimeSpan from running delta time clock
        /// </summary>
        /// <returns><see cref="TimeSpan"/> from stopwatch</returns>
        public TimeSpan GetCurrentTime() {
            return _stopwatch.Elapsed;
        }

        /// <summary>
        /// Give time between last call and now
        /// </summary>
        /// <returns>Time between last call and now</returns>
        public double GetDeltaTime() {
            double deltaTime = _stopwatch.ElapsedMilliseconds - lastTime;
            lastTime = _stopwatch.ElapsedMilliseconds;
            return deltaTime / 30;
        }

        public void Deconstruct([NotNull] out Stopwatch stopwatch) {
            _stopwatch.Stop();
            stopwatch = _stopwatch;
        }
    }
}