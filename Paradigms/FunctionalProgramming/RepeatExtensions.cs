namespace Paradigms.FunctionalProgramming
{
    using System;
    using System.Collections.Generic;

    internal static class RepeatExtensions
    {
        // Repeats parameter-less action a number of times.
        public static void Repeat(this Action action, int times)
        {
            for (int time = 0; time < times; time++)
            {
                action();
            }
        }

        // Repeats parameter-less function a number of times.
        public static IEnumerable<TResult> Repeat<TResult>(this Func<TResult> func, int times)
        {
            for (int time = 0; time < times; time++)
            {
                yield return func();
            }
        }
    }
}
