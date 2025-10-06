using System.Globalization;
using DTOs;


namespace Quiz2.Contracts.Service_Interfaces;

public interface ICardService
{
    GetCardDto GetCardByCardNumber(string cardNumber);
    GetCardDetailsDto GetCardDetails(string cardNumber);
    GetCardForLoginDto GetCardForLoginDto(string cardNumber);
    bool CardExist(string cardNumber, string password);
    bool CardIsActive(string cardNumber);
    float GetCardBalance(string cardNumber);
    void UpdateLastTransferDate(string cardNumber, DateOnly dateOnly);
    void UpdateLoginData(CardLoginUpdateDto cardLoginUpdateDto);
    void UpdateLastLoginTime(string cardNumber, DateTime datetime);
    void UpdateDailyTransferAmount(string cardNumber, float amount);
    int GetCardLoginAttempts(string cardNumber);
    DateTime? GetLastLoginTime(string cardNumber);
    void UpdateLoginAttempts(string cardNumber, int attempt);
    void UpdateBalance(string cardNumber, float amount);
    void ChangePassword(string cardNumber, string newPass);
}