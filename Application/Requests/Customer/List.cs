using MediatR;

namespace Jake.Requests.Customer;

public class List
{
    public class Handler : IRequestHandler<Query, Result>
    {
        private readonly Domain.UseCases.Customer.ListUseCase _listUseCaseCustomers;

        public Handler(Domain.UseCases.Customer.ListUseCase listUseCaseCustomers)
        {
            _listUseCaseCustomers = listUseCaseCustomers;
        }

        public async Task<Result> Handle(Query request, CancellationToken cancellationToken)
        {
            return new Result { Customers = await _listUseCaseCustomers.Execute() };
        }
    }

    public class Query : IRequest<Result>
    {
    }

    public class Result
    {
        public IEnumerable<Domain.Models.Customer> Customers { get; set; } = null!;
    }
}