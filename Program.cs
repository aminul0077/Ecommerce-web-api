using System.Net.Http.Headers;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();



var app = builder.Build();

app.UseHttpsRedirection();

List<Category> categories = new List<Category>();

app.MapGet("/", () => "API is working fine");
//Get
app.MapGet("/api/categories", () =>
{
    return Results.Ok(categories);
});
//Post
app.MapPost("/api/categories", () =>
{
    var newCategory = new Category
    {
        CategoryId = Guid.Parse("c2e4ea46-a651-48b5-a608-d6d47623aef7"),
        Name = "Electronics",
        Description = "Devices and gadget includung phones, laptop and other electronic equipment",
        CreatedAt = DateTime.UtcNow,

    };
    categories.Add(newCategory);
    return Results.Created($"/api/categories/{newCategory.CategoryId}", newCategory);
});

//Delete
app.MapDelete("/api/categories", () =>
{
    var foundCategory = categories.FirstOrDefault(category => category.CategoryId == Guid.Parse("c2e4ea46-a651-48b5-a608-d6d47623aef7"));
    if (foundCategory == null)
    {
        return Results.NotFound("Does not exit");
    }
    categories.Remove(foundCategory);
    return Results.NoContent();
});

//Update
app.MapPut("/api/categories", () =>
{
    var foundCategory = categories.FirstOrDefault(category => category.CategoryId == Guid.Parse("c2e4ea46-a651-48b5-a608-d6d47623aef7"));
    if (foundCategory == null)
    {
        return Results.NotFound("Does not exit!!!");
    }
    foundCategory.Name = "Smart Phone";
    foundCategory.Description = "Smart phone ia a nice category";
    return Results.NoContent();
});


app.Run();

public record Category
{
    public Guid CategoryId { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public DateTime CreatedAt { get; set; }
     
};
