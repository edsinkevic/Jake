using Domain.Errors;
using Domain.Models;
using Domain.UseCases.Customer.Session;
using MediatR;

namespace Jake.Requests.Customer;

public class Login
{
    public class Handler : IRequestHandler<Command, Result>
    {
        private readonly LoginUseCase _customerLoginUseCase;

        public Handler(LoginUseCase customerLoginUseCase)
        {
            _customerLoginUseCase = customerLoginUseCase;
        }

        public async Task<Result> Handle(Command request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _customerLoginUseCase.Execute(request.LoginCredentials);
                return new Result { CustomerSession = result };
            }
            catch (CustomerDoesNotExist e)
            {
                return new Result { Error = e.Message };
            }
        }
    }

    public class Result
    {
        public string? Error { get; set; }
        public CustomerSession CustomerSession { get; set; } = null!;
    }

    public class Request
    {
        public LoginCredentials LoginCredentials { get; set; } = null!;
    }

    public class Command : IRequest<Result>
    {
        public LoginCredentials LoginCredentials { get; set; } = null!;
    }
}