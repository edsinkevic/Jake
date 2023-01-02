using System.Threading.Tasks;
using Domain.Email;
using Domain.Errors;
using Domain.Repositories.Business;
using Domain.Repositories.Customer;
using Domain.Repositories.Verification;
using Domain.UseCases.Customer;
using Moq;
using Xunit;

namespace Domain.Tests.UseCases.Customer;

public class CreateUseCaseTest
{
    [Fact]
    public async Task BusinessDoesNotExistTest()
    {
        var customers = new Mock<ICustomerRepository>();
        var businesses = new Mock<IBusinessRepository>();
        var verifications = new Mock<IVerificationRepository>();
        var verificationSender = new Mock<IVerificationSender>();

        var dto = new CreateCustomerDto
        {
            Address = "string", BusinessId = 1, Email = "string", Password = "string", PhoneNumber = "312337",
            Username = "string"
        };

        var useCase = new CreateUseCase(customers.Object, businesses.Object, verifications.Object,
            verificationSender.Object);

        await Assert.ThrowsAsync<BusinessDoesNotExist>(async () => await useCase.Execute(dto));
    }
}