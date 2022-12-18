namespace Domain.Repositories.Product;

public class ListProductsDto
{
    public string ContinuationToken { get; set; } = null!;
    public int Top { get; set; }
}