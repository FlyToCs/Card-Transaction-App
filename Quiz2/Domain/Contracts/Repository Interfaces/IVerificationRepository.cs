using Domain.Entities;

namespace Quiz2.Contracts.Repository_Interfaces;

public interface IVerificationRepository
{
    VerificationCode Create();
    VerificationCode GetVerificationCode();
}