using Domain.Repositories.Business;
using MediatR;

namespace Jake.Requests.Business;

public class Create
{
    public class Handler : IRequestHandler<Command, Result>
    {
        private readonly Domain.UseCases.Business.CreateUseCase _businessCreateUseCase;

        public Handler(Domain.UseCases.Business.CreateUseCase businessCreateUseCase)
        {
            _businessCreateUseCase = businessCreateUseCase;
        }

        public async Task<Result> Handle(Command request, CancellationToken cancellationToken)
        {
            var dto = request.ToDto();
            var result = await _businessCreateUseCase.Execute(dto);
            return new Result { Id = result.Id };
        }
    }

    public class Command : IRequest<Result>
    {
        public string Name { get; set; }

        public Command(string name)
        {
            Name = name;
        }

        public CreateBusinessDto ToDto()
        {
            return new CreateBusinessDto { Name = Name };
        }
    }

    public class Request
    {
        public string Name { get; set; } = null!;
    }

    public class Result
    {
        public long Id { get; set; }
    }
}