using System.Net.Http.Headers;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

//Add services to the controller
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();


var app = builder.Build();

app.UseHttpsRedirection();

app.MapGet("/", () => "API is working fine");

app.MapControllers();

app.Run();


