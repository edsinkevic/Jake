using Domain.UseCases.Product;
using MediatR;

namespace Jake.Requests.Product;

public class List
{
    public class Handler : IRequestHandler<Query, Result>
    {
        private readonly ListProductsUseCase _listProductsUseCase;

        public Handler(ListProductsUseCase listProductsUseCase)
        {
            _listProductsUseCase = listProductsUseCase;
        }

        public async Task<Result> Handle(Query request, CancellationToken cancellationToken)
        {
            return new Result { Products = await _listProductsUseCase.Execute() };
        }
    }

    public class Query : IRequest<Result>
    {
    }

    public class Result
    {
        public IEnumerable<Domain.Models.Product> Products { get; set; } = null!;
    }
}