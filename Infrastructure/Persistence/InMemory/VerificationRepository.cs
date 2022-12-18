using Domain.Errors;
using Domain.Repositories.Verification;
using Infrastructure.Database;
using Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using Verification = Domain.Models.Verification;

namespace Infrastructure.Persistence.InMemory;

public class VerificationRepository : IVerificationRepository
{
    private readonly InMemoryDbContext _context;

    public VerificationRepository(InMemoryDbContext context)
    {
        _context = context;
    }

    public async Task<Verification> Create(CreateVerificationDto verificationDto)
    {
        var verification = new Data.Verification
            { CustomerId = verificationDto.CustomerId, Verified = false, VerificationToken = Guid.NewGuid().ToString() };
        await _context.Verifications.AddAsync(verification);
        await _context.SaveChangesAsync();
        return verification.ToDomain();
    }

    public async Task Verify(string verificationToken)
    {
        var verifications =
            await _context.Verifications.Where(x => x.VerificationToken == verificationToken).ToListAsync();

        if (verifications.Count != 1)
            throw new VerificationDoesNotExist(
                $"Verification with verification token '{verificationToken} does not exist");

        var verification = verifications.First();
        verification.Verified = false;

        _context.Verifications.Attach(verification);

        await _context.SaveChangesAsync();
    }
}