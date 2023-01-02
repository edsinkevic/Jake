using Domain.UseCases.Order;
using Domain.UseCases.Product;

namespace Jake.DependencyInjection.UseCases.Product;

public class Injector
{
    public static void Inject(WebApplicationBuilder builder)
    {
        builder.Services.AddTransient<CreateProductUseCase>();
        builder.Services.AddTransient<ListProductsUseCase>();
    }
}