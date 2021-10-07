using JetBrains.Annotations;
using OpenApogee.Models.Physics.Math;
using OpenApogee.Models.Physics.Time;

namespace OpenApogee.Models.Physics {
    /// <summary>
    /// A starter class for rocket simulation.
    /// </summary>
    public class RocketObject {
        // TODO: Add rotation component and apply forces based on the angle.
        // TODO: Calculate drag on body as speed increases;


        private Vector3 _position = new();
        private Vector3 _velocity = new();
        private Vector3 _momentum = new();

        private PhysicsReferenceTime _referenceTime;

        private double _mass;
        private double _thrust;
        private double _burnTime;

        private double _apogee;
        private double _vMax;
        private bool _hasBeenSimulated;

        /// <summary>
        /// Sets up <see cref="RocketObject"/> with default params.
        /// </summary>
        /// <param name="mass">The mass of the rocket in Kilograms</param>
        /// <param name="thrust">The thrust of the rocket in Newtons</param>
        /// TODO: Change burn time to input a chart for the burn curve.
        /// <param name="burnTime">The burn time in seconds</param>
        /// <param name="timeDelta">The amount that time is stepped forward with each simulation loop Default<value>0.001</value></param>
        public RocketObject(double mass, double thrust, double burnTime, double timeDelta = 0.0001) {
            _mass = mass;
            _thrust = thrust;
            _burnTime = burnTime;
            _referenceTime = new PhysicsReferenceTime(timeDelta);
        }

        /// <summary>
        /// Runs Simulation of <see cref="RocketObject"/>.
        /// Will not run simulation if simulation data has already been computed.
        /// </summary>
        /// <param name="force">Set flag true to force simulation</param>
        /// <returns>If the simulation was run.</returns>
        public bool Simulate(bool force = false) {
            if (!force)
                if (_hasBeenSimulated)
                    return false;

            while (_position.Y > -0.1) {
                if (_referenceTime.CurrentTime < _burnTime)
                    _momentum.Y += (_thrust + _mass * Constants.GRAVITY) * _referenceTime.TimeDelta;
                else
                    _momentum.Y += _mass * Constants.GRAVITY * _referenceTime.TimeDelta;
                _velocity = _momentum / _mass;

                _position += _velocity * _referenceTime.TimeDelta;


                _apogee = _apogee < _position.Y ? _position.Y : _apogee;
                _vMax = _vMax < _velocity.Y ? _velocity.Y : _vMax;

                _referenceTime.UpdateTime();
            }

            _hasBeenSimulated = true;
            return true;
        }

        /// <summary>
        /// Gets the max height of the Rockets travel.
        /// </summary>
        public double Apogee => _apogee;

        /// <summary>
        /// Gets the max speed the rocket during flight.
        /// </summary>
        public double VMax => _vMax;
    }
}