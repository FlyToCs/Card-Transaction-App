using Domain.Entities;
using Quiz2.Contracts.Repository_Interfaces;
using Quiz2.Contracts.Service_Interfaces;

namespace Services;

public class VerificationService(IVerificationRepository verificationRepository) : IVerificationService
{
    private readonly IVerificationRepository _verificationRepository = verificationRepository;

    public VerificationCode Create()
    {
        return _verificationRepository.Create();
    }

    public VerificationCode GetVerificationCode()
    {
        return _verificationRepository.GetVerificationCode();
    }
}