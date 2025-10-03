using Quiz2.Contracts.Repository_Interfaces;
using Quiz2.Contracts.Service_Interfaces;
using Quiz2.Entities;

namespace Quiz2.Services;

public class CardService(ICardRepository cardRepository) : ICardService
{
    private readonly ICardRepository _cardRepository = cardRepository;

    public Card GetCard(int id)
    {
        throw new NotImplementedException();
    }

    public Card GetCardByNumber(string cardNumber)
    {
        throw new NotImplementedException();
    }
}