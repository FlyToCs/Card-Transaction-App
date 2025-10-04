using Quiz2.DTOs;
using Quiz2.Entities;

namespace Quiz2.Contracts.Service_Interfaces;

public interface ICardService
{
    GetCardDto GetCardByNumber(string cardNumber);
    bool UpdateLoginAttempts(string cardNumber, int attempt);
    bool ChangePassword(string cardNumber, string password);
    void Update(GetCardDto getCardDto);
}