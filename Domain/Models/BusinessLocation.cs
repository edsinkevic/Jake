namespace Domain.Models;

public class BusinessLocation
{
    public long Id { get; set; }
    public Business? Business { get; set;}
    public string Name { get; set; } = null!;
    public string Street { get; set; } = null!;
    public string City { get; set; } = null!;
    public string ZipCode { get; set; } = null!;
    public string? PhoneNumber { get; set; }
}