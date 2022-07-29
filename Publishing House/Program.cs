using Microsoft.EntityFrameworkCore;
using Publishing_House.Model;
using Publishing_House.Model.DatabaseModels;
using Publishing_House.Services.Contracts;
using Publishing_House.Services.Implementations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
string connection = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddControllers();

builder.Services.AddDbContext<PublishingHouseContext>(opt => opt.UseSqlServer(connection));
builder.Services.AddTransient<IBookService, BookService>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
