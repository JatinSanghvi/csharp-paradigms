namespace Paradigms.Oop
{
    using System.Collections.Generic;

    internal interface IStockQuoteParser
    {
        IEnumerable<StockQuote> ParseQuotes();
    }
}
