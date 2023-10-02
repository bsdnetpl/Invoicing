using FluentValidation;
using Invoicing.DB;
using Invoicing.DTO;
using Invoicing.Middleware;
using Invoicing.Models;
using Invoicing.Services;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Model;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ConnectMssql>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("CS")));
builder.Services.AddScoped<IInvoceService, InvoceService>();
builder.Services.AddAutoMapper(typeof(AutoMapperConfig));
builder.Services.AddScoped<IValidator<CustomerDTO>, CustomerDTOValistion>();
builder.Services.AddValidatorsFromAssemblyContaining<CustomerDTOValistion>();
builder.Services.AddScoped<IValidator<Seller>, SellerValidation>();
builder.Services.AddValidatorsFromAssemblyContaining<SellerValidation>();
builder.Services.AddScoped<Validation>();
//builder.Services.AddScoped<MiddlewareServices>();
builder.Services.AddScoped<ICustomerServices, CustomerServices>();
builder.Services.AddScoped<ISellerServices, SellerServices>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
//app.UseMiddleware<MiddlewareServices>();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
