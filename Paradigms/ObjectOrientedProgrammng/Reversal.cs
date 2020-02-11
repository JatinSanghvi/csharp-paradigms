namespace Paradigms.ObjectOrientedProgramming
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    internal sealed class Reversal
    {
        public Reversal(StockQuote quote, ReversalDirection direction)
        {
            this.Quote = quote;
            this.Direction = direction;
        }

        public StockQuote Quote { get; }

        public ReversalDirection Direction { get; }
    }
}
