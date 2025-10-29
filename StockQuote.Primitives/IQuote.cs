namespace StockQuote.Primitives
{
    public interface IQuote
    {
        DateOnly Time { get; }
        double Close { get; }
    }
}
