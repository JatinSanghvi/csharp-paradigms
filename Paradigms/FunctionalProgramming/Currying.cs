namespace Paradigms.FunctionalProgramming
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal static class Currying
    {
        public static void Main(string[] args)
        {
            /*
             * Currying converts and action or function with input arguments into a higher-order function. This new
             * function consumes the same set of input arguments but returns parameter-less action or function (instead
             * of return value). The delayed evaluation allows the output of new function to other higher-order
             * functions like 'Repeat' or 'Retry' that only consume parameter-less methods.
             */

            var greet1 = ((Action<string>)Console.WriteLine).Curry();
            greet1("Hello!").Repeat(2);

            var greet2 = ((Action<string, string>)Console.WriteLine).Curry()("Hello, {0}!");
            greet2("John").Repeat(2);
            greet2("Jane").Repeat(2);

            Func<int, int> square = Square;
            var squareCurry = square.Curry();

            Console.WriteLine($"Total = {squareCurry(5).Repeat(2).Sum()}.");
            Console.WriteLine($"Total = {squareCurry(10).Repeat(2).Sum()}.");

            Func<double, int, double> power = Power;
            var powerCurry = power.Curry();

            var powerFive = powerCurry(5);
            Console.WriteLine($"Total = {powerFive(2).Repeat(2).Sum()}.");
            Console.WriteLine($"Total = {powerFive(3).Repeat(2).Sum()}.");

            var tenSquare = powerCurry(10)(2);
            var tenCube = powerCurry(10)(3);
            Console.WriteLine($"Total = {tenSquare.Repeat(2).Sum()}.");
            Console.WriteLine($"Total = {tenCube.Repeat(2).Sum()}.");
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

        private static Func<T, Action> Curry<T>(this Action<T> action)
        {
            return (T param) => () => action(param);
        }

        private static Func<T1, Func<T2, Action>> Curry<T1, T2>(this Action<T1, T2> action)
        {
            return (T1 param1) => (T2 param2) => () => action(param1, param2);
        }

        private static Func<T, Func<TResult>> Curry<T, TResult>(this Func<T, TResult> func)
        {
            return (T param) => () => func(param);
        }

        private static Func<T1, Func<T2, Func<TResult>>> Curry<T1, T2, TResult>(this Func<T1, T2, TResult> func)
        {
            return (T1 param1) => (T2 param2) => () => func(param1, param2);
        }
    }
}
