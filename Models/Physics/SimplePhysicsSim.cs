using System;
using System.Diagnostics;
using JetBrains.Annotations;

namespace OpenApogee.Models.Physics {
    public class SimplePhysicsSim {
        private Vector3 position = new Vector3();
        private Vector3 acceleration = new Vector3();
        
        private Vector3 velocity = new Vector3();

        private float mass = 1;
        public SimplePhysicsSim(Vector3 momentum) {
            this.acceleration = momentum;
        }
        

        public float Simulate() {
            Stopwatch sw = new();
            float apogee = 0;
            sw.Start();
            
            

            double lastTime  = sw.Elapsed.TotalMilliseconds / 2;
            while (position.Y > -0.1) {
                while (!(sw.ElapsedMilliseconds % 10 > 5)) {
                    
                }
                double time = sw.Elapsed.TotalMilliseconds / 2;
                double deltaTime = time - lastTime ;
                lastTime = time;
                

                if (sw.Elapsed.TotalSeconds < 1) {
                    acceleration.Y = (15 / mass) - 9.8 ;
                }
                else {
                    acceleration.Y = -9.8;
                }
                
                velocity += acceleration * deltaTime;
                position += velocity * deltaTime;
                
                apogee = (float)(position.Y > apogee ? position.Y : apogee);
            }

            sw.Stop();
            return apogee;
        }
        
        public Vector3 Position => position;
        public Vector3 Velocity => velocity;

    }
}