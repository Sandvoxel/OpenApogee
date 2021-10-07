namespace OpenApogee.Models.Physics.Math {
    public class Matrix {
        private double[,] _matrix;

        public Matrix(int x, int y) {
            _matrix = new double[x, y];
        }

        public Matrix(Quaternion quaternion) {
            _matrix = new double[3, 3];
            //helper quantities - calculate these up front
            //to avoid redundancies
            var xSq = quaternion.X * quaternion.X;
            var ySq = quaternion.Y * quaternion.Y;
            var zSq = quaternion.Z * quaternion.Z;
            var wSq = quaternion.W * quaternion.W;
            var twoX = 2.0f * quaternion.X;
            var twoY = 2.0f * quaternion.Y;
            var twoW = 2.0f * quaternion.W;
            var xy = twoX * quaternion.Y;
            var xz = twoX * quaternion.Z;
            var yz = twoY * quaternion.Z;
            var wx = twoW * quaternion.Z;
            var wy = twoW * quaternion.Y;
            var wz = twoW * quaternion.Z;
            //fill in the first row
            _matrix[0,0] = wSq + xSq - ySq - zSq;
            _matrix[0,1] = xy - wz;
            _matrix[0,2] = xz + wy;
            //fill in the second row
            _matrix[1,0] = xy + wz;
            _matrix[1,1] = wSq - xSq + ySq - zSq;
            _matrix[1,2] = yz - wx;
            //fill in the third row
            _matrix[2,0] = xz - wy;
            _matrix[2,1] = yz + wx;
            _matrix[2,2] = wSq - xSq - ySq + zSq;
        }
        
        
        
    }
}