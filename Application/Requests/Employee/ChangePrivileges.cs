using Domain.Errors;
using Domain.Models;
using Domain.Repositories.Employee;
using Domain.UseCases.Employee;
using MediatR;

namespace Jake.Requests.Employee;

public class ChangePrivileges
{
    public class Handler : IRequestHandler<Command, Result>
    {
        private readonly ChangePrivilegesUseCase _changePrivilegesUseCase;

        public Handler(ChangePrivilegesUseCase changePrivilegesUseCase)
        {
            _changePrivilegesUseCase = changePrivilegesUseCase;
        }

        public async Task<Result> Handle(Command request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _changePrivilegesUseCase.Execute(request.ToDto());
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

        public ChangeEmployeePrivilegesDto ToDto() =>
            new()
            {
                EmployeeId = Request.EmployeeId,
                RemovePrivileges = Request.RemovePrivileges,
                AddPrivileges = Request.AddPrivileges
            };
    }

    public class Request
    {
        public long EmployeeId { get; set; }
        public List<Privilege> RemovePrivileges { get; set; } = null!;
        public List<Privilege> AddPrivileges { get; set; } = null!;
    }

    public class Result
    {
        public string? Error { get; set; }
        public long Id { get; set; }
    }
}