using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace matrix_operators
{
    public class Matrix
    {
        private int[,] mat;


        public Matrix(int[,] tmp)
        {
            int sizeX, sizeY;

            sizeX = tmp.GetUpperBound(0) + 1;
            sizeY = tmp.GetUpperBound(1) + 1;

            mat = new int[sizeX, sizeY];
            Array.Copy(tmp, mat, sizeX*sizeY);
        }

        public Matrix(int n,int m)
        {
            mat = new int[n, m];
        }

        public static Matrix operator *(Matrix m1,Matrix m2)
        {
            if(m1.mat.GetUpperBound(1) != m2.mat.GetUpperBound(0))
            {
                throw new Exception("size is wrong !");
            }
            else
            {
                int row = m1.mat.GetUpperBound(0) + 1;
                int col = m1.mat.GetUpperBound(1) + 1;
                int col2 = m2.mat.GetUpperBound(1) + 1;
                int i, j, k, sum = 0;

                int[,] tmp = new int[row, col2];
                for(i=0;i<row;i++)
                {
                    for(j=0;j<col2;j++)
                    {
                        for (k = 0,sum=0; k < col; k++)
                            sum += m1.mat[i, k] * m2.mat[k, j];

                        tmp[i, j] = sum;
                    }
                }
                m1 = new Matrix(tmp);
            }
            return m1;
        }

        internal void print()
        {
            for (int i = 0; i < mat.GetLength(0); i++)
            {
                for (int j = 0; j < mat.GetLength(1); j++)
                {
                    Console.Write(mat[i, j] + " ");
                }
                Console.WriteLine("");
            }


        }
    }
}
