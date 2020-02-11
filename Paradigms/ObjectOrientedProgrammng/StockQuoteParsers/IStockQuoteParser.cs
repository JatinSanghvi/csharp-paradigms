namespace Paradigms.ObjectOrientedProgramming
{
    using System.Collections.Generic;

    internal interface IStockQuoteParser
    {
        IEnumerable<StockQuote> ParseQuotes();
    }
}
