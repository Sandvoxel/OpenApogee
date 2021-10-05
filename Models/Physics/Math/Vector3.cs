using System;

namespace OpenApogee.Models.Physics {
    public class Vector3 {
        private float x, y, z;

        public Vector3() : this(0, 0, 0) {}

        public Vector3(float x, float y, float z) {
            this.x = x;
            this.y = y;
            this.z = z;
        }
        
        
        public float Magnitude() {
            return (float) Math.Sqrt(x*x + y*y + z*z);
        }

        public Vector3 Normal() {
            float magnitude = Magnitude();
            return  new Vector3(x /= magnitude, y /= magnitude, z /= magnitude);;
        }


        public static Vector3 operator +(Vector3 a, Vector3 b) {
            return new Vector3(a.x * b.x, a.y * b.y, a.z * b.z);
        } 
        public static Vector3 operator /(Vector3 a,float b) {
            return new Vector3(a.x / b, a.y / b, a.z / b);
        }


        public override string ToString() {
            return $"({x},{y},{z})";
        }
    }
}