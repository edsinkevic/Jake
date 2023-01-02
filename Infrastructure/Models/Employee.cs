using Domain.Models;

namespace Infrastructure.Models;

public partial class Data
{
    public class Employee
    {
        public long Id { get; set; }
        public Business? Business { get; set; }
        public List<Privilege> Privileges { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Email { get; set; } = null!;

        public List<Domain.Models.Privilege> DomainPrivileges() => Privileges.Select(x => x.PrivilegeType).ToList();

        public Domain.Models.Employee ToDomain() => new()
        {
            Email = Email,
            Id = Id,
            Password = Password,
            Privileges = Privileges.Select(x => x.PrivilegeType).ToList(),
        };
    }
}