namespace Jake.DependencyInjection.UseCases;

public class Injector
{
    public static void Inject(WebApplicationBuilder builder)
    {
        Customer.Injector.Inject(builder);
        Customer.Session.Injector.Inject(builder);
        Business.Injector.Inject(builder);
        Verification.Injector.Inject(builder);
        Employee.Injector.Inject(builder);
        BusinessLocation.Injector.Inject(builder);
        Order.Injector.Inject(builder);
        Product.Injector.Inject(builder);
    }
}