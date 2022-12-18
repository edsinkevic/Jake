using Domain.Errors;
using Domain.UseCases.Verification;
using MediatR;

namespace Jake.Requests.Customer;

public class CreateVerify
{
    public class Handler : IRequestHandler<Command, Result>
    {
        private readonly VerifyUseCase _verifyUseCaseCreation;

        public Handler(VerifyUseCase verifyUseCaseCreation)
        {
            _verifyUseCaseCreation = verifyUseCaseCreation;
        }

        public async Task<Result> Handle(Command request, CancellationToken cancellationToken)
        {
            try
            {
                await _verifyUseCaseCreation.Execute(request.Request.VerificationToken);
            }
            catch (VerificationDoesNotExist e)
            {
                return new Result { Error = e.Message };
            }

            return new Result();
        }
    }

    public class Command : IRequest<Result>
    {
        public Request Request { get; set; } = null!;
    }

    public class Request
    {
        public string VerificationToken { get; set; } = null!;
    }

    public class Result
    {
        public string? Error { get; set; }
    }
}