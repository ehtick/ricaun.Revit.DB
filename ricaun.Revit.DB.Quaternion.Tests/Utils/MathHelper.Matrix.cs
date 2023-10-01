using System;

namespace RevitAddin.QuaternionTest.Tests
{
    static partial class MathHelper
    {
        public static bool Similar(double[,] a, double[,] b, double tolerance = 1e-9)
        {
            int numRowsA = a.GetLength(0);
            int numColsA = a.GetLength(1);
            int numRowsB = b.GetLength(0);
            int numColsB = b.GetLength(1);

            var numRows = Math.Min(numRowsA, numRowsB);
            var numCols = Math.Min(numColsA, numColsB);

            for (int i = 0; i < numRows; i++)
            {
                for (int j = 0; j < numCols; j++)
                {
                    if (Math.Abs(a[i, j] - b[i, j]) > tolerance)
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}