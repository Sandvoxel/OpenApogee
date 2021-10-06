using System;
using System.Diagnostics;
using JetBrains.Annotations;

namespace OpenApogee.Models.Physics {
    public class SimplePhysicsSim {
        private Vector3 _position = new Vector3();
        private Vector3 _momentum  = new Vector3();
        
        private Vector3 _velocity = new Vector3();

        private double _mass = 1;
        private double _thrust = 20;
        
        public float Simulate() {
            float apogee = 0;
            //TODO: Actually do the physics math by hand to find the max height for a given values (Write a test that dose this for you).
            //TODO: Split This calculation into multiple files (I.E. SimpleRocket Class and A Simulation Class).
            //TODO: Implement Rotation and Rotation Forces on the Body (Quaternion).
            //TODO: Add Center of Mass, Thrust, Drag, and Lift to body.
            //TODO: Calculate Drag from given altitude.

            PhysicsRefrenceTime refrenceTime = new(0.0001);

            while (_position.Y > -0.1) {

                if (refrenceTime.CurrentTime < 1) {
                    _momentum.Y += (_thrust + _mass * -9.8) * refrenceTime.TimeDelta;;
                }
                else {
                    _momentum.Y += _mass * -9.8 * refrenceTime.TimeDelta;
                }
                _velocity = _momentum / _mass;

                _position += _velocity * refrenceTime.TimeDelta;


                apogee = apogee < _position.Y ? (float)_position.Y : apogee;
                
                refrenceTime.UpdateTime();
            }

            return apogee;
        }
        

    }
}