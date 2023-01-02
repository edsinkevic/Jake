using Domain.UseCases.Order;
using Domain.UseCases.Product;
using MediatR;

namespace Jake.Requests.Order;

public class List
{
    public class Handler : IRequestHandler<Query, Result>
    {
        private readonly ListOrdersUseCase _listOrdersUseCase;

        public Handler(ListOrdersUseCase listOrdersUseCase)
        {
            _listOrdersUseCase = listOrdersUseCase;
        }

        public async Task<Result> Handle(Query request, CancellationToken cancellationToken)
        {
            return new Result { Orders = await _listOrdersUseCase.Execute() };
        }
    }

    public class Query : IRequest<Result>
    {
    }

    public class Result
    {
        public IEnumerable<Domain.Models.Order> Orders { get; set; } = null!;
    }
}