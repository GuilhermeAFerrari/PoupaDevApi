using Microsoft.EntityFrameworkCore;
using PoupaDev.API.Jobs;
using PoupaDev.API.Middlewares;
using PoupaDev.API.Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("PoupaDevCs");
builder.Services.AddDbContext<PoupaDevContext>(o => o.UseSqlServer(connectionString));

builder.Services.AddHostedService<RendimentoAutomaticoJob>();

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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

app.UseMiddleware<ErrorMiddleware>();

app.MapControllers();

app.Run();
