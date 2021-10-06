using System;
using System.Diagnostics;
using JetBrains.Annotations;

namespace OpenApogee.Models.Physics {
    public class SimplePhysicsSim {
        private Vector3 position = new Vector3();
        private Vector3 acceleration = new Vector3();
        
        private Vector3 velocity = new Vector3();

        private float mass = 1;
        
        public float Simulate() {
            //Max Height for flight
            float apogee = 0;

            //Delta time class
            DeltaTime timer = new();
            
            //TODO: Move from real time to its own internal timeframe.
            //TODO: Actually do the physics math by hand to find the max height for a given values (Write a test that dose this for you).
            while (position.Y > -0.1) { 
                
                //If statement to stop rocket thrust after a second of burn time
                if (timer.GetCurrentTime().TotalSeconds < 1) {
                    acceleration.Y = (15 / mass) - 9.8 ;
                }
                else {
                    acceleration.Y = -9.8;
                }

                //integrating acceleration into velocity and then integrating velocity int position.
                double deltaTime = timer.GetDeltaTime();
                velocity += acceleration * deltaTime;
                position += velocity * deltaTime;
                
                //capturing the max height of flight
                apogee = (float)(position.Y > apogee ? position.Y : apogee);
            }

            return apogee;
        }
        
        public Vector3 Position => position;
        public Vector3 Velocity => velocity;

    }
}