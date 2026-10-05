using System.Drawing;
using System.Numerics;
namespace ProjectEuler
{
    public class BigFixedPoint :
    IAdditionOperators<BigFixedPoint, BigFixedPoint, BigFixedPoint>,
    IMultiplyOperators<BigFixedPoint, BigFixedPoint, BigFixedPoint>
    {
        public int Point { get; set; }
        public BigInteger Value { get; }    

        public BigFixedPoint(int point, BigInteger value)
        {
            Point = point;

            Value = value;
            Value <<= point;
        }
        public BigFixedPoint(BigFixedPoint old)
        {
            Point = old.Point;
            Value = old.Value;
        }
        public override string ToString()
        {
            // Reconstruct the full integer (fractional bytes are the lowest ones)
            BigInteger fullValue = Value;

            BigInteger absValue = BigInteger.Abs(fullValue);

            // Scale for fractional digits: 256^Point
            BigInteger scale = BigInteger.One << Point;

            BigInteger integerPart = absValue / scale;
            BigInteger remainder = absValue % scale;

            // Build fractional digits
            char[] digits = new char[20];
            for (int i = 0; i < 20; i++)
            {
                remainder *= 10;
                BigInteger digit = remainder / scale;
                digits[i] = (char)('0' + (int)digit);
                remainder %= scale;
            }
            string sign = "";
            if (Value < 0)
            {
                sign = "-";
            }
            return $"{sign}{integerPart},{new string(digits)}";
        }
        public static BigFixedPoint operator <<(BigFixedPoint value, int shift)
        {
            BigInteger NewValue = value.Value;
            NewValue <<= shift;
            var ans = new BigFixedPoint(0, NewValue);
            ans.Point = value.Point;
            return ans;
        }
        public static BigFixedPoint operator >>(BigFixedPoint value, int shift)
        {
            BigInteger NewValue = value.Value;
            NewValue >>= shift;
            var ans = new BigFixedPoint(0, NewValue);
            ans.Point = value.Point;
            return ans;
        }
        public static BigFixedPoint operator +(BigFixedPoint a, BigFixedPoint b)
        {
            BigInteger cValue = a.Value + b.Value;
            BigFixedPoint c = new BigFixedPoint(0, cValue);
            c.Point = a.Point;
            return c;
        }
        public static BigFixedPoint operator *(BigFixedPoint a, BigFixedPoint b)
        {
            BigInteger cValue = b.Value * a.Value;
            cValue >>= a.Point;
            BigFixedPoint c = new BigFixedPoint(0, cValue);
            c.Point = a.Point;
            return c;
        }
        public static bool operator <(BigFixedPoint a, BigFixedPoint b) => a.Value < b.Value;
        public static bool operator >(BigFixedPoint a, BigFixedPoint b) => a.Value > b.Value;
        public static BigFixedPoint operator /(BigFixedPoint a, BigInteger b)
        {
            BigInteger value = a.Value / b;
            BigFixedPoint c = new BigFixedPoint(0, value);
            c.Point = a.Point;
            return c;
        }
    }
}