using Domain.Errors;
using Domain.Repositories.Customer;
using Domain.Repositories.Employee;
using Domain.UseCases.Employee;
using MediatR;

namespace Jake.Requests.Employee;

public class Create
{
    public class Handler : IRequestHandler<Command, Result>
    {
        private readonly CreateEmployeeUseCase _createEmployeeUseCase;

        public Handler(CreateEmployeeUseCase createEmployeeUseCase)
        {
            _createEmployeeUseCase = createEmployeeUseCase;
        }

        public async Task<Result> Handle(Command request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _createEmployeeUseCase.Execute(request.ToDto());
                return new Result { Id = result.Id };
            }
            catch (BusinessDoesNotExist e)
            {
                return new Result { Error = e.Message };
            }
        }
    }

    public class Command : IRequest<Result>
    {
        public Request Request { get; set; } = null!;

        public CreateEmployeeDto ToDto() =>
            new()
            {
                BusinessId = Request.BusinessId,
                Email = Request.Email,
                Password = Request.Password,
            };
    }

    public class Request
    {
        public long BusinessId { get; set; }
        public string Password { get; set; } = null!;
        public string Email { get; set; } = null!;
    }

    public class Result
    {
        public string? Error { get; set; }
        public long Id { get; set; }
    }
}