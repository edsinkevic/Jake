using Domain.Email;
using Domain.Repositories.Customer;
using Domain.Repositories.Verification;

namespace Domain.UseCases.Customer;

public class CreateUseCase
{
    private readonly ICustomerRepository _customers;
    private readonly IVerificationRepository _verifications;
    private readonly IVerificationSender _verificationSender;

    public CreateUseCase(ICustomerRepository customers, IVerificationRepository verifications,
        IVerificationSender verificationSender)
    {
        _customers = customers;
        _verifications = verifications;
        _verificationSender = verificationSender;
    }
    
    public async Task<Models.Customer> Execute(CreateCustomerDto customerDto)
    {
        var customer = await _customers.Create(customerDto);

        var verification = await _verifications.Create(new CreateVerificationDto
            { CustomerId = customer.Id, VerificationToken = GenerateVerificationToken() });
        
        _verificationSender.Send(customer.Email, verification.VerificationToken);

        return customer;
    }

    private static string GenerateVerificationToken()
    {
        return Guid.NewGuid().ToString();
    }
}