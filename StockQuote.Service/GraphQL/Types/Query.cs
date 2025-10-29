namespace StockQuote.Service.GraphQL.Types
{
    public record Quote(string Ticker);

    [QueryType]
    public static class QueryQuotes
    {
        public static Quote GetQuote(string ticker)
        {
            return new Quote(ticker);
        }
    }
}
