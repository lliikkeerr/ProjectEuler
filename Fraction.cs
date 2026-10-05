using System.Numerics;

namespace ProjectEuler
{
    internal class BigFraction
    {
        public BigInteger Num;
        public BigInteger Den;
        private BigInteger GCD(BigInteger a, BigInteger b)
        {
            while (b != 0)
            {
                BigInteger temp = b;
                b = a % b;
                a = temp;
            }
            if (a > 0)
            {
                return a;
            }
            else
            {
                return -a;
            };
        }
        public BigFraction(BigInteger num, BigInteger den)
        {
            if (den == 0)
            {
                throw new DivideByZeroException();
            }
            if (num == 0)
            {
                Num = 0;
                Den = 1;
                return;
            }
            BigInteger a = GCD(num, den);
            Num = num / a;
            Den = den / a;
        }
        public static BigFraction operator +(BigFraction a, BigFraction b) => new BigFraction(a.Num * b.Den + a.Den * b.Num, a.Den * b.Den);
        public static BigFraction operator +(BigFraction a, long b) => new BigFraction(a.Num + b * a.Den, a.Den);
        public static BigFraction operator /(long a, BigFraction b) => new BigFraction(b.Den * a, b.Num);
        public static BigFraction operator *(BigFraction a, BigFraction b) => new BigFraction(a.Num * b.Num, a.Den * b.Den);
        public override string ToString()
        {
            return $"{Num} / {Den}";
        }
    }
    internal class Fraction
    {
        public long num;
        public long den;
        private long GCD(long a, long b)
        {
            while (b != 0)
            {
                long temp = b;
                b = a % b;
                a = temp;
            }
            return Math.Abs(a);
        }

        public Fraction(long num, long den)
        {
            if (den == 0)
            {
                throw new DivideByZeroException();
            }
            if (num == 0)
            {
                this.num = 0;
                this.den = 1;
                return;
            }
            if (den < 0)
            {
                den *= -1;
                num *= -1;
            }
            long a = GCD(num, den);
            this.num = num / a;
            this.den = den / a;
        }
        public static Fraction operator +(Fraction a, long b) => new Fraction(a.num + b * a.den, a.den);
        public static Fraction operator /(long a, Fraction b) => new Fraction(b.den * a, b.num);
        public override string ToString()
        {
            return $"{num} / {den}";
        }


        public static bool operator >(Fraction a, Fraction b) => a.num * b.den > b.num * a.den;
        public static bool operator <(Fraction a, Fraction b) => a.num * b.den < b.num * a.den;
        public static Fraction operator -(Fraction a, Fraction b) => new Fraction(a.num * b.den - b.num * a.den, a.den * b.den);
        public static bool operator ==(Fraction a, Fraction b) => (a.num == b.num) & (a.den == b.den);
        public static bool operator !=(Fraction a, Fraction b) => a.num != b.num || a.den != b.den;
    }
}