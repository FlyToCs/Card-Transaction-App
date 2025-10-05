using System.Globalization;
using DTOs;

namespace Quiz2.Contracts.Repository_Interfaces;

public interface ICardRepository
{
    GetCardDto? GetCardByNumber(string cardNumber);
    GetCardDetailsDto? GetCardDetails(string cardNumber);
    bool CardExist(string cardNumber, string password);
    bool CardIsActive(string cardNumber);
    float GetCardBalance(string cardNumber);
    int GetCardLoginAttempt(string cardNumber);
    DateTime GetLastLoginTime(string cardNumber);
    void UpdateLoginAttempts(string cardNumber,int attempt);
    void UpdateCardPassword(string cardNumber, string password);
    void UpdateLastTransferDate(string cardNumber, DateOnly dateOnly);
    void UpdateLastLoginTime(string cardNumber, DateTime datetime);
    void UpdateDailyTransferAmount(string cardNumber, float amount);
    void UpdateBalance(string cardNumber, float amount);

}