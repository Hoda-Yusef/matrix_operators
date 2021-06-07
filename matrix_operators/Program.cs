using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace matrix_operators
{
    // Hoda Khier + Yusef Aborokon 44/5
    class Program
    {
        static void Main()
        {
            MyCircle c1 = new MyCircle();
            MyCircle c2 = new MyCircle(10);
            MyCircle c3 = new MyCircle(2, 2);
            MyCircle c4 = new MyCircle(2, 2, 5);
            MyCircle comparing;


            Console.WriteLine("(" + c1.QuardenateX + "," + c1.QuardenateY + ") Diameter is " + c1.Diameter);
            Console.WriteLine("(" + c2.QuardenateX + "," + c2.QuardenateY + ") Diameter is " + c2.Diameter);
            Console.WriteLine("(" + c3.QuardenateX + "," + c3.QuardenateY + ") Diameter is " + c3.Diameter);
            Console.WriteLine("(" + c4.QuardenateX + "," + c4.QuardenateY + ") Diameter is " + c4.Diameter);

            c1 = c1++;
            c2 = c2--;
            if (c3 == c4)
            {
                Console.WriteLine("Circle c3 is Equal to Circle c4");
            }
            else
            {
                if (c3 != c4)
                    Console.WriteLine("Circle c3 is NOT Equal to Circle c4");

            }

            if (c1.Equals(c2.QuardenateX, c2.QuardenateY, c2.Diameter))
            {
                Console.WriteLine("Circle c1 is Equal to Circle c2");
            }


            if (c4 < c2)
            {
                Console.WriteLine("Circle c2 is larger than Circle c4");
            }
            else
            {
                if (c4 > c2)
                {
                    Console.WriteLine("Circle c4 is larger than Circle c2");
                }
            }

            comparing = c1 + c3;
            Console.WriteLine("(" + comparing.QuardenateX + "," + comparing.QuardenateY + ") Diameter is " + comparing.Diameter);

            comparing = c4 - c3;
            Console.WriteLine("(" + comparing.QuardenateX + "," + comparing.QuardenateY + ") Diameter is " + comparing.Diameter);

            comparing = comparing - 2;
            Console.WriteLine("(" + comparing.QuardenateX + "," + comparing.QuardenateY + ") Diameter is " + comparing.Diameter);

            comparing = comparing + 7;
            Console.WriteLine("(" + comparing.QuardenateX + "," + comparing.QuardenateY + ") Diameter is " + comparing.Diameter);


            // Time to deal with matrixes


            int[,] m = new int[2, 3];
            int[,] n = new int[3, 4];
            int[,] other = new int[3, 4];

            int i, j;

            for (i = 0; i < 2; i++)
                for (j = 0; j < 3; j++)
                    m[i, j] = 1;

            for (i = 0; i < 3; i++)
                for (j = 0; j < 4; j++)
                    n[i, j] = 1;

            for (i = 0; i < 3; i++)
                for (j = 0; j < 4; j++)
                    other[i, j] = 1;

            Matrix m1 = new Matrix(m);
            Matrix m2 = new Matrix(n);
            Matrix m3 = new Matrix(other);

            Console.WriteLine("++++++++++++++++++++++++++++");
            m1.Print();
            Console.WriteLine("++++++++++++++++++++++++++++");
            m2.Print();
            Console.WriteLine("++++++++++++++++++++++++++++");
            m1 = m1 * m2;
            Console.WriteLine("++++++++++++++++++++++++++++");
            m1.Print();
            // An example for size error
            /*
              Console.WriteLine("++++++++++++++++++++++++++++");
              try
              {
                 m3 = m3 + m1;
              }
              catch(Exception e)
              {
                  throw new Exception("Size problem", e);
              }
            */
            Console.WriteLine("++++++++++++++++++++++++++++");
            try
            {
                m3 = m3 - m2;
                m3.Print();
            }
            catch (Exception e)
            {
                throw new Exception("Size problem", e);
            }
            Console.WriteLine("++++++++++++++++++++++++++++");
            try
            {
                if (m3.Equals(m2))
                    Console.WriteLine("Two matrixes are equal");
                else
                    Console.WriteLine("Two matrixes are NOT equal");
            }
            catch (Exception e)
            {
                throw new Exception("Size problem", e);
            }

            Console.WriteLine("++++++++++++++++++++++++++++");
            try
            {
                if (m3 == m2)
                    Console.WriteLine("Two matrixes are equal");
                else
                {
                    if (m3 != m2)
                        Console.WriteLine("Two matrixes are NOT equal");

                }
            }
            catch (Exception e)
            {
                throw new Exception("Size problem", e);
            }

            m3 = m3 + m2;
            m3.Print();


        }
    }
}
