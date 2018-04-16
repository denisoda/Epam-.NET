using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Matrixs
{
    public static class MatrixOperation
    {
        public static SquareMatrix<T> Add<T>(this SquareMatrix<T> lhs, SquareMatrix<T> rhs)
        {
            if (lhs is null)
            {
                throw new ArgumentNullException();
            }

            if (rhs is null)
            {
                throw new ArgumentNullException();
            }

            if (lhs.Size != rhs.Size)
            {
                throw new ArgumentException("matrix must be the same size.");
            }

            SquareMatrix<T> newMatrix = new SquareMatrix<T>(lhs.Size);

            for (int i = 0; i < rhs.Size; i++)
            {
                for (int j = 0; j < rhs.Size; j++)
                {
                    newMatrix[i, j] = (dynamic)lhs[i, j] + (dynamic)rhs[i, j];
                }
            }

            return newMatrix;
        }
    }
}
