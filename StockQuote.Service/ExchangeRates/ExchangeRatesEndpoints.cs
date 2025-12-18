using MediatR;
using System.Text.Json;


namespace StockQuote.Service.ExchangeRates
{
    public static class ExchangeRatesEndpoints
    {
        public sealed class GetRequest : IRequest<Response>
        {
            public static readonly GetRequest Empty = new();
        }

        public sealed class Response
        {
            public string? Message { get; set; }
            public string? ContentType { get; set; }
        }

        public static void Register(WebApplication app)
        {
            app.MapGet("/exchange-rate-ecb", async (IRequestHandler<GetRequest, Response> handler, CancellationToken cancellationToken) =>
            {
                var response = await handler.Handle(GetRequest.Empty, cancellationToken);
                return TypedResults.Text(response.Message, response.ContentType);
            })
            .Produces<Response>(200);
        }

        public sealed class Handler()
            : IRequestHandler<GetRequest, Response>
        {
            public async Task<Response> Handle(GetRequest content, CancellationToken cancellationToken)
            {
                using HttpClient client = new HttpClient()
                {
                    BaseAddress = new Uri("https://www.ecb.europa.eu/")
                };

                using var response = await client.GetAsync("stats/eurofxref/eurofxref-daily.xml", cancellationToken);
                response.EnsureSuccessStatusCode();

                return new Response()
                {
                    Message = await response.Content.ReadAsStringAsync(cancellationToken),
                    ContentType = response.Content.Headers.ContentType?.MediaType
                };
            }
        }
    }
}
