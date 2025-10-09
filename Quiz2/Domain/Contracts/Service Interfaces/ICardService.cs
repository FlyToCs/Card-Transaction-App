using System.Globalization;
using DTOs;


namespace Quiz2.Contracts.Service_Interfaces;

public interface ICardService
{
    GetCardDto GetCardByCardNumber(string cardNumber);
    GetCardDetailsDto GetCardDetails(string cardNumber);
    GetCardForLoginDto GetCardForLoginDto(string cardNumber);
    void UpdateLastTransferDate(string cardNumber, DateTime dateOnly);
    void UpdateLoginData(CardLoginUpdateDto cardLoginUpdateDto);
    void UpdateDailyTransferAmount(string cardNumber, float amount);
    void UpdateBalance(string cardNumber, float amount);
    void ChangePassword(string cardNumber, string newPass);
}