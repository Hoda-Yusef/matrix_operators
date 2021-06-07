using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace matrix_operators
{
    // Hoda Khier + Yusef Aborokon 44/5
    public class Matrix
    {
        private int[,] mat;


        // בנאי מקבל מערך דו מימדי ומעתיק אותו ל מטריצה 
        public Matrix(int[,] tmp)
        {
            int sizeX, sizeY;

            sizeX = tmp.GetUpperBound(0) + 1;
            sizeY = tmp.GetUpperBound(1) + 1;

            mat = new int[sizeX, sizeY];
            Array.Copy(tmp, mat, sizeX * sizeY);
        }

        // בנאי מקבל גודל שורות ועמודות מטריצה
        public Matrix(int n, int m)
        {
            mat = new int[n, m];
        }

        // כפל שתי מטריצות
        public static Matrix operator *(Matrix m1, Matrix m2)
        {
            if (m1.mat.GetUpperBound(1) != m2.mat.GetUpperBound(0))
            {
                throw new Exception("size is wrong !");
            }
            else
            {
                int row = m1.mat.GetUpperBound(0) + 1;
                int col = m1.mat.GetUpperBound(1) + 1;
                int col2 = m2.mat.GetUpperBound(1) + 1;
                int i, j, k, sum;

                int[,] tmp = new int[row, col2];
                for (i = 0; i < row; i++)
                {
                    for (j = 0; j < col2; j++)
                    {
                        for (k = 0, sum = 0; k < col; k++)
                            sum += m1.mat[i, k] * m2.mat[k, j];

                        tmp[i, j] = sum;
                    }
                }
                m1 = new Matrix(tmp);
            }
            return m1;
        }


        // חיבור שתי מטריצות
        public static Matrix operator +(Matrix m1, Matrix m2)
        {
            if (m1.mat.GetUpperBound(0) != m2.mat.GetUpperBound(0)
                || m1.mat.GetUpperBound(1) != m2.mat.GetUpperBound(1))
            {
                throw new Exception("size is wrong !");
            }
            else
            {
                int row = m1.mat.GetUpperBound(0) + 1;
                int col = m1.mat.GetUpperBound(1) + 1;

                int i, j, sum;

                int[,] tmp = new int[row, col];
                for (i = 0; i < row; i++)
                {
                    for (j = 0; j < col; j++)
                    {
                        sum = 0;
                        sum += m1.mat[i, j] + m2.mat[i, j];

                        tmp[i, j] = sum;
                    }
                }
                m1 = new Matrix(tmp);
            }
            return m1;
        }


        // חיסור שתי מטריצות
        public static Matrix operator -(Matrix m1, Matrix m2)
        {
            if (m1.mat.GetUpperBound(0) != m2.mat.GetUpperBound(0)
                && m1.mat.GetUpperBound(1) != m2.mat.GetUpperBound(1))
            {
                throw new Exception("size is wrong !");
            }
            else
            {
                int row = m1.mat.GetUpperBound(0) + 1;
                int col = m1.mat.GetUpperBound(1) + 1;

                int i, j, sum;

                int[,] tmp = new int[row, col];
                for (i = 0; i < row; i++)
                {
                    for (j = 0; j < col; j++)
                    {
                        sum = 0;
                        sum += m1.mat[i, j] - m2.mat[i, j];

                        tmp[i, j] = sum;
                    }
                }
                m1 = new Matrix(tmp);
            }
            return m1;
        }

        // הדפסת מטריצה
        internal void Print()
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
        // דריסת שיטה מובנית
        public override bool Equals(object obj)
        {
            return obj is Matrix matrix &&
                   EqualityComparer<int[,]>.Default.Equals(mat, matrix.mat);
        }

        public override int GetHashCode()
        {
            return 1321690757 + EqualityComparer<int[,]>.Default.GetHashCode(mat);
        }

        // השוואת שתי מטריצות
        // אם שוות יוחזר אמת ושקר אחרת
        public static bool operator ==(Matrix m1, Matrix m2)
        {
            int flag = 0;
            if (m1.mat.GetUpperBound(0) != m2.mat.GetUpperBound(0)
               && m1.mat.GetUpperBound(1) != m2.mat.GetUpperBound(1))
            {
                throw new Exception("size is wrong !");
            }
            else
            {
                for (int i = 0; i < m1.mat.GetUpperBound(0); i++)
                {
                    for (int j = 0; j < m1.mat.GetUpperBound(1); j++)
                    {
                        if (m1.mat[i, j] != m2.mat[i, j])
                            flag = 1;
                    }
                }
                if (flag == 0)
                    return true;  // equals
                return false;  // not equal
            }
        }



        // בדיקת אי שיוויון בין שתי מטריצות
        // אם לא שוות מוחזר אמת ושקר אחרת
        public static bool operator !=(Matrix m1, Matrix m2)
        {
            int flag = 1; //equals
            if (m1.mat.GetUpperBound(0) != m2.mat.GetUpperBound(0)
               && m1.mat.GetUpperBound(1) != m2.mat.GetUpperBound(1))
            {
                throw new Exception("size is wrong !");
            }
            else
            {
                for (int i = 0; i < m1.mat.GetUpperBound(0); i++)
                {
                    for (int j = 0; j < m1.mat.GetUpperBound(1); j++)
                    {
                        if (m1.mat[i, j] != m2.mat[i, j])
                            flag = 0;
                    }
                }
                if (flag == 0)
                    return true;  //  not equal
                return false;  // equals
            }
        }

        // הגדרת שיטה חדשה
        // השוואה בין מטריצה עליה מופעלת השיטה לבין מטריצה מועברת לשיטה 
        // אם שוות יוחזר אמת ושקר אחרת
        public bool Equals(Matrix other)
        {
            int i, j, flag = 0;
            if (this.mat.GetUpperBound(0) != other.mat.GetUpperBound(0)
                || this.mat.GetUpperBound(1) != other.mat.GetUpperBound(1))
            {
                throw new Exception("size is wrong !");
            }
            else
            {
                for (i = 0; i < this.mat.GetUpperBound(0); i++)
                {
                    for (j = 0; j < this.mat.GetUpperBound(1); j++)
                    {
                        if (this.mat[i, j] != other.mat[i, j])
                            flag = 1;
                    }
                }
                if (flag == 0)
                    return true;
                return false;
            }
        }
    }
}
