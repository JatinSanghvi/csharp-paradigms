namespace Paradigms.FunctionalProgramming
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Threading.Tasks;

    internal static class ParallelExecution
    {
        public static void Main()
        {
            PrintExecutionTime(() => FindSquares(1000, 2000, false)); // 34 seconds
            PrintExecutionTime(() => FindSquares(1000, 2000, true)); // 17 seconds

            // Takes 21 seconds for both actions combined.
            PrintExecutionTime(() => Parallel.Invoke(
                () => FindSquares(1000, 1650, false), // 18 seconds
                () => FindSquares(1650, 2000, false) // 17 seconds
            ));
        }

        private static void FindSquares(int start, int end, bool asParallel)
        {
            IEnumerable<int> numbers = Enumerable.Range(start, end - start);

            IEnumerable<int> squares = asParallel
                ? numbers.AsParallel().Select(number => SlowSquare(number))
                : numbers.Select(number => SlowSquare(number));

            Console.WriteLine(string.Join(' ', squares));
        }

        private static int SlowSquare(int number)
        {
            return SlowExponent(number, 2);
        }

        private static int SlowExponent(int number, int exponent)
        {
            if (exponent == 0)
            {
                return 1;
            }

            int result = 0;

            for (int count = 0; count < number; count++)
            {
                result += SlowExponent(number, exponent - 1);
            }

            return result;
        }

        private static void PrintExecutionTime(Action action)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            action();
            stopwatch.Stop();
            Console.WriteLine($"Execution Time: {stopwatch.Elapsed}.");
        }
    }
}
