using Microsoft.EntityFrameworkCore;
using OrdersAPI.Application.Interfaces.Services;
using OrdersAPI.Application.Services;
using OrdersAPI.Insfractucture.Interfaces.Repositories;
using OrdersAPI.Insfractucture;
using OrdersAPI.Insfractucture.Context;
using OrdersAPI.Insfractucture.Repositories;
using System.Globalization;
using System.Text.Json.Serialization;
using OrdersAPI.Application.Mapping;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();


builder.Services.AddControllers().AddNewtonsoftJson();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(MappingConfig));
//builder.Services.addauto (typeof(Mapping));

builder.Services.AddDbContext<ApplicationDbContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

// Inyección de dependencias
builder.Services.AddScoped(typeof(IGenericService<,,,>), typeof(GenericService<,,,>));
builder.Services.AddScoped(typeof(IGenericRepository<,>), typeof(GenericRepository<,>));
builder.Services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));

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
