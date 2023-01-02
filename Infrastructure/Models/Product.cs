using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Models;

public partial class Data
{
    public class Product
    {
        public long Id { get; set; }
        public long BusinessId { get; set; }
        [ForeignKey("BusinessId")] public Business? Business { get; set; }
        public string Name { get; set; } = null!;
        public decimal Price { get; set; }
        public decimal TaxRate { get; set; }
        public bool Enabled { get; set; }
        public string Description { get; set; } = null!;
        public string Image { get; set; } = null!;

        public Domain.Models.Product ToDomain() =>
            new()
            {
                Business = Business?.ToDomain(),
                Name = Name,
                Price = Price,
                TaxRate = TaxRate,
                Description = Description,
                Id = Id,
                Enabled = Enabled,
                Image = Image,
            };
    }
}