namespace OpenApogee.Models {
    public class PhysicsRefrenceTime {
        private double _timeDelta;
        private double _currentTime;

        public PhysicsRefrenceTime(double timeDelta) {
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