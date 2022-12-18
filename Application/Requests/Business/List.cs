using MediatR;

namespace Jake.Requests.Business;

public class List
{
    public class Handler : IRequestHandler<Query, Result>
    {
        private readonly Domain.UseCases.Business.ListUseCase _listUseCaseBusinesses;

        public Handler(Domain.UseCases.Business.ListUseCase listUseCaseBusinesses)
        {
            _listUseCaseBusinesses = listUseCaseBusinesses;
        }

        public async Task<Result> Handle(Query request, CancellationToken cancellationToken)
        {
            return new Result { Businesses = await _listUseCaseBusinesses.Execute() };
        }
    }

    public class Query : IRequest<Result>
    {
    }

    public class Result
    {
        public IEnumerable<Domain.Models.Business> Businesses { get; set; } = null!;
    }
}