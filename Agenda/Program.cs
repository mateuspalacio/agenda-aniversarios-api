using Agenda.Exceptions;
using Agenda.Filters;
using Agenda.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var services = builder.Services;
var configuration = builder.Configuration;

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

services.AddDbContext<AppDbContext>(opt => opt.UseMySql(configuration.GetConnectionString("AgendaContext"), ServerVersion.AutoDetect(configuration.GetConnectionString("AgendaContext"))));
Console.WriteLine(configuration.GetConnectionString("AgendaContext"));
services.AddScoped<IPessoaRepository, PessoaRepository>();
services.Configure<ApiBehaviorOptions>(options =>
{
    options.InvalidModelStateResponseFactory = act =>
    {
        DefaultException d = new DefaultException();
        return d.CustomErrorResponse(act);
    };
});
var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
app.UseSwagger();
app.UseSwaggerUI();
//}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
