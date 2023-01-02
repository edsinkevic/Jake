using Domain.Errors;
using Domain.Repositories.BusinessLocation;
using Domain.UseCases.BusinessLocation;
using MediatR;

namespace Jake.Requests.BusinessLocations;

public class Create
{
    public class Handler : IRequestHandler<Command, Result>
    {
        private readonly CreateBusinessLocationUseCase _createBusinessLocationUseCase;

        public Handler(CreateBusinessLocationUseCase createBusinessLocationUseCase)
        {
            _createBusinessLocationUseCase = createBusinessLocationUseCase;
        }

        public async Task<Result> Handle(Command request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _createBusinessLocationUseCase.Execute(request.ToDto());
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

        public CreateBusinessLocationDto ToDto() =>
            new()
            {
                BusinessId = Request.BusinessId,
                City = Request.City,
                Name = Request.Name,
                PhoneNumber = Request.PhoneNumber,
                Street = Request.Street,
                ZipCode = Request.ZipCode
            };
    }

    public class Request
    {
        public long BusinessId { get; set; }
        public string Name { get; set; } = null!;
        public string Street { get; set; } = null!;
        public string City { get; set; } = null!;
        public string ZipCode { get; set; } = null!;
        public string? PhoneNumber { get; set; }
    }

    public class Result
    {
        public string? Error { get; set; }
        public long Id { get; set; }
    }
}