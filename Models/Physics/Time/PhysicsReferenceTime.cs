namespace OpenApogee.Models.Physics.Time {
    /// <summary>
    /// This class is used for a fixed time step reference in physics calculations.
    /// </summary>
    public class PhysicsReferenceTime {
        private readonly double _timeDelta;
        private double _currentTime;

        public PhysicsReferenceTime(double timeDelta) {
            _timeDelta = timeDelta;
        }

        /// <summary>
        /// This method must be called to update time.
        /// </summary>
        public void UpdateTime() {
            _currentTime += _timeDelta;
        }


        public double TimeDelta => _timeDelta;
        public double CurrentTime => _currentTime;
    }
}