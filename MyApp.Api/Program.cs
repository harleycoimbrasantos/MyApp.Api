using MyApp.Data.Context;
using Microsoft.EntityFrameworkCore;
using MyApp.CrossCutting.DependecyInjector;
using Serilog;
using static System.Net.Mime.MediaTypeNames;
using System.Text;
using FluentValidation;
using MyApp.Application.CNAB;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((hostContext, services, configuration) => {
    configuration.WriteTo.Console();
    configuration.WriteTo.File("./logs.txt");
});

Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

builder.Services.AddHttpContextAccessor();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMediator();
builder.Services.AddServices();
builder.Services.AddRepositories();
builder.Services.AddValidatorsFromAssemblyContaining(typeof(RequestValidator));

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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
