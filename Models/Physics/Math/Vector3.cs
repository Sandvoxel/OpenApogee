using System;

namespace OpenApogee.Models.Physics {
    public class Vector3 {
        private double x, y, z;

        public Vector3() : this(0, 0, 0) {}

        public Vector3(double x, double y, double z) {
            this.x = x;
            this.y = y;
            this.z = z;
        }
        
        
        public double Magnitude() {
            return (double) Math.Sqrt(x*x + y*y + z*z);
        }

        public Vector3 Normal() {
            double magnitude = Magnitude();
            return  new Vector3(x /= magnitude, y /= magnitude, z /= magnitude);;
        }


        public static Vector3 operator *(Vector3 a, Vector3 b) => new(a.x * b.x, a.y * b.y, a.z * b.z);
        public static Vector3 operator +(Vector3 a, Vector3 b) {
            a.x += b.x;
            a.y += b.y;
            a.z += b.z;
            return a;
        }

        public static Vector3 operator /(Vector3 a,double b) {
            a.x /= b;
            a.y /= b;
            a.z /= b;
            return a;
        }
        public static Vector3 operator *(Vector3 a,double b) {
            a.x *= b;
            a.y *= b;
            a.z *= b;
            return a;
        }

        public double X {
            get => x;
            set => x = value;
        }

        public double Y {
            get => y;
            set => y = value;
        }

        public double Z {
            get => z;
            set => z = value;
        }


        public override string ToString() {
            return $"({x},{y},{z})";
        }
    }
}