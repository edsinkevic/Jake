using Domain.UseCases.Business;

namespace Jake.DependencyInjection.UseCases.Business;

public class Injector
{
    public static void Inject(WebApplicationBuilder builder)
    {
        builder.Services.AddTransient<CreateUseCase>();
        builder.Services.AddTransient<ListUseCase>();
    }
}