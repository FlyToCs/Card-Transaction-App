using Quiz2.Contracts.Repository_Interfaces;
using Quiz2.Contracts.Service_Interfaces;
using Quiz2.Entities;

namespace Quiz2.Services;

public class CardService(ICardRepository cardRepository) : ICardService
{
    private readonly ICardRepository _cardRepository = cardRepository;

    public Card GetCard(int id)
    {
        var card = _cardRepository.GetCard(id);
        if (card == null)
            throw new Exception("the card number is invalid");
        if (card.CardNumber.Length !=16)
            throw new Exception("the card number should be 16 number");
        

        return card;
        
    }

    public Card GetCardByNumber(string cardNumber)
    {
        var card = _cardRepository.GetCardByNumber(cardNumber);
        if (card == null)
            throw new Exception("the card number is invalid");
        if (card.CardNumber.Length != 16)
            throw new Exception("the card number should be 16 number");

        return card;
    }
}