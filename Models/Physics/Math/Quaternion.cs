namespace OpenApogee.Models.Physics.Math {
    public class Quaternion {
        private float w, x, y, z;

        public Quaternion(float w, float x, float y, float z) {
            this.w = w;
            this.x = x;
            this.y = y;
            this.z = z;
        }


        public float Magnitude() {
            return (float)System.Math.Sqrt(w * w + x * x + y * y + z * z);
        }

        public void Normalise() {
            var magnitude = Magnitude();
            w /= magnitude;
            x /= magnitude;
            y /= magnitude;
            z /= magnitude;
        }
    }
}