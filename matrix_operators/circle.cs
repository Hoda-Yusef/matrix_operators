using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace matrix_operators
{
    class circle
    {
        private int x;
        private int y;
        private int raduis;

        public circle()
        {
            X = 0;
            Y = 0;
            Raduis = 0;
        }

        public int X { get => x; set => x = value; }
        public int Y { get => y; set => y = value; }
        public int Raduis { get => raduis; set => raduis = value; }
    }

    
}
