namespace OpenApogee.Models.Physics.Math {
    public static class MathUtil {
        public static double RadToDeg(double rad) {
            return rad * 180 / System.Math.PI;
        }
        public static double DegToRad(double deg) {
            return deg * System.Math.PI / 180;
        }
    }
}