namespace Domain.Models;

public class CustomerSession
{
    public long Id { get; set; }
    public long CustomerId { get; set; }
    public string SessionToken { get; set; } = null!;
    public DateTime Expiry { get; set; }

    public bool Expired(DateTime now) => now.CompareTo(Expiry) > 0;
    public void Expire() => this.Expiry = DateTime.Now.AddMinutes(-2);
}