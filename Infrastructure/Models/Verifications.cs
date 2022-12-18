using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Models;

public partial class Data
{
    public class Verification
    {
        public long Id { get; set; }
        public bool Verified { get; set; }
        public long CustomerId { get; set; }
        public string VerificationToken { get; set; } = null!;
        [ForeignKey("CustomerId")] public Customer Customer { get; set; } = null!;

        public Domain.Models.Verification ToDomain() => new()
        {
            Customer = Customer.ToDomain(), CustomerId = CustomerId, Id = Id, VerificationToken = VerificationToken,
            Verified = Verified
        };
    }
    
}