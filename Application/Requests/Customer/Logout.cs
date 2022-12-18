using Domain.Models;
using MediatR;

namespace Jake.Requests.Customer;

public class Logout
{
    public class Handler : IRequestHandler<Command, Result>
    {
        private readonly Domain.UseCases.Customer.Session.LogoutUseCase _logoutUseCaseCustomer;

        public Handler(Domain.UseCases.Customer.Session.LogoutUseCase logoutUseCaseCustomer)
        {
            _logoutUseCaseCustomer = logoutUseCaseCustomer;
        }

        public async Task<Result> Handle(Command request, CancellationToken cancellationToken)
        {
            var customerSession = await _logoutUseCaseCustomer.Execute(request.SessionToken);
            return customerSession == null
                ? new Result { Error = $"Customer session {request.SessionToken} doesn't exist" }
                : new Result { CustomerSession = customerSession };
        }
    }

    public class Command : IRequest<Result>
    {
        public string SessionToken { get; set; } = null!;
    }

    public class Result
    {
        public string? Error { get; set; }
        public CustomerSession? CustomerSession { get; set; } = null!;
    }
}