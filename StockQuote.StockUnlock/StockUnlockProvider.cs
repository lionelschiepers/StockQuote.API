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
        public Task<IQuote?> GetQuoteAsync(string ticker)
        {
            ArgumentNullException.ThrowIfNull(ticker);

            return Task.FromResult<IQuote?>(new StockUnlockQuote
            {
                Time = DateOnly.FromDateTime(DateTime.Today),
                Close = 0
            });
        }
    }
}
