namespace Paradigms.FunctionalProgramming
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    internal static class AsyncPattern
    {
        public static void Main()
        {
            WithoutAsyncPattern();
            WithAsyncPattern();
        }

        private static void WithoutAsyncPattern()
        {
            var listPrimesTask = new Task<IEnumerable<int>>(() => ListPrimes(2, 100));

            Task printPrimesTask = listPrimesTask.ContinueWith(
                antecedent => Console.WriteLine(string.Join(' ', antecedent.Result)),
                TaskScheduler.Current);

            listPrimesTask.Start();
            Console.WriteLine("Do some other work.");
            printPrimesTask.Wait();
        }

        private static void WithAsyncPattern()
        {
            Task<IEnumerable<int>> ListPrimesAsync()
            {
                return Task.FromResult(ListPrimes(2, 100));
            }

            async Task PrintPrimesAsync()
            {
                IEnumerable<int> primes = await ListPrimesAsync().ConfigureAwait(false);
                Console.WriteLine(string.Join(' ', primes));
            }

            Console.WriteLine("Do some other work.");
            PrintPrimesAsync().Wait();
        }

        private static IEnumerable<int> ListPrimes(int begin, int end)
        {
            return Enumerable.Range(begin, end - begin).Where(IsPrime);
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

            return true;
        }
    }
}
