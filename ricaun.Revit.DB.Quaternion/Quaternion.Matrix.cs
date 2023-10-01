using System;

namespace ricaun.Revit.DB.Quaternion
{
    public partial class Quaternion
    {
        /// <summary>
        /// Create a 3x3 Matrix [row, column] 
        /// </summary>
        /// <returns>The 3x3 Matrix without normalized.</returns>
        /// <remarks>Based: https://www.euclideanspace.com/maths/geometry/rotations/conversions/quaternionToMatrix/index.htm</remarks>
        public double[,] ToMatrix()
        {
            double[,] matrix = new double[3, 3];

            double sqw = W * W;
            double sqx = X * X;
            double sqy = Y * Y;
            double sqz = Z * Z;

            // invs (inverse square length) is only required if quaternion is not already normalised
            double invs = 1 / (sqx + sqy + sqz + sqw);

            // Disable normalised
            invs = 1.0;

            matrix[0, 0] = (sqx - sqy - sqz + sqw) * invs;
            matrix[1, 1] = (-sqx + sqy - sqz + sqw) * invs;
            matrix[2, 2] = (-sqx - sqy + sqz + sqw) * invs;

            double tmp1 = X * Y;
            double tmp2 = Z * W;
            matrix[0, 1] = 2.0 * (tmp1 + tmp2) * invs;
            matrix[1, 0] = 2.0 * (tmp1 - tmp2) * invs;

            tmp1 = X * Z;
            tmp2 = Y * W;
            matrix[0, 2] = 2.0 * (tmp1 - tmp2) * invs;
            matrix[2, 0] = 2.0 * (tmp1 + tmp2) * invs;
            tmp1 = Y * Z;
            tmp2 = X * W;
            matrix[1, 2] = 2.0 * (tmp1 + tmp2) * invs;
            matrix[2, 1] = 2.0 * (tmp1 - tmp2) * invs;

            return matrix;
        }

        /// <summary>
        /// Create a 3x3 Matrix [row, column] 
        /// </summary>
        /// <returns>The 3x3 Matrix normalized.</returns>
        public double[,] ToMatrixNormalize()
        {
            double[,] matrix = new double[3, 3];

            Quaternion q = Quaternion.Normalize(this);

            matrix[0, 0] = 1 - 2 * q.Y * q.Y - 2 * q.Z * q.Z;
            matrix[1, 0] = 2 * q.X * q.Y - 2 * q.Z * q.W;
            matrix[2, 0] = 2 * q.X * q.Z + 2 * q.Y * q.W;
            matrix[0, 1] = 2 * q.X * q.Y + 2 * q.Z * q.W;
            matrix[1, 1] = 1 - 2 * q.X * q.X - 2 * q.Z * q.Z;
            matrix[2, 1] = 2 * q.Y * q.Z - 2 * q.X * q.W;
            matrix[0, 2] = 2 * q.X * q.Z - 2 * q.Y * q.W;
            matrix[1, 2] = 2 * q.Y * q.Z + 2 * q.X * q.W;
            matrix[2, 2] = 1 - 2 * q.X * q.X - 2 * q.Y * q.Y;

            return matrix;
        }

        /// <summary>
        /// Create a Quaternion using a 3x3 Matrix [row, column]
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns>The Quaternion</returns>
        /// <remarks>The <paramref name="matrix"/> need to be normalized to work properly.</remarks>
        public static Quaternion CreateFromMatrix(double[,] matrix)
        {
            int numRows = matrix.GetLength(0);
            int numCols = matrix.GetLength(1);

            if (numRows < 3 || numCols < 3)
                throw new ArgumentException("Matrix must be at least 3x3");

            double trace = matrix[0, 0] + matrix[1, 1] + matrix[2, 2];
            double s;
            double x, y, z, w;

            if (trace > 0)
            {
                s = Math.Sqrt(trace + 1) * 2;
                x = (matrix[1, 2] - matrix[2, 1]) / s;
                y = (matrix[2, 0] - matrix[0, 2]) / s;
                z = (matrix[0, 1] - matrix[1, 0]) / s;
                w = 0.25 * s;
            }
            else if (matrix[0, 0] >= matrix[1, 1] && matrix[0, 0] >= matrix[2, 2])
            {
                s = Math.Sqrt(1 + matrix[0, 0] - matrix[1, 1] - matrix[2, 2]) * 2;
                x = 0.25 * s;
                y = (matrix[1, 0] + matrix[0, 1]) / s;
                z = (matrix[2, 0] + matrix[0, 2]) / s;
                w = (matrix[1, 2] - matrix[2, 1]) / s;
            }
            else if (matrix[1, 1] > matrix[2, 2])
            {
                s = Math.Sqrt(1 + matrix[1, 1] - matrix[0, 0] - matrix[2, 2]) * 2;
                x = (matrix[1, 0] + matrix[0, 1]) / s;
                y = 0.25 * s;
                z = (matrix[2, 1] + matrix[1, 2]) / s;
                w = (matrix[2, 0] - matrix[0, 2]) / s;
            }
            else
            {
                s = Math.Sqrt(1 + matrix[2, 2] - matrix[0, 0] - matrix[1, 1]) * 2;
                x = (matrix[2, 0] + matrix[0, 2]) / s;
                y = (matrix[2, 1] + matrix[1, 2]) / s;
                z = 0.25 * s;
                w = (matrix[0, 1] - matrix[1, 0]) / s;
            }

            return new Quaternion(x, y, z, w);
        }
    }
}
