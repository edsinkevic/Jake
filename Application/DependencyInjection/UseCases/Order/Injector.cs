using Domain.UseCases.Order;

namespace Jake.DependencyInjection.UseCases.Order;

public class Injector
{
    public static void Inject(WebApplicationBuilder builder)
    {
        builder.Services.AddTransient<CreateOrderUseCase>();
        builder.Services.AddTransient<ConfirmOrderUseCase>();
        builder.Services.AddTransient<CompleteOrderUseCase>();
        builder.Services.AddTransient<ListOrdersUseCase>();
    }
}