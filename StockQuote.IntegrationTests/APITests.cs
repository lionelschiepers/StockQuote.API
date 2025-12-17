using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;
using System.Text;
using System.Text.Json;
using Xunit;

namespace StockQuote.IntegrationTests;

public class APITests(CustomWebApplicationFactory<Program> _factory) :
    IClassFixture<CustomWebApplicationFactory<Program>>
{
    private readonly HttpClient _client = _factory.CreateClient(new WebApplicationFactoryClientOptions
    {
        AllowAutoRedirect = false
    });

    [Fact]
    public async Task Status500_Returns500()
    {
        var defaultPage = await _client.GetAsync("/status500", TestContext.Current.CancellationToken);

        Assert.Equal(HttpStatusCode.InternalServerError, defaultPage.StatusCode);
    }

    [Fact]
    public async Task GraphQL_Quote_ReturnsSuccess()
    {
        var query = new
        {
            query = "query { quote(ticker: \"AAPL\") { close } }"
        };
        var json = JsonSerializer.Serialize(query);
        using var content = new StringContent(json, Encoding.UTF8, "application/json");

        var response = await _client.PostAsync("/graphql", content, TestContext.Current.CancellationToken);

        response.EnsureSuccessStatusCode();

        var responseString = await response.Content.ReadAsStringAsync(TestContext.Current.CancellationToken);
        using var jsonDoc = JsonDocument.Parse(responseString);
        var close = jsonDoc.RootElement.GetProperty("data").GetProperty("quote").GetProperty("close").GetDouble();

        Assert.Equal(0, close);
    }
}