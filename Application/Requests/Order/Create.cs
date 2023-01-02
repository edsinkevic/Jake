using Domain.Errors;
using Domain.Models;
using Domain.Repositories.Customer;
using Domain.Repositories.Employee;
using Domain.Repositories.Order;
using Domain.UseCases.Employee;
using Domain.UseCases.Order;
using MediatR;

namespace Jake.Requests.Order;

public class Create
{
    public class Handler : IRequestHandler<Command, Result>
    {
        private readonly CreateOrderUseCase _createOrderUseCase;

        public Handler(CreateOrderUseCase createOrderUseCase)
        {
            _createOrderUseCase = createOrderUseCase;
        }

        public async Task<Result> Handle(Command request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _createOrderUseCase.Execute(request.ToDto());
                return new Result { Id = result.Id };
            }
            catch (DomainError e)
            {
                return new Result { Error = e.Message };
            }
        }
    }

    public class Command : IRequest<Result>
    {
        public Request Request { get; set; } = null!;

        public CreateOrderDto ToDto() =>
            new()
            {
                CustomerId = Request.CustomerId,
                PaymentType = Request.PaymentType,
                ProductIds = Request.ProductIds
            };
    }

    public class Request
    {
        public long CustomerId { get; set; }
        public List<long> ProductIds { get; set; } = null!;
        public PaymentType PaymentType { get; set; }
    }

    public class Result
    {
        public string? Error { get; set; }
        public long Id { get; set; }
    }
}