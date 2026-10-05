
namespace ProjectEuler
{
    internal class Geometry
    {
        internal class Point
        {
            public double X;
            public double Y;
            public Point(double x, double y)
            {
                this.X = x;
                this.Y = y;
            }
            public override string ToString()
            {
                return $"[{X}, {Y}]";
            }
        }
        public delegate Point parametricEq(double t);
        public Geometry()
        {

        }

        public static Point[] GetPointsFromParEq(parametricEq f, int n)
        {
            Point[] Arr = new Point[n + 1];
            for (int i = 0; i <= n; i++)
            {
                Arr[i] = f((double)i / n);
            }
            return Arr;
        }
        public static double DistanceOfPoints(Point A, Point B)
        {
            return Math.Sqrt((A.X - B.X) * (A.X - B.X) + (A.Y - B.Y) * (A.Y - B.Y));
        }
        public static double AreaOfPolygon(Point[] points)
        {
            double area = 0;
            for (int i = 0; i < points.Length; i++)
            {
                area += (points[i].X * points[(i + 1) % points.Length].Y - points[i].Y * points[(i + 1) % points.Length].X);
            }
            area /= 2;
            return Math.Abs(area);
        }
        public static bool IsRightTriangle(Point A, Point B, Point C)
        {
            var a = (C.X - B.X) * (C.X - B.X) + (C.Y - B.Y) * (C.Y - B.Y);
            var b = (A.X - C.X) * (A.X - C.X) + (A.Y - C.Y) * (A.Y - C.Y);
            var c = (A.X - B.X) * (A.X - B.X) + (A.Y - B.Y) * (A.Y - B.Y);
            return (a + b == c) || (a + c == b) || (b + c == a);
        }
    }   

}