using Domain.UseCases.Employee;

namespace Jake.DependencyInjection.UseCases.Employee;

public static class Injector
{
    public static void Inject(WebApplicationBuilder builder)
    {
        builder.Services.AddTransient<CreateEmployeeUseCase>();
        builder.Services.AddTransient<ChangePrivilegesUseCase>();
    }
}