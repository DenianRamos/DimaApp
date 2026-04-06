using Microsoft.AspNetCore.Http.HttpResults;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => TypedResults.Redirect("/health"));

app.MapGet("/health", () =>
    TypedResults.Ok(new
    {
        status = "ok",
        service = "Dima.Api",
        timestamp = DateTimeOffset.UtcNow
    }));

app.MapGet("/v2/products", () =>
    TypedResults.Ok(new[]
    {
        new { id = 1, name = "Notebook", price = 3500.00m },
        new { id = 2, name = "Mouse", price = 120.90m }
    }));

app.Run();

public partial class Program;
