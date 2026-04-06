using System.Net;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace Dima.Tests;

public class ApiTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly HttpClient _client;

    public ApiTests(WebApplicationFactory<Program> factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task GetHealth_ShouldReturnOk()
    {
        var response = await _client.GetAsync("/health");

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }

    [Fact]
    public async Task GetProducts_ShouldReturnSeededItems()
    {
        var response = await _client.GetFromJsonAsync<List<ProductDto>>("/v2/products");

        Assert.NotNull(response);
        Assert.True(response!.Count >= 2);
        Assert.Contains(response, item => item.Name == "Notebook");
    }

    public sealed record ProductDto(long Id, string Name, decimal Price);
}
