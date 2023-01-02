using Domain.Errors;
using Domain.Models;
using Domain.Repositories.Customer;
using Domain.Repositories.Employee;
using Domain.Repositories.Order;
using Domain.Repositories.Product;
using Domain.UseCases.Employee;
using Domain.UseCases.Order;
using Domain.UseCases.Product;
using MediatR;

namespace Jake.Requests.Product;

public class Create
{
    public class Handler : IRequestHandler<Command, Result>
    {
        private readonly CreateProductUseCase _createProductUseCase;

        public Handler(CreateProductUseCase createProductUseCase)
        {
            _createProductUseCase = createProductUseCase;
        }

        public async Task<Result> Handle(Command request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _createProductUseCase.Execute(request.ToDto());
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

        public CreateProductDto ToDto() =>
            new()
            {
                BusinessId = Request.BusinessId,
                Name = Request.Name,
                Price = Request.Price,
                TaxRate = Request.TaxRate,
                Enabled = Request.Enabled,
                Description = Request.Description,
                Image = Request.Image
            };
    }

    public class Request
    {
        public long BusinessId { get; set; }
        public string Name { get; set; } = null!;
        public decimal Price { get; set; }
        public decimal TaxRate { get; set; }
        public bool Enabled { get; set; }
        public string Description { get; set; } = null!;
        public string Image { get; set; } = null!;
    }

    public class Result
    {
        public string? Error { get; set; }
        public long Id { get; set; }
    }
}