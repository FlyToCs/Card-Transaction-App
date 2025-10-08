
using Domain.Entities;

namespace Quiz2.Contracts.Service_Interfaces;

public interface IVerificationService
{
    VerificationCode Create();
    VerificationCode GetVerificationCode();
}
