using System;

namespace Exercise1_BackwardsCounter
{
    class Program
    {
        static int Main(string[] args)
        {
            if (args.Length != 2)
            {
                Console.Error.WriteLine("Usage: <start> <divisor>");
                return 1;
            }
            
            if (!int.TryParse(args[0], out int start) ||
                !int.TryParse(args[1], out int divisor))
            {
                Console.Error.WriteLine("Invalid input: both arguments must be integers.");
                return 1;
            }

            if (start < 2)
            {
                Console.Error.WriteLine("Invalid input: first number must be ≥ 2.");
                return 1;
            }
            if (start >= 1000)
            {
                Console.Error.WriteLine("Out of range: first number must be < 1000.");
                return 1;
            }

            if (divisor == 0)
            {
                Console.Error.WriteLine("Division by zero error.");
                return 1;
            }
            if (divisor < 0)
            {
                Console.Error.WriteLine("Invalid input: negative numbers not allowed.");
                return 1;
            }
            if (divisor > start)
            {
                Console.Error.WriteLine("Invalid input: divisor must be ≤ first number.");
                return 1;
            }

            if (start % divisor != 0)
            {
                Console.Error.WriteLine("Invalid input: first number must be evenly divisible by second number.");
                return 1;
            }

            bool firstPrinted = false;
            for (int i = start; i > 0; i--)
            {
                if (i % divisor == 0)
                {
                    if (firstPrinted) Console.Write(" ");
                    Console.Write(i);
                    firstPrinted = true;
                }
            }
            Console.WriteLine();
            return 0;
        }
    }
}