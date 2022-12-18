namespace Domain.Repositories.Verification;

public interface IVerificationRepository
{
    public Task<Models.Verification> Create(CreateVerificationDto verificationDto);
    public Task Verify(string verificationToken);
}