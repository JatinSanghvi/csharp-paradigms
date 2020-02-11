namespace Paradigms.FunctionalProgramming
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal static class LazyEvaluation
    {
        public static void Main(string[] args)
        {
            // Nothing would get executed and the control would exit the 'Main' method if 'String.Join()' is not called.
            string firstTenPrimes = string.Join(' ', GetOddNumbers().Where(IsPrime).Take(10));
            Console.WriteLine();
            Console.WriteLine($"Prime numbers: {firstTenPrimes}.");
        }

        private static IEnumerable<int> GetOddNumbers()
        {
            for (int number = 1; ; number += 2)
            {
                Console.WriteLine($"{nameof(GetOddNumbers)}: Returning '{number}'.");
                yield return number;
            }
        }

        private static bool IsPrime(int number)
        {
            for (int factor = 2; factor * factor <= number; factor++)
            {
                if (number % factor == 0)
                {
                    return false;
                }
            }

            return number > 1;
        }
    }
}
