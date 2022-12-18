namespace Infrastructure.Models;

public partial class Data
{
    public class BusinessLocation
    {
        public long Id { get; set; }
        public Business Business { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string Street { get; set; } = null!;
        public string City { get; set; } = null!;
        public string ZipCode { get; set; } = null!;
        public string? PhoneNumber { get; set; }

        public Domain.Models.BusinessLocation ToDomain()
        {
            return new Domain.Models.BusinessLocation
            {
                Business = Business.ToDomain(), City = City, Id = Id, Name = Name, PhoneNumber = PhoneNumber,
                Street = Street,
                ZipCode = ZipCode
            };
        }
    }
}