using MyApp.Data.Context;
using Microsoft.EntityFrameworkCore;
using MyApp.CrossCutting.DependecyInjector;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMediator();
builder.Services.AddServices();
builder.Services.AddRepositories();

var connectionString =
    builder.Configuration.GetValue<string>("ConnectionStrings:SQLConnection");

builder.Services.AddDbContext<SQLContext>(options =>
    options.UseSqlServer(connectionString));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(q =>
    q.AllowAnyOrigin()
     .AllowAnyMethod()
     .AllowAnyHeader()
);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
