using Domain.Repositories;
using Domain.Repositories.Verification;

namespace Domain.UseCases.Verification;

public class VerifyUseCase
{
    
    private readonly IVerificationRepository _verifications;

    public VerifyUseCase(IVerificationRepository verifications)
    {
        _verifications = verifications;
    }

    public async Task Execute(string verificationToken)
    {
        await _verifications.Verify(verificationToken);
    }
}