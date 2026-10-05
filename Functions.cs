using System.Numerics;

namespace ProjectEuler
{
    internal class Functions
    {
        public Functions() { }
        public long PentagonalNumber(long n)
        {
            return n * (3 * n - 1) / 2;
        }
        public long TriangularNumber(long n)
        {
            return n * (n + 1) / 2;
        }
        public long HexagonalNumber(long n)
        {
            return n * (2 * n - 1);
        }
        public long SquareNumber(long n)
        {
            return n * n;
        }
        public long HeptagonalNumber(long n)
        {
            return n * (5 * n - 3) / 2;
        }
        public long OctagonalNumber(long n)
        {
            return n * (3 * n - 2);
        }
        public BigInteger Pow(BigInteger a, BigInteger b)
        {
            if (b == 0)
            {
                return 1;
            }
            else if(b % 2 == 0)
            {
                BigInteger temp = Pow(a, b / 2);
                return temp * temp;
            }
            else
            {
                BigInteger temp = Pow(a, b / 2);
                return a * temp * temp;
            }
        }
        public int Pow(int a, int b)
        {
            if (b == 0)
            {
                return 1;
            }
            else if (b % 2 == 0)
            {
                int temp = Pow(a, b / 2);
                return temp * temp;
            }
            else
            {
                int temp = Pow(a, b / 2);
                return a * temp * temp;
            }
        }
        public uint Pow(uint a, uint b)
        {
            if (b == 0)
            {
                return 1;
            }
            else if (b % 2 == 0)
            {
                uint temp = Pow(a, b / 2);
                return temp * temp;
            }
            else
            {
                uint temp = Pow(a, b / 2);
                return a * temp * temp;
            }
        }
        public static long GCD(long a, long b)
        {
            while (b != 0)
            {
                long temp = b;
                b = a % b;
                a = temp;
            }
            return Math.Abs(a);
        }
    }
}