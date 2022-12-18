namespace Domain.Repositories.Category;

public class CreateCategoryDto
{
    public long BusinessId { get; set; }
    public long ParentCategoryId { get; set; }
    public string Name { get; set; } = null!;
}