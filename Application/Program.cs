using System.Text.Json.Serialization;
using Domain.Email;
using Domain.Repositories;
using Domain.Repositories.Business;
using Domain.Repositories.BusinessLocation;
using Domain.Repositories.Customer;
using Domain.Repositories.Customer.Session;
using Domain.Repositories.Employee;
using Domain.Repositories.Order;
using Domain.Repositories.Payment;
using Domain.Repositories.Product;
using Domain.Repositories.Verification;
using Infrastructure.Database;
using Infrastructure.Email;
using Infrastructure.Persistence.InMemory;
using MediatR;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
    .AddJsonOptions(config => config.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(config =>
    config.CustomSchemaIds(x => x.FullName)
);
builder.Services.AddMediatR(typeof(Program));

builder.Services.AddTransient<IBusinessRepository, BusinessRepository>();
builder.Services.AddTransient<ICustomerRepository, CustomerRepository>();
builder.Services.AddTransient<IVerificationRepository, VerificationRepository>();
builder.Services.AddTransient<ICustomerSessionRepository, CustomerSessionRepository>();
builder.Services.AddTransient<IBusinessLocationRepository, BusinessLocationRepository>();
builder.Services.AddTransient<IOrderRepository, OrderRepository>();
builder.Services.AddTransient<IPaymentRepository, PaymentRepository>();
builder.Services.AddTransient<IProductRepository, ProductRepository>();
builder.Services.AddTransient<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddDbContext<InMemoryDbContext>();
Jake.DependencyInjection.UseCases.Injector.Inject(builder);
builder.Services.AddTransient<IVerificationSender, VerificationSender>();

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