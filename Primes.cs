using System.Runtime.CompilerServices;

namespace ProjectEuler
{
    internal class Primes
    {
        private long[] Divisors;
        private long len;
        public Primes(long len)
        {
            this.len = len;
            Divisors = GetlowestDiv(len);
        }
        public Primes()
        {
            Divisors = GetlowestDiv(1000);
            len = 1000;
        }
        public static long[] GetlowestDiv(long len)
        {
            long[] res = new long[len];
            res[0] = 1;
            res[1] = 1;
            for (long i = 2; i < len; i++)
            {
                if (res[i] == 0)
                {
                    for (long j = i; j < len; j += i)
                    {
                        if (res[j] == 0)
                        {
                            res[j] = i;
                        }
                    }
                }
            }
            return res;
        }
        public Dictionary<long, long> GetPrimeDivisors(long i)
        {
            Dictionary<long, long> Divs = new Dictionary<long, long>();
            while (i != 1)
            {
                if (Divs.ContainsKey(Divisors[i]))
                {
                    Divs[Divisors[i]]++;
                }
                else
                {
                    Divs.Add(Divisors[i], 1);
                }
                i /= Divisors[i];
            }
            return Divs;
        }
        private long pow(long a, long b)
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
        public long SumOfDivisors(long a)
        {
            if (a == 1)
            {
                return 1;
            }
            var Divs = GetPrimeDivisors(a).ToArray();
            long[] number = new long[Divs.Length];
            long sum = 0;
            long product = 1;
            long index = 0;
            while (number[number.Length - 1] <= Divs[number.Length - 1].Value)
            {
                product = 1;
                for (long i = 0; i < number.Length; i++)
                {
                    product *= pow(Divs[i].Key, number[i]);
                }
                sum += product;

                number[0]++;
                index = 0;
                while (number[index] > Divs[index].Value)
                {
                    number[index] = 0;
                    index++;
                    if (index == number.Length)
                    {
                        return sum - a;
                    }
                    number[index]++;
                }
            }
            return sum - a;
        }
        public HashSet<long> GetPrimes(long upper, long lower = 2)
        {
            HashSet<long> result = new HashSet<long>();
            for (long i = lower; i < upper; i++)
            {
                if (Divisors[i] == i)
                {
                    result.Add(i);
                }
            }
            return result;
        }
        public bool IsPrime(long number)
        {
            if (number < 2)
            {
                return false;
            }
            if (number >= len)
            {
                for (long i = 2; i < Math.Sqrt(number); i++)
                {
                    if (number % i == 0)
                    {
                        return false;
                    }
                }
                return true;
            }
            return Divisors[number] == number;
        }
        public static void MergeDivisors(Dictionary<long, long> divisors1, Dictionary<long, long> divisors2) //merges longo divisors1
        {
            foreach (var divisor in divisors2)
            {
                if (divisors1.ContainsKey(divisor.Key))
                {
                    divisors1[divisor.Key] += divisor.Value;
                }
                else
                {
                    divisors1.Add(divisor.Key, divisor.Value);
                }
            }
        }
        public Dictionary<long, long> MultiplyNumbers(long[] numbers)
        {
            Dictionary<long, long> result = GetPrimeDivisors(numbers[0]);
            for (long i = 1; i < numbers.Length; i++)
            {
                MergeDivisors(result, GetPrimeDivisors(numbers[i]));
            }
            return result;
        }
        public bool IsSquareFree(long number)
        {
            foreach (var item in GetPrimeDivisors(number))
            {
                if (item.Value != 1)
                {
                    return false;
                }
            }
            return true;
        }
        public static bool IsSquare(Dictionary<long, long> divisors)
        {
            foreach (var item in divisors)
            {
                if (item.Value % 2 == 1)
                {
                    return false;
                }
            }
            return true;
        }
        public static bool IsCoprime(long a, long b)
        {
            return Functions.GCD(a, b) == 1;
        }
        public long Phifunction(long n)
        {
            var divs = GetPrimeDivisors(n);
            foreach (var item in divs)
            {
                n -= (n / item.Key);
            }
            return n;
        }
        public HashSet<long> GetSquareDivisors(long n)
        {
            HashSet<long> result = new HashSet<long> { 1 };
            var divs = GetPrimeDivisors(n);
            foreach (var item in divs)
            {
                var value = item.Key;
                var count = item.Value;
                HashSet<long> temp = new HashSet<long>();
                while (count >= 2)
                {
                    temp.Add(value * value);
                    count -= 2;
                    value *= value;
                }
                HashSet<long> temp1 = new HashSet<long>();
                foreach (var current in temp)
                {
                    foreach (var old in result)
                    {
                        temp1.Add(old * current);
                    }
                }
                foreach (var huj in temp1)
                {
                    result.Add(huj);
                }
            }
            return result;
        }
        public long TotientFunction(long n)
        {
            var divs = GetPrimeDivisors(n);
            long result = n;
            foreach (var item in divs)
            {
                result *= (item.Key - 1);
                result /= item.Key;
            }
            return result;
        }
    }
}