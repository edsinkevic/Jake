using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Models;

public partial class Data
{
    public class CustomerSession
    {
        public long Id { get; set; }
        public long CustomerId { get; set; }
        [ForeignKey("CustomerId")] public Customer Customer { get; set; } = null!;
        public string SessionToken { get; set; } = null!;
        public DateTime Expiry { get; set; }

        public Domain.Models.CustomerSession ToDomain() => new()
            { CustomerId = CustomerId, Expiry = Expiry, Id = Id, SessionToken = SessionToken };

        public void Expire() => this.Expiry = DateTime.Now.AddMinutes(-2);
    }
}