using DTOs;

namespace Quiz2.Contracts.Repository_Interfaces;

public interface ICardRepository
{
    GetCardDto? GetCardByNumber(string cardNumber);
    bool UpdateLoginAttempts(string cardNumber,int attempt);
    bool UpdateCardPassword(string cardNumber, string password);
    void Update(GetCardDto getCardDto);
}