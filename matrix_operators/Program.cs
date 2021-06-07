using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace matrix_operators
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] m = new int[2, 3];
            int[,] n = new int[3, 4];

            int i, j;

            for (i = 0; i < 2; i++)
                for (j = 0; j < 3; j++)
                    m[i, j] = 1;

            for (i = 0; i < 3; i++)
                for (j = 0; j < 4; j++)
                    n[i, j] = 1;

            Matrix m1 = new Matrix(m);
            Matrix m2 = new Matrix(n);

            Console.WriteLine("++++++++++++++++++++++++++++");
            m1.print();
            Console.WriteLine("++++++++++++++++++++++++++++");
            m2.print();
            Console.WriteLine("++++++++++++++++++++++++++++");
            m1 = m1 * m2;
            Console.WriteLine("++++++++++++++++++++++++++++");
            m1.print();


        }
    }
}
