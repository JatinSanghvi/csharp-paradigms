using System;
using System.Collections.Generic;

namespace Paradigms.Linq
{
    internal static class EnumerableExtensions
    {
        public static void Main(string[] args)
        {
            var cities = new string[] { "Ghent", "London", "Las Vegas", "Hyderabad" };

            foreach (string city in cities.Filter(c => c.StartsWith('L')).ReverseSort(c => c.Length))
            {
                Console.WriteLine(city);
            }
        }
    }

    internal static class Extensions
    {
        public static IEnumerable<T> Filter<T>(this IEnumerable<T> source, Predicate<T> predicate)
        {
            foreach (T item in source)
            {
                if (predicate(item))
                {
                    yield return item;
                }
            }
        }

        public static IEnumerable<TSource> ReverseSort<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> getKey)
            where TKey : IComparable<TKey>
        {
            var list = new List<(TKey, TSource)>();
            foreach (TSource item in source)
            {
                list.Add((getKey(item), item));
            }

            list.Sort();
            list.Reverse();

            foreach (var element in list)
            {
                yield return element.Item2;
            }
        }
    }
}
