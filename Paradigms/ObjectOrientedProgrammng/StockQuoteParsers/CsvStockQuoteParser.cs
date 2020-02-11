namespace Paradigms.ObjectOrientedProgramming
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal sealed class CsvStockQuoteParser : IStockQuoteParser
    {
        private readonly IDataLoader loader;

        public CsvStockQuoteParser(IDataLoader loader)
        {
            this.loader = loader;
        }

        public IEnumerable<StockQuote> ParseQuotes()
        {
            string[] lines = this.loader.LoadData().Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

            var quotes = new List<StockQuote>();

            foreach (string line in lines.Skip(1))
            {
                string[] cells = line.Split(',');

                yield return new StockQuote(
                    date: DateTime.Parse(cells[0]),
                    open: decimal.Parse(cells[1]),
                    high: decimal.Parse(cells[2]),
                    low: decimal.Parse(cells[3]),
                    close: decimal.Parse(cells[4]));
            }
        }
    }
}
