namespace Domain.Models;

public class Category
{
    public long Id { get; set; }
    public Business? Business { get; set; }
    public string Name { get; set; } = null!;
    public Category? ParentCategory { get; set; }
}