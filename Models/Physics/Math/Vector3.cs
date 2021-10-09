using System;

namespace OpenApogee.Models.Physics.Math {
    public class Vector3 {
        private double x, y, z;

        public Vector3() : this(0, 0, 0) {
        }

        public Vector3(double x, double y, double z) {
            this.x = x;
            this.y = y;
            this.z = z;
        }


        public double Magnitude() {
            double sumOfSq = x * x + y * y + z * z;
            if (sumOfSq < 0.01) throw new ArithmeticException();
            return System.Math.Sqrt(x * x + y * y + z * z);
        }

        public Vector3 Normal() {
            var magnitude = 1/Magnitude();
            return new Vector3(x *= magnitude, y *= magnitude, z *= magnitude);
        }

        public Vector3 Copy() {
            return new Vector3(x, y, z);
        }


        public static Vector3 operator *(Vector3 a, Vector3 b) {
            return new(a.x * b.x, a.y * b.y, a.z * b.z);
        }

        public static Vector3 operator +(Vector3 a, Vector3 b) {
            return new(a.x + b.x, a.y + b.y, a.z + b.z);
        }

        public static Vector3 operator /(Vector3 a, double b) {
            return new(a.x / b, a.y / b, a.z / b);
        }

        public static Vector3 operator *(Vector3 a, double b) {
            return new(a.x * b, a.y * b, a.z * b);
        }

        public static Vector3 operator *(double b, Vector3 a) {
            return new(a.x * b, a.y * b, a.z * b);
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