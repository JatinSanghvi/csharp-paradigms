namespace Paradigms.ObjectOrientedProgramming
{
    using System;

    internal static class StockReversals
    {
        public static void Main()
        {
            var loader = GetLoader("Oop\\Msft.csv");
            var parser = new CsvStockQuoteParser(loader);
            var analyzer = new StockQuoteAnalyzer(parser);

            foreach (Reversal reversal in analyzer.FindReversals())
            {
                PrintReversal(reversal);
            }
        }

        private static IDataLoader GetLoader(string source)
        {
            if (source.ToLower().StartsWith("http://"))
            {
                return new WebDataLoader(new Uri(source));
            }
            else
            {
                return new FileDataLoader(source);
            }
        }

        private static void PrintReversal(Reversal reversal)
        {
            switch (reversal.Direction)
            {
                case ReversalDirection.Down:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Pivot downside {0}", reversal.Quote.Date);
                    break;
                case ReversalDirection.Up:
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Pivot upside {0}", reversal.Quote.Date);
                    break;
            }
        }
    }
}
