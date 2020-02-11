#pragma warning disable IDE0039 // Use local function

namespace Paradigms.Linq
{
    using System;
    using System.Linq.Expressions;

    internal static class DelegateTypes
    {
        public static void Main()
        {
            ActionFuncDemo();
            ExpressionDemo();
        }

        public static void ActionFuncDemo()
        {
            Action<int> write = Console.WriteLine;
            Func<int, int> square = x => x * x;
            Func<int, int, int> add = (x, y) => x + y;

            Console.Write("Square of (1 + 3) = ");
            write(square(add(1, 3)));
        }

        public static void ExpressionDemo()
        {
            Action<int> write = Console.WriteLine;
            Expression<Func<int, int>> square = x => x * x;
            Func<int, int, int> add = (x, y) => x + y;

            Console.Write("Square of (1 + 3) = ");
            write(square.Compile()(add(1, 3)));
        }
    }
}
