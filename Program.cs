using System.Net.Http.Headers;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();



var app = builder.Build();

app.UseHttpsRedirection();

List<Category> categories = new List<Category>();

app.MapGet("/", () => "API is working fine");
//Get
app.MapGet("/api/categories", ([FromQuery] string searchValue ="") =>
{
    if (searchValue != null)
    {
        var searchCategories = categories.Where(c => c.Name.Contains(searchValue, StringComparison.OrdinalIgnoreCase)).ToList();
        return Results.Ok(searchCategories);
    }
    return Results.Ok(categories);
});
//Post
app.MapPost("/api/categories", ([FromBody] Category categoryData) =>
{
    var newCategory = new Category
    {
        CategoryId = Guid.NewGuid(),
        Name = categoryData.Name,
        Description = categoryData.Description,
        CreatedAt = DateTime.UtcNow,

    };
    categories.Add(newCategory);
    return Results.Created($"/api/categories/{newCategory.CategoryId}", newCategory);
});

//Delete
app.MapDelete("/api/categories/{categoryId}", (Guid categoryId) =>
{
    var foundCategory = categories.FirstOrDefault(category => category.CategoryId == categoryId);
    if (foundCategory == null)
    {
        return Results.NotFound("Does not exit");
    }
    categories.Remove(foundCategory);
    return Results.NoContent();
});

//Update
app.MapPut("/api/categories/{categoryId}", (Guid categoryId, [FromBody] Category categoryData) =>
{
    var foundCategory = categories.FirstOrDefault(category => category.CategoryId == categoryId);
    if (foundCategory == null)
    {
        return Results.NotFound("Does not exit!!!");
    }
    foundCategory.Name = categoryData.Name;
    foundCategory.Description = categoryData.Description;
    return Results.NoContent();
});


app.Run();

public record Category
{
    public Guid CategoryId { get; set; }

    public string Name { get; set; }

    public string? Description { get; set; }

    public DateTime CreatedAt { get; set; }
     
};
