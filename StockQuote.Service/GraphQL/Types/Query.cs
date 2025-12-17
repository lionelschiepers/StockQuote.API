using StockQuote.Primitives;

namespace StockQuote.Service.GraphQL.Types
{
    public record Quote(string Ticker, DateOnly Time, double Close);

    [QueryType]
    public static class QueryQuotes
    {
        public static async Task<Quote?> GetQuoteAsync(string ticker, [Service] IQuoteProvider provider)
        {
            ArgumentNullException.ThrowIfNull(provider);
            var quote = await provider.GetQuoteAsync(ticker);
            if (quote == null)
            {
                return null;
            }
            return new Quote(ticker, quote.Time, quote.Close);
        }
    }
}
