namespace Paradigms.Oop
{
    using System.Collections.Generic;
    using System.Linq;

    internal sealed class StockQuoteAnalyzer
    {
        private readonly IStockQuoteParser parser;

        public StockQuoteAnalyzer(IStockQuoteParser parser)
        {
            this.parser = parser;
        }

        public IEnumerable<Reversal> FindReversals()
        {
            var quotes = this.parser.ParseQuotes().ToList();
            return new ReversalLocator(quotes).Locate();
        }
    }
}
