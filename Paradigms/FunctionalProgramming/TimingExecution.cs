namespace Paradigms.FunctionalProgramming
{
    using System;
    using System.Diagnostics;

    internal static class TimingExecution
    {
        public static void Main(string[] args)
        {
            TimeSpan elapsed = GetExecutionTime(() =>
            {
                int number = 3;
                int exponent = 15;
                Console.WriteLine($"{number}^{exponent} = {SlowExponent(number, exponent)}");
            });

            Console.WriteLine($"Execution Time: {elapsed.Milliseconds} mSec.");
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

        private static TimeSpan GetExecutionTime(Action action)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            action();
            return stopwatch.Elapsed;
        }
    }
}
