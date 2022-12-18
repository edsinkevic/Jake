using Domain.UseCases.Customer.Session;

namespace Jake.DependencyInjection.UseCases.Customer.Session;
public static class Injector
{
    public static void Inject(WebApplicationBuilder builder)
    {
        builder.Services.AddTransient<LoginUseCase>();
        builder.Services.AddTransient<LogoutUseCase>();
    }
}