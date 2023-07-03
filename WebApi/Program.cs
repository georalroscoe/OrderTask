
using Application;
using Microsoft.AspNetCore.Builder;
using DataAccess.Repositories;
using DataAccess;
using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using WebApi;
using Application.Interfaces;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
var connstr = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddMvc().AddControllersAsServices();
builder.Services.AddDbContext<ECommerceContext>(options => options.UseSqlServer(connstr));
builder.Services.AddScoped<DbContext, ECommerceContext>()
    .AddScoped<IUnitOfWork, UnitOfWork>()
    .AddTransient<IGenericRepository<Order>, GenericRepository<Order>>()
    .AddTransient<IGenericRepository<Customer>, GenericRepository<Customer>>()
   
    .AddTransient<IGenericRepository<Product>, GenericRepository<Product>>()
    .AddTransient<IGenericRepository<OrderProduct>, GenericRepository<OrderProduct>>()
    .AddTransient<ICreateOrders, OrderCreator>();
    

  


builder.Services.AddControllers();
builder.Services.AddSwaggerGen();


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    // Enable middleware to serve generated Swagger as a JSON endpoint.
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();