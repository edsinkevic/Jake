namespace Infrastructure.Models;

public partial class Data
{
    public class CustomerSession
    {
        public long Id { get; set; }
        public long CustomerId { get; set; }
        public string SessionToken { get; set; } = null!;
        public DateTime Expiry { get; set; }

        public Domain.Models.CustomerSession ToDomain() => new()
            { CustomerId = CustomerId, Expiry = Expiry, Id = Id, SessionToken = SessionToken };
    }
}