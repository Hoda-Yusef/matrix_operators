using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace matrix_operators
{
    // Hoda Khier + Yusef Aborokon 44/5
    class MyCircle : IEquatable<MyCircle>
    {
        private int a;  // קוארדינאטה X של מרכז המעגל
        private int b;  // קוארדינאטה Y של מרכז המעגל
        private int c;  // קוטר מעגל


        public MyCircle()
        {
            // נקודה במרכז הצירים
            a = 0;
            b = 0;
            c = 0;
        }

        // בנאי מקבל קוטר מעגל
        public MyCircle(int C)
        {
            a = 0;
            b = 0;
            c = C;
        }

        // בנאי מקבל נקודת מרכז המעגל
        public MyCircle(int X, int y)
        {
            a = X;
            b = y;
            c = 0;
        }

        // בנאי מקבל מרכז מעגל וקוטר
        public MyCircle(int X, int Y, int C)
        {
            a = X;
            b = Y;
            c = C;
        }

        // שיטות שליפה/עדכון ערך של X של מרכז המעגל
        public int QuardenateX
        {
            get => a;
            set => a = value;
        }
        // שיטות שליפה/עדכון ערך של Y של מרכז המעגל
        public int QuardenateY
        {
            get => b;
            set => b = value;
        }

        // שיטות שליפנ/עדכון ערך הקוטר
        public int Diameter
        {
            get => c;
            set => c = value;
        }
        // חיבור שני מעגלים
        public static MyCircle operator +(MyCircle c1, MyCircle c2)
        {
            MyCircle tmpCircle = new MyCircle();
            tmpCircle.a = c1.a + c2.a;
            tmpCircle.b = c1.b + c2.b;
            tmpCircle.c = c1.c + c2.c;
            return tmpCircle;
        }

        // חיבור מספר שלם לקוטר מעגל המועבר לפונקציה זו
        public static MyCircle operator +(MyCircle c1, int number)
        {
            MyCircle newCircle = new MyCircle();
            newCircle.a = c1.a;
            newCircle.b = c1.b;
            newCircle.c = c1.c + number;
            return newCircle;
        }

        // חיסור שני מעגלים
        public static MyCircle operator -(MyCircle c1, MyCircle c2)
        {
            MyCircle tmpCircle = new MyCircle();
            tmpCircle.a = c1.a - c2.a;
            tmpCircle.b = c1.b - c2.b;
            tmpCircle.c = c1.c - c2.c;
            return tmpCircle;
        }

        //חיסור מספר שלם מקוטר מעגל המועבר לפונקציה זו
        public static MyCircle operator -(MyCircle c1, int number)
        {
            MyCircle newCircle = new MyCircle();
            newCircle.a = c1.a;
            newCircle.b = c1.b;
            newCircle.c = c1.c - number;
            return newCircle;
        }

        // קידום קוטר ב 1 
        public static MyCircle operator ++(MyCircle circle)
        {
            circle.c = circle.c + 1;
            return circle;
        }

        // חיסור 1 מקוטר
        public static MyCircle operator --(MyCircle circle)
        {
            circle.c = circle.c - 1;
            return circle;
        }

        // השוואת שני מעגלים
        public static bool operator ==(MyCircle c1, MyCircle c2)
        {
            if (c1.QuardenateX == c2.QuardenateX && c1.QuardenateY == c2.QuardenateY && c1.Diameter == c2.Diameter)
                return true;
            return false;
        }

        // פונקציה בודקת אם שני מעגלים שונים מחזירה אמת ושקר אחרת
        public static bool operator !=(MyCircle c1, MyCircle c2)
        {
            if (c1.QuardenateX != c2.QuardenateX || c1.QuardenateY != c2.QuardenateY || c1.Diameter != c2.Diameter)
                return true;
            return false;
        }

        // בודקת אם ערכי המעגל שעליו מופעלת הפונקציה שווים לערכי מעגל המועברים לפונקציה
        // אם כן מחזירה אמת ושקר אחרת
        public bool Equals(int X2, int Y2, int diameter2)
        {
            if (this.QuardenateX == X2 && this.QuardenateY == Y2 && this.Diameter == diameter2)
                return true;
            return false;
        }
        // דריסת שיטת Equals + GetHashCode
        public override bool Equals(object obj)
        {
            return Equals(obj as MyCircle);
        }

        public bool Equals(MyCircle other)
        {
            return other != null &&
                   a == other.a &&
                   b == other.b &&
                   c == other.c;
        }

        public override int GetHashCode()
        {
            int hashCode = 1474027755;
            hashCode = hashCode * -1521134295 + a.GetHashCode();
            hashCode = hashCode * -1521134295 + b.GetHashCode();
            hashCode = hashCode * -1521134295 + c.GetHashCode();
            return hashCode;
        }

        // בודקת אם מעגל ראשון גדול מהשני
        // מחזירה אמת אם כן ושקר אחרת
        public static bool operator >(MyCircle c1, MyCircle c2)
        {
            return c1.c > c2.c;
        }

        // בודקת אם מעגל ראשון קטן מהשני
        // מחזירה אמת אם כן ושקר אחרת
        public static bool operator <(MyCircle c1, MyCircle c2)
        {
            return c1.c < c2.c;
        }
    }
}
