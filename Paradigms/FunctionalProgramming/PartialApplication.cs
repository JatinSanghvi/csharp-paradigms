namespace Paradigms.FunctionalProgramming
{
    using System;
    using System.Linq;

    internal static class PartialApplication
    {
        public static void Main()
        {
            /*
             * Partial application allows an action or function with input arguments to be passed as argument to higher-
             * order functions like 'Repeat' or 'Retry' that only consume parameter-less methods.
             */

            Action<string> writeLine1 = Console.WriteLine;
            writeLine1.Partial("Hello!").Repeat(3);

            Action<string, string> writeLine2 = Console.WriteLine;
            writeLine2.Partial("{0}", "Good bye!").Repeat(3);

            Func<int, int> square = Square;
            Console.WriteLine($"Total = {square.Partial(5).Repeat(2).Sum()}.");

            Func<double, int, double> power = Power;
            Console.WriteLine($"Total = {power.Partial(5, 3).Repeat(2).Sum()}.");
        }

        private static int Square(int number)
        {
            int square = number * number;
            Console.WriteLine($"Square({number}) = {square}.");
            return square;
        }

        private static double Power(double number, int exponent)
        {
            double power = Enumerable.Repeat(number, exponent).Aggregate(1.0, (x, y) => x * y);
            Console.WriteLine($"Power({number}, {exponent}) = {power}.");
            return power;
        }

        private static Action Partial<T>(this Action<T> action, T param)
        {
            return () => action(param);
        }

        private static Action Partial<T1, T2>(this Action<T1, T2> action, T1 param1, T2 param2)
        {
            return () => action(param1, param2);
        }

        private static Func<TResult> Partial<T, TResult>(this Func<T, TResult> func, T param)
        {
            return () => func(param);
        }

        private static Func<TResult> Partial<T1, T2, TResult>(this Func<T1, T2, TResult> func, T1 param1, T2 param2)
        {
            return () => func(param1, param2);
        }
    }
}
