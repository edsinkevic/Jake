using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Models;

public partial class Data
{
    public class Category
    {
        public long Id { get; set; }
        [ForeignKey("BusinessId")] public Business Business { get; set; } = null!;
        public long BusinessId { get; set; }
        public string Name { get; set; } = null!;
        [ForeignKey("ParentCategoryId")] public Data.Category? ParentCategory { get; set; }
        public long ParentCategoryId { get; set; }

        public Domain.Models.Category ToDomain() =>
            new() { Business = Business.ToDomain(), Id = Id, Name = Name, ParentCategory = ParentCategory?.ToDomain() };
    }
}