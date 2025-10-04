using Quiz2.DTOs;
using Quiz2.Entities;

namespace Quiz2.Contracts.Repository_Interfaces;

public interface ICardRepository
{
    GetCardDto? GetCardByNumber(string cardNumber);
    bool UpdateLoginAttempts(string cardNumber,int attempt);
    void Update(GetCardDto getCardDto);
}