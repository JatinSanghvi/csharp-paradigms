namespace Paradigms.Oop
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    internal sealed class ReversalLocator
    {
        private readonly IList<StockQuote> quotes;

        public ReversalLocator(IList<StockQuote> quotes)
        {
            this.quotes = quotes;
        }

        public IEnumerable<Reversal> Locate()
        {
            for (int i = 0; i < this.quotes.Count - 1; i++)
            {
                if (this.quotes[i].ReversesDownFrom(this.quotes[i + 1]))
                {
                    yield return new Reversal(this.quotes[i], ReversalDirection.Down);
                }

                if (this.quotes[i].ReversesUpFrom(this.quotes[i + 1]))
                {
                    yield return new Reversal(this.quotes[i], ReversalDirection.Up);
                }
            }
        }
    }
}
