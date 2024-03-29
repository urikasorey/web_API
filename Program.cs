
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using RESTful_Web_API.Data;
using RESTful_Web_API.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register Library Service to use it with Dependency Injection in Controllers
builder.Services.AddTransient<ILibraryService, LibraryService>();

builder.Services.AddControllers().AddJsonOptions(x =>
	x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

// Register database
builder.Services.AddDbContext<AppDbContext>(options =>
	options.UseSqlServer(builder.Configuration.GetConnectionString("connect")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();