using Quiz2.Entities;

namespace Quiz2.Contracts.Repository_Interfaces;

public interface ICardRepository
{
    Card? GetCard(int id);
    Card? GetCardByNumber(string cardNumber);
}