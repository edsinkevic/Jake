using Domain.UseCases.Customer;

namespace Jake.DependencyInjection.UseCases.Customer;

public static class Injector
{
    public static void Inject(WebApplicationBuilder builder)
    {
        builder.Services.AddTransient<CreateUseCase>();
        builder.Services.AddTransient<DeleteUseCase>();
        builder.Services.AddTransient<UpdateUseCase>();
        builder.Services.AddTransient<ListUseCase>();
    }
}