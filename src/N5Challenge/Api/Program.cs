using Core.CQRS.Commands;
using Core.Depedencies;
using Core.Interfaces.Repositories;
using Core.Interfaces.Services;
using Core.Services;
using Infrastructure.Data;
using Infrastructure.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog(((ctx, lc) => lc.ReadFrom.Configuration(ctx.Configuration)));
builder.Services.AddLogging();
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configuración de SQL Server
builder.Services.AddDbContext<AppDbContext>(options =>
	options.UseSqlServer(builder.Configuration.GetConnectionString("DBConnection")));

// Inyección de dependencias
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

// Elasticsearch
//var elasticsearchUri = builder.Configuration["ElasticSearch:Uri"];
builder.Services.AddSingleton<IElasticSearchService, ElasticSearchService>();

// MediatR
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(RequestPermissionCommand).Assembly));
builder.Services.AddAutoMapper(cfg => cfg.AddProfile<MappingProfile>());

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
