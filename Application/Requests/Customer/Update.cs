using Domain.Errors;
using Domain.Repositories.Customer;
using MediatR;

namespace Jake.Requests.Customer;

public class Update
{
    public class Handler : IRequestHandler<Command, Result>
    {
        private readonly Domain.UseCases.Customer.UpdateUseCase _customerUpdateUseCase;

        public Handler(Domain.UseCases.Customer.UpdateUseCase customerUpdateUseCase)
        {
            _customerUpdateUseCase = customerUpdateUseCase;
        }

        public async Task<Result> Handle(Command request, CancellationToken cancellationToken)
        {
            try
            {
                await _customerUpdateUseCase.Execute(request.Request.ToDto());
                return new Result();
            }
            catch (CustomerDoesNotExist e)
            {
                return new Result { Error = e.Message };
            }
        }
    }

    public class Command : IRequest<Result>
    {
        public Request Request { get; set; } = null!;
    }

    public class Request
    {
        public long CustomerId { get; set; }
        public string? Username { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }

        public UpdateCustomerDto ToDto() => new()
        {
            CustomerId = CustomerId, Username = Username, Address = Address, Email = Email,
            PhoneNumber = PhoneNumber
        };
    }

    public class Result
    {
        public string? Error { get; set; }
    }
}