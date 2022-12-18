namespace Domain.Models;

public class Product
{
    public long Id { get; set; }
    public Business? Business { get; set; }
    public string Name { get; set; } = null!;
    public decimal Price { get; set; }
    public decimal TaxRate { get; set; }
    public bool Enabled { get; set; }
    public string Description { get; set; } = null!;
    public string Image { get; set; } = null!;
}