using System;

namespace OpenApogee.Models.Physics.Math {
    public class Quaternion {
        private double w, x, y, z;

        public Quaternion() : this(1,0,0,0) {}

        public Quaternion(double w, double x, double y, double z) {
            this.w = w;
            this.x = x;
            this.y = y;
            this.z = z;
        }


        
        
        public double Magnitude() {
            var sumOfSq = w * w + x * x + y * y + z * z;
            if (sumOfSq < 0.01) throw new ArithmeticException();
            return System.Math.Sqrt(sumOfSq);
        }

        public void Normalise() {
            var magnitude = 1/Magnitude();
            w *= magnitude;
            x *= magnitude;
            y *= magnitude;
            z *= magnitude;
        }

        
        public static Quaternion operator *(Quaternion q1, Quaternion q2) {
            Quaternion result = new();
            result.w = q1.w * q2.w - q1.x * q2.x - q1.y * q2.y - q1.z * q2.z;
            result.x = q1.w * q2.x + q1.x * q2.w + q1.y * q2.z - q1.z * q2.y;
            result.y = q1.w * q2.y + q1.y * q2.w + q1.x * q2.z - q1.z * q2.x;
            result.z = q1.w * q2.z + q1.z * q2.w + q1.x * q2.y - q1.y * q2.x;
            return result;
        }

        public double W => w;
        public double X => x;
        public double Y => y;
        public double Z => z;
    }
}