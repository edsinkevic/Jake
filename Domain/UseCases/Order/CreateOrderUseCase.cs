using Domain.Errors;
using Domain.Models;
using Domain.Repositories.Customer;
using Domain.Repositories.Order;
using Domain.Repositories.Payment;
using Domain.Repositories.Product;

namespace Domain.UseCases.Order;

public class CreateOrderUseCase
{
    private readonly IOrderRepository _orders;
    private readonly IProductRepository _products;
    private readonly ICustomerRepository _customerRepository;
    private readonly IPaymentRepository _paymentRepository;

    public CreateOrderUseCase(IOrderRepository orders, IProductRepository products,
        ICustomerRepository customerRepository, IPaymentRepository paymentRepository)
    {
        _orders = orders;
        _products = products;
        _customerRepository = customerRepository;
        _paymentRepository = paymentRepository;
    }

    public async Task<Models.Order> Execute(CreateOrderDto dto)
    {
        var customer = await _customerRepository.Find(dto.CustomerId);
        if (customer == null)
            throw new CustomerDoesNotExist($"Customer {dto.CustomerId} does not exist");

        var idsExist = await _products.IdsExist(dto.ProductIds);
        if (!idsExist)
            throw new ProductsDontExist($"Products {string.Join(",", dto.ProductIds)} don't exist");

        var order = await _orders.Create(dto);
        var payment = await _paymentRepository.Create(order.Id, PaymentType.BankTransaction);
        return order;
    }
}