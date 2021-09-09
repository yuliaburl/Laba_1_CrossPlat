using System;
using System.IO;

class Program
{
    static bool isPrime(long num)
    {
        if (num == 1 || (num > 2 && num % 2 == 0)) return false;
        if (num == 2) return true;
        for (long div = 3; div < num; div += 2)
            if (num % div == 0) return false;
        return true;
    }

    static void Main()
    {
        const string inputFile = "INPUT.TXT";
        const string outputFile = "OUTPUT.TXT";
        const long maxPrime = 1000;

        long x = long.Parse(File.ReadAllText(inputFile));

        long primeDivProduct = 1;
        for (long div = 1; div <= maxPrime; div++)
            if (isPrime(div) && x % div == 0)
                primeDivProduct *= div;
        long result = 0;
        for (long div = 1; div <= x; div++)
            if (x % div == 0 && div % primeDivProduct == 0) result++;

        File.WriteAllText(outputFile, result.ToString());
    }
}