using Domain.Errors;
using Domain.UseCases.Customer;
using MediatR;

namespace Jake.Requests.Customer;

public class Delete
{
    public class Handler : IRequestHandler<Command, Result>
    {
        private readonly DeleteUseCase _customerDeleteUseCase;

        public Handler(DeleteUseCase customerDeleteUseCase)
        {
            _customerDeleteUseCase = customerDeleteUseCase;
        }

        public async Task<Result> Handle(Command request, CancellationToken cancellationToken)
        {
            try
            {
                await _customerDeleteUseCase.Execute(request.Request.CustomerId);
                return new Result();
            }
            catch (CustomerDoesNotExist e)
            {
                return new Result { Error = e.Message };
            }
        }
    }

    public class Command : IRequest<Result>
    {
        public Request Request { get; set; } = null!;
    }

    public class Request
    {
        public long CustomerId { get; set; }
    }

    public class Result
    {
        public string? Error { get; set; }
    }
}