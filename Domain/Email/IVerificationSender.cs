namespace Domain.Email;

public interface IVerificationSender
{
    public void Send(string email, string verificationToken);
}