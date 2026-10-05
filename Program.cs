namespace ProjectEuler;

internal class Program
{
    static void Main(string[] args)
    {
        var Primes = new Primes(40_000_000);
        var prime = Primes.GetPrimes(40_000_000);
        long sum = 0;
        long print = 0;
        long addition = 1_000_000;
        foreach (var item in prime)
        {
            if (item > print)
            {
                print += addition;
                Console.WriteLine(item);
            }
            long p = item;
            int counter = 1;
            while(p > 1)
            {
                counter++;
                p = Primes.TotientFunction(p);
            }
            if (counter == 25)
            {
                sum += item;
            }
        }
        Console.WriteLine($"the total is: {sum}");
    }
}
