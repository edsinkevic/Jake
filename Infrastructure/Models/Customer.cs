using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Models;

public partial class Data
{
    public class Customer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required] public long BusinessId { get; set; }

        [ForeignKey("BusinessId")] [Required] public Business Business { get; set; } = null!;
        [Required] public string Username { get; set; } = null!;
        [Required] public string Password { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        [Required] public string Email { get; set; } = null!;
        public string Address { get; set; } = null!;

        public List<CustomerSession> Sessions { get; set; } = null!;

        public Domain.Models.Customer ToDomain() => new()
        {
            BusinessId = BusinessId, Email = Email, Id = Id, PasswordHash = Password,
        };
    }
}