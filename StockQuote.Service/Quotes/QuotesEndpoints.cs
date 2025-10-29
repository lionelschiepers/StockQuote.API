using MediatR;
using System.Text.Json;
using YahooFinanceApi;

namespace StockQuote.Service.Quotes
{
    public static class QuotesEndpoints
    {
        private static readonly JsonSerializerOptions _jsonOptions = new()
        {
            DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull
        };

        public sealed class GetRequest : IRequest<Response>
        {
            public static readonly GetRequest Empty = new();
        }

        public sealed class Response
        {
            public string? Message { get; set; }
        }

        public static void Register(WebApplication app)
        {
            app.MapGet("/quote", async (IRequestHandler<GetRequest, Response> handler, CancellationToken cancellationToken) =>
            {
                var response = await handler.Handle(GetRequest.Empty, cancellationToken);
                return TypedResults.Json(response, _jsonOptions);
            })
            .Produces<Response>(200);
        }

        public sealed class Handler()
            : IRequestHandler<GetRequest, Response>
        {
            public async Task<Response> Handle(GetRequest content, CancellationToken cancellationToken)
            {
                var securities = await Yahoo.Symbols("AAPL", "GOOG").Fields(Field.Symbol, Field.RegularMarketPrice, Field.FiftyTwoWeekHigh).QueryAsync(cancellationToken);
                var aapl = securities["AAPL"];
                var price = aapl[Field.RegularMarketPrice];

                return new Response()
                {
                    Message = $"{aapl.Symbol} = {price}"
                };
            }
        }
    }
}
