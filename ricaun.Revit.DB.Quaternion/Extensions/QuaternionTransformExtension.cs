using Autodesk.Revit.DB;
using System;
using System.Globalization;

namespace ricaun.Revit.DB.Quaternion.Extensions
{
    /// <summary>
    /// QuaternionTransformExtension
    /// </summary>
    public static class QuaternionTransformExtension
    {
        /// <summary>
        /// Decomposes the tranform into its quaternion and origin.
        /// </summary>
        /// <param name="tranform">The transform</param>
        /// <param name="quaternion"></param>
        /// <param name="origin"></param>
        /// <returns>True if the decomposition was successful, false otherwise.</returns>
        public static bool Decompose(this Transform tranform, out Quaternion quaternion, out XYZ origin)
        {
            quaternion = tranform.GetQuaternion();
            origin = tranform.Origin;
            return true;
        }

        /// <summary>
        /// Creates a transform from the specified matrix [row, column].
        /// </summary>
        /// <remarks>
        /// <br>Row 0 - [ BasisX.X BasisY.X BasisZ.X ]</br>
        /// <br>Row 1 - [ BasisX.Y BasisY.Y BasisZ.Y ]</br>
        /// <br>Row 2 - [ BasisX.Z BasisY.Z BasisZ.Z ]</br>
        /// <br>Row 3 - [ Origin.X Origin.Y Origin.Z ]</br>
        /// </remarks>
        /// <param name="tranform">The transform to create from matrix.</param>
        /// <param name="matrix">The double array matrix to create the transform from.</param>
        /// <returns>The transform created from the matrix.</returns>
        public static Transform CreateMatrix(this Transform tranform, double[,] matrix)
        {
            tranform.BasisX = new XYZ(matrix[0, 0], matrix[0, 1], matrix[0, 2]);
            tranform.BasisY = new XYZ(matrix[1, 0], matrix[1, 1], matrix[1, 2]);
            tranform.BasisZ = new XYZ(matrix[2, 0], matrix[2, 1], matrix[2, 2]);

            if (matrix.GetLength(0) >= 4)
                tranform.Origin = new XYZ(matrix[3, 0], matrix[3, 1], matrix[3, 2]);

            return tranform;
        }

        /// <summary>
        /// SetQuaternion
        /// </summary>
        /// <param name="tranform"></param>
        /// <param name="quaternion"></param>
        /// <returns></returns>
        public static Transform SetQuaternion(this Transform tranform, Quaternion quaternion)
        {
            var scale = tranform.Scale;
            return tranform.CreateMatrix(Quaternion.Normalize(quaternion).ToMatrix()).ScaleBasis(scale);
        }

        /// <summary>
        /// GetQuaternion
        /// </summary>
        /// <param name="tranform"></param>
        /// <returns></returns>
        public static Quaternion GetQuaternion(this Transform tranform)
        {
            var scale = tranform.Scale;
            return Quaternion.CreateFromMatrix(tranform.ScaleBasis(1.0 / scale).ToMatrix()) * Math.Sqrt(scale);
        }

        /// <summary>
        /// Converts the given transform to a double array matrix [row, column].
        /// </summary>
        /// <param name="tranform">The transform to convert.</param>
        /// <returns>A double array matrix representation of the transform.</returns>
        public static double[,] ToMatrix(this Transform tranform)
        {
            double[,] matrix = new double[4, 3];
            for (int j = 0; j < 3; j++)
            {
                for (int i = 0; i < 3; i++)
                {
                    matrix[i, j] = tranform.get_Basis(i)[j];
                }
                matrix[3, j] = tranform.Origin[j];
            }
            return matrix;
        }

        #region Determinant

        /// <summary>
        /// Determinant
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns></returns>
        public static double Determinant3x3(this double[,] matrix)
        {
            if (matrix.GetLength(0) < 3 || matrix.GetLength(1) < 3)
            {
                throw new ArgumentException("Matrix should be at least 3x3.");
            }

            double determinant = 0;

            determinant += matrix[0, 0] * (matrix[1, 1] * matrix[2, 2] - matrix[1, 2] * matrix[2, 1]);
            determinant -= matrix[0, 1] * (matrix[1, 0] * matrix[2, 2] - matrix[1, 2] * matrix[2, 0]);
            determinant += matrix[0, 2] * (matrix[1, 0] * matrix[2, 1] - matrix[1, 1] * matrix[2, 0]);

            return determinant;
        }

        #endregion

        /// <summary>
        /// Converts the given double array matrix to a string representation.
        /// </summary>
        /// <param name="matrix">The double array matrix to convert.</param>
        /// <returns>The string representation of the matrix.</returns>
        public static string AsString(this double[,] matrix)
        {
            var str = "";
            str += "[";
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                str += "(";
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    str += matrix[i, j].ToString("0.00", CultureInfo.InvariantCulture);
                    str += ",";
                }
                str = str.Trim(',');
                str = str.Trim();
                str += ")";
                str += ",";
            }
            str = str.Trim(',');
            str = str.Trim();
            str += "]";
            return str;
        }

        /// <summary>
        /// Converts the given transform to a string representation.
        /// </summary>
        /// <param name="tranform">The transform to convert.</param>
        /// <returns>The string representation of the transform.</returns>
        public static string AsString(this Transform tranform)
        {
            var scale = tranform.IsConformal ? tranform.Scale : double.NaN;
            return $"({tranform.BasisX.X:0.00},{tranform.BasisX.Y:0.00},{tranform.BasisX.Z:0.00}) ({tranform.BasisY.X:0.00},{tranform.BasisY.Y:0.00},{tranform.BasisY.Z:0.00}) ({tranform.BasisZ.X:0.00},{tranform.BasisZ.Y:0.00},{tranform.BasisZ.Z:0.00}) [{tranform.Origin.X:0.00},{tranform.Origin.Y:0.00},{tranform.Origin.Z:0.00}] [{scale:0.00}]";
        }

        /// <summary>
        /// Converts the given quaternion to a string representation.
        /// </summary>
        /// <param name="quaternion">The quaternion to convert.</param>
        /// <returns>The string representation of the quaternion.</returns>
        public static string AsString(this Quaternion quaternion)
        {
            return $"({quaternion.X:0.00},{quaternion.Y:0.00},{quaternion.Z:0.00},{quaternion.W:0.00})";
        }
    }

}
