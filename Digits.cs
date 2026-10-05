
using System.Diagnostics;
using System.Numerics;

namespace ProjectEuler
{
    internal class Digits
    {
        public Digits() { }
        public static bool IsPalindrome(long a)
        {
            string s = a.ToString();
            for (int i = 0; i < s.Length / 2 + 1; i++)
            {
                if (s[i] != s[s.Length - i - 1])
                {
                    return false;
                }
            }
            return true;
        }
        public static long Reverse(long a)
        {
            var n = a.ToString().Reverse();
            string s = "";
            foreach (var item in n)
            {
                s += item.ToString();
            }
            return long.Parse(s);
        }
        public bool IsPandigital(int a)
        {
            if (a > 987654321)
            {
                return false;
            }
            int digits = 0;
            while (a > Math.Pow(10, digits))
            {
                digits++;
            }
            int[] numbers = new int[digits];
            foreach (var digit in a.ToString())
            {
                if (int.Parse(digit.ToString()) <= digits & digit.ToString() != "0")
                {
                    if (numbers[int.Parse(digit.ToString()) - 1] == 0)
                    {
                        numbers[int.Parse(digit.ToString()) - 1]++;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            return true;
        }
        public long SumOfDigits(long a)
        {
            long sum = 0;
            foreach (var digit in a.ToString())
            {
                sum += long.Parse(digit.ToString());
            }
            return sum;
        }
        public long SumOfDigits(BigInteger a)
        {
            long sum = 0;
            foreach (var item in a.ToString())
            {
                sum += long.Parse(item.ToString());
            }
            return sum;
        }

        public int RomanToInt(string text)
        {
            int index = 0;
            int sum = 0;
            while (index < text.Length)
            {
                if (text[index] == 'M')
                {
                    sum += 1000;
                    index++;
                }
                else if (text[index] == 'D')
                {
                    sum += 500;
                    index++;
                }
                else if (text[index] == 'C')
                {
                    if (index != text.Length - 1)
                    {
                        if (text[index + 1] == 'M')
                        {
                            sum += 900;
                            index += 2;
                        }
                        else if (text[index + 1] == 'D')
                        {
                            sum += 400;
                            index += 2;
                        }
                        else
                        {
                            sum += 100;
                            index++;
                        }
                    }
                    else
                    {
                        sum += 100;
                        index++;
                    }
                }
                else if (text[index] == 'L')
                {
                    sum += 50;
                    index++;
                }
                else if (text[index] == 'X')
                {
                    if (index != text.Length - 1)
                    {
                        if (text[index + 1] == 'C')
                        {
                            sum += 90;
                            index += 2;
                        }
                        else if (text[index + 1] == 'L')
                        {
                            sum += 40;
                            index += 2;
                        }
                        else
                        {
                            sum += 10;
                            index++;
                        }
                    }
                    else
                    {
                        sum += 10;
                        index++;
                    }
                }
                else if (text[index] == 'V')
                {
                    sum += 5;
                    index++;
                }
                else
                {
                    if (index != text.Length - 1)
                    {
                        if (text[index + 1] == 'X')
                        {
                            sum += 9;
                            index += 2;
                        }
                        else if (text[index + 1] == 'V')
                        {
                            sum += 4;
                            index += 2;
                        }
                        else
                        {
                            sum += 1;
                            index++;
                        }
                    }
                    else
                    {
                        sum += 1;
                        index++;
                    }
                }
            }
            return sum;
        }
        public string IntToRoman(int num)
        {
            if (num <= 0 || num >= 5000)
                throw new ArgumentOutOfRangeException("num", "Value must be between 1 and 4999");

            var romanNumerals = new (int, string)[]
            {
            (1000, "M"), (900, "CM"), (500, "D"), (400, "CD"), (100, "C"), (90, "XC"),
            (50, "L"), (40, "XL"), (10, "X"), (9, "IX"), (5, "V"), (4, "IV"), (1, "I")
            };

            string result = "";

            foreach (var (value, symbol) in romanNumerals)
            {
                while (num >= value)
                {
                    result += symbol;
                    num -= value;
                }
            }

            return result;
        }
        public int CubeSumOfDigits(int a)
        {
            string num = a.ToString();
            int sum = 0;
            int digit;
            foreach (var Digit in num)
            {
                digit = int.Parse(Digit.ToString());
                sum += digit * digit * digit;
            }
            return sum;
        }
        public int SquareSumOfDigits(int a)
        {
            string num = a.ToString();
            int sum = 0;
            int digit;
            foreach (var Digit in num)
            {
                digit = int.Parse(Digit.ToString());
                sum += digit * digit;
            }
            return sum;
        }
        public long SumOfNPowDigits(long a, long n)
        {
            long Pow(long a, long b)
            {
                if (b == 0)
                {
                    return 1;
                }
                else if (b % 2 == 0)
                {
                    long temp = Pow(a, b / 2);
                    return temp * temp;
                }
                else
                {
                    long temp = Pow(a, b / 2);
                    return a * temp * temp;
                }
            }
            string num = a.ToString();
            long sum = 0;
            long digit;
            foreach (var Digit in num)
            {
                digit = int.Parse(Digit.ToString());
                sum += Pow(digit, n);
            }
            return sum;
        }
        public static bool HasSameDigits(int a, int b)
        {
            Dictionary<char, int> dict = new Dictionary<char, int>();
            foreach (var digit in a.ToString())
            {
                if (dict.ContainsKey(digit))
                {
                    dict[digit]++;
                }
                else
                {
                    dict.Add(digit, 1);
                }
            }
            foreach (var digit in b.ToString())
            {
                if (dict.ContainsKey(digit))
                {
                    dict[digit]--;
                }
                else
                {
                    return false;
                }
            }
            foreach (var item in dict)
            {
                if (item.Value != 0)
                {
                    return false;
                }
            }
            return true;
        }
        public bool HasSameDigits(BigInteger a, BigInteger b)
        {
            byte[] digits = new byte[10];
            while (a > 0)
            {
                digits[(int)(a % 10)]++;
                a /= 10;
            }
            while (b > 0)
            {
                digits[(int)(b % 10)]--;
                b /= 10;
            }
            foreach (var item in digits)
            {
                if (item != 0)
                {
                    return false;
                }
            }
            return true;
        }
        public int ReplaceNthDigit(int a, int index, int digit)
        {
            int pow(int a, int b)
            {
                if (b == 0)
                {
                    return 1;
                }
                else
                {
                    return a * pow(a, b - 1);
                }
            }
            int temp = a;
            temp /= pow(10, index);
            temp %= 10;
            return a + digit * pow(10, index) - temp * pow(10, index);
        }
        public int NumberOfDiferentDigits(int a)
        {
            var HS = new HashSet<char>();
            foreach (var item in a.ToString())
            {
                HS.Add(item);
            }
            return HS.Count();
        }
        public Dictionary<char, int> CountDiferentDigits(int a)
        {
            var dict = new Dictionary<char, int>();
            foreach (var digit in a.ToString())
            {
                if (dict.ContainsKey(digit))
                {
                    dict[digit]++;
                }
                else
                {
                    dict.Add(digit, 1);
                }
            }
            return dict;
        }
        public int[] DiferentDigitsInArray(long a)
        {
            int[] Arr = new int[10];
            foreach(char c in a.ToString())
            {
                Arr[int.Parse(c.ToString())]++;
            }
            return Arr;
        }
        public int SumOfDigitFactorials(int a)
        {
            string num = a.ToString();
            int sum = 0;
            int digit;
            int factorial(int a)
            {
                int ret = 1;
                for (int i = 2; i <= a; i++)
                {
                    ret *= i;
                }
                return ret;
            }
            foreach (var Digit in num)
            {
                digit = int.Parse(Digit.ToString());
                sum += factorial(digit);
            }
            return sum;
        }
    }
}