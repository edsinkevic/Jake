using Domain.Email;

namespace Infrastructure.Email;

public class VerificationSender : IVerificationSender
{
    public VerificationSender()
    {
    }

    public void Send(string email, string verificationToken)
    {
        Console.WriteLine(verificationToken);
    }
}