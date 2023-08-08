using FluentValidation;
using Microsoft.EntityFrameworkCore;
using MyApp.Application.CNAB;
using MyApp.CrossCutting;
using MyApp.CrossCutting.DependecyInjector;
using MyApp.Data.Context;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((hostContext, services, configuration) => {
    configuration.WriteTo.Console();
    configuration.WriteTo.File("./logs.txt");
});

builder.Services.AddHttpContextAccessor();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMediator();
builder.Services.AddServices();
builder.Services.AddRepositories();
builder.Services.AddValidatorsFromAssemblyContaining<Request>();
builder.Services.AddTransient<ExceptionHandlingMiddleware>();

var connectionString =
    builder.Configuration.GetValue<string>("ConnectionStrings:SQLConnection");

builder.Services.AddDbContext<SQLContext>(options =>
    options.UseSqlServer(connectionString));

var app = builder.Build();

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

app.UseMiddleware<ExceptionHandlingMiddleware>();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
