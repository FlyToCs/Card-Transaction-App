using System.Globalization;
using DTOs;

namespace Quiz2.Contracts.Repository_Interfaces;

public interface ICardRepository
{
    GetCardDto? GetCardByNumber(string cardNumber);
    bool CardExist(string cardNumber, string password);
    bool CardIsActive(string cardNumber);
    float GetCardBalance(string cardNumber);
    void UpdateLoginAttempts(string cardNumber,int attempt);
    void UpdateCardPassword(string cardNumber, string password);
    void UpdateBalance(string cardNumber, float amount);

}