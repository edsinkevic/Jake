using Domain.UseCases.BusinessLocation;

namespace Jake.DependencyInjection.UseCases.BusinessLocation;

public class Injector
{
    public static void Inject(WebApplicationBuilder builder)
    {
        builder.Services.AddTransient<CreateBusinessLocationUseCase>();
    }
}