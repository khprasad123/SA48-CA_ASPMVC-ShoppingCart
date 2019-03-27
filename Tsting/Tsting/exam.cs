using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Tsting
{
    public struct Point
    {
        public int x;
        public int y;
        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        public override string ToString()
        {
            return (String.Format("[Point:{0},{1}]", x, y));
        }
    }
    public class Point2
    {
        public int x;
        public int y;
        public Point2(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        public override string ToString()
        {
            return (String.Format("[Point2:{0},{1}]", x, y));
        }
    }
    public class App
    {
        public static void Main()
        {
            Point a = new Point(3, 4);
            Point b = a;
            a = new Point(5, 6);
            Console.WriteLine(a);
            Console.WriteLine(b);
            Point2 p = new Point2(23, 24);
            Point2 q = p;
            p = new Point2(25, 26);
            Console.WriteLine(p);
            Console.WriteLine(q);
        }
    }
}