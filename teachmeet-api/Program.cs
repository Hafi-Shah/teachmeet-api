using Microsoft.EntityFrameworkCore;
using teachmeet_api.Entities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
string? connString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<TeachmeetdbContext>(options =>
    options.UseSqlServer(connString));

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseCors("AllowAll");
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();