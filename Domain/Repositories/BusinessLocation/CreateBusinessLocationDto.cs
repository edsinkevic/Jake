namespace Domain.Repositories.BusinessLocation;

public class CreateBusinessLocationDto
{
    public long BusinessId { get; set;}
    public string Name { get; set; } = null!;
    public string Street { get; set; } = null!;
    public string City { get; set; } = null!;
    public string ZipCode { get; set; } = null!;
    public string? PhoneNumber { get; set; }
}