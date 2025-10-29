using StockQuote.Primitives;

namespace StockQuote
{
    public sealed class StockUnlockQuote : IQuote
    {
        public DateOnly Time { get; init; }
        public double Close { get; init; }
    }

    public sealed class StockUnlockProvider : IQuoteProvider
    {
        public IQuote GetQuote(string ticker)
        {
            ArgumentNullException.ThrowIfNull(ticker);

            return new StockUnlockQuote
            {
                Time = DateOnly.FromDateTime(DateTime.Today),
                Close = 0
            };
        }
    }
}
