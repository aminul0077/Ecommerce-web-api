using System.Net.Http.Headers;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();



var app = builder.Build();

app.UseHttpsRedirection();

var products = new List<Product>()
{
    new Product("Samsung S25 Ultra",100000),
    new Product("iPhone 16 pro max",110000),
};
app.MapGet("/products", () =>
{
    return Results.Ok(products);
});

app.Run();

public record Product(string Name, decimal Price);
