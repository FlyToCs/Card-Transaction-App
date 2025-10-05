using System.Globalization;
using DTOs;


namespace Quiz2.Contracts.Service_Interfaces;

public interface ICardService
{
    bool CardExist(string cardNumber, string password);
    bool CardIsActive(string cardNumber);
    float GetCardBalance(string cardNumber);
    void UpdateLoginAttempts(string cardNumber, int attempt);
    void UpdateBalance(string cardNumber, float amount);
    void ChangePassword(string cardNumber, string oldPass, string newPass);
}