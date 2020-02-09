namespace Paradigms
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    public static class Program
    {
        public static void Main(string[] args)
        {
            string sourceNamespace = typeof(Program).Namespace;

            // Get all applicable static classes.
            IEnumerable<Type> allClasses = Assembly.GetExecutingAssembly().GetTypes().Where(t => IsProgramClass(t, sourceNamespace));

            string[] namespaces = allClasses.Select(c => c.Namespace).Distinct().OrderBy(n => n).ToArray();
            if (!TryChoose(namespaces, n => n.Substring(sourceNamespace.Length + 1), "namespace", "namespaces", out string selectedNamespace))
            {
                return;
            }

            string[] classNames = allClasses.Where(c => c.Namespace == selectedNamespace).Select(c => c.Name).OrderBy(n => n).ToArray();
            if (!TryChoose(classNames, c => c, "class", "classes", out string selectedClassName))
            {
                return;
            }

            Type.GetType($"{selectedNamespace}.{selectedClassName}").GetMethod("Main").Invoke(null, new object[] { new string[0] });
            Console.ReadKey();
        }

        private static bool IsProgramClass(Type type, string sourceNamespace)
        {
            return type.IsSealed && type.IsAbstract && type.GetMethod("Main") != null
                && type.Namespace.StartsWith(sourceNamespace) && type.Namespace.Length > sourceNamespace.Length;
        }

        private static bool TryChoose<T>(T[] items, Func<T, string> display, string name, string namePlural, out T selectedItem)
        {
            Console.WriteLine($"List of {namePlural}:");

            for (int id = 1; id <= items.Length; id++)
            {
                Console.WriteLine($"{id}. {display(items[id - 1])}");
            }

            Console.Write($"\nEnter {name} ID (0 to quit): ");

            if (!int.TryParse(Console.ReadLine(), out int selectedId) || selectedId <= 0 || selectedId > items.Length)
            {
                selectedItem = default(T);
                return false;
            }

            Console.WriteLine();

            selectedItem = items[selectedId - 1];
            return true;
        }
    }
}
