using Domain.UseCases.Customer;
using Domain.UseCases.Verification;

namespace Jake.DependencyInjection.UseCases.Verification;

public static class Injector
{
    public static void Inject(WebApplicationBuilder builder)
    {
        builder.Services.AddTransient<VerifyUseCase>();
    }
}