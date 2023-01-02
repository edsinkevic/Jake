using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Models;

namespace Infrastructure.Models;

public partial class Data
{
    public class Business
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required] public string Name { get; set; } = null!;
        [Required] public List<Customer> Customers { get; set; } = new();

        public Domain.Models.Business ToDomain() =>
            new() { Customers = Customers.Select(x => x.ToDomain()).ToList(), Id = Id, Name = Name };
    }

}