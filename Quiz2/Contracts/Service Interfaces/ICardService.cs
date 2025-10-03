using Quiz2.Entities;

namespace Quiz2.Contracts.Service_Interfaces;

public interface ICardService
{
    Card GetCard(int id);
    Card GetCardByNumber(string cardNumber);
}