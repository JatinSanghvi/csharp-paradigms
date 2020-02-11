namespace Paradigms.ObjectOrientedProgramming
{
    using System;

    internal sealed class StockQuote
    {
        private readonly DateTime date;
        private readonly decimal open;
        private readonly decimal high;
        private readonly decimal low;
        private readonly decimal close;

        public StockQuote(DateTime date, decimal open, decimal high, decimal low, decimal close)
        {
            this.date = date;
            this.open = open;
            this.high = high;
            this.low = low;
            this.close = close;
        }

        public string Date => this.date.ToShortDateString();

        public bool ReversesDownFrom(StockQuote other)
        {
            return this.open > other.high && this.close < other.low;
        }

        public bool ReversesUpFrom(StockQuote other)
        {
            return this.open < other.low && this.close > other.high;
        }
    }
}
