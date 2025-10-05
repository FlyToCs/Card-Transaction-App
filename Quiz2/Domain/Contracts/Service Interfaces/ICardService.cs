using System.Globalization;
using DTOs;


namespace Quiz2.Contracts.Service_Interfaces;

public interface ICardService
{
    GetCardDto GetCardByNumber(string cardNumber);
    bool UpdateLoginAttempts(string cardNumber, int attempt);
    bool ChangePassword(string cardNumber, string oldPass, string newPass);
    void Update(GetCardDto getCardDto);
}