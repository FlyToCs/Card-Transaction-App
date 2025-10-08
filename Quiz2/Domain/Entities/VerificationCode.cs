using System.Security.Cryptography;

namespace Domain.Entities;

public class VerificationCode
{
    public int Code { get; set; } = GenerateSecureCode(5);
    public DateTime CreationDate { get; set; } = DateTime.Now;

    private static int GenerateSecureCode(int length)
    {
        int max = (int)Math.Pow(10, length);
        int number = RandomNumberGenerator.GetInt32(0, max);
        return number; 
    }
}