using Domain.Models;

namespace Infrastructure.Models;

public partial class Data
{
    public class Employee
    {
        public long Id { get; set; }
        public Business? Business { get; set; }
        public List<Privilege> Privileges { get; set; } = null!;
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Fullname { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string City { get; set; } = null!;
        public string ZipCode { get; set; } = null!;

        public Domain.Models.Employee ToDomain() => new()
        {
            Address = Address,
            City = City,
            Email = Email,
            Fullname = Fullname,
            Id = Id,
            Password = Password,
            PhoneNumber = PhoneNumber,
            Privileges = Privileges,
            Username = Username
        };
    }
}