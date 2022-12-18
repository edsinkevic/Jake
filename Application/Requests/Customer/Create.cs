using Domain.Repositories.Customer;
using Domain.UseCases.Customer;
using MediatR;

namespace Jake.Requests.Customer;

public class Create
{
    public class Handler : IRequestHandler<Command, Result>
    {
        private readonly CreateUseCase _customerCreateUseCase;

        public Handler(CreateUseCase customerCreateUseCase)
        {
            _customerCreateUseCase = customerCreateUseCase;
        }

        public async Task<Result> Handle(Command request, CancellationToken cancellationToken)
        {
            var result = await _customerCreateUseCase.Execute(request.ToDto());
            return new Result { Id = result.Id };
        }
    }

    public class Command : IRequest<Result>
    {
        public Request Request { get; set; } = null!;

        public CreateCustomerDto ToDto() =>
            new()
            {
                Address = Request.Address,
                BusinessId = Request.BusinessId,
                Email = Request.Email,
                Password = Request.Password,
                PhoneNumber = Request.PhoneNumber,
                Username = Request.Username
            };
    }

    public class Request
    {
        public long BusinessId { get; set; }
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Address { get; set; } = null!;
    }

    public class Result
    {
        public long Id { get; set; }
    }
}