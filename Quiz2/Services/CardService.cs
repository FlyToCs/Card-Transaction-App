using Quiz2.Contracts.Repository_Interfaces;
using Quiz2.Contracts.Service_Interfaces;
using Quiz2.DTOs;
using Quiz2.Entities;

namespace Quiz2.Services;

public class CardService(ICardRepository cardRepository) : ICardService
{
    private readonly ICardRepository _cardRepository = cardRepository;



    public GetCardDto GetCardByNumber(string cardNumber)
    {
        var card = _cardRepository.GetCardByNumber(cardNumber);
        if (card == null)
            throw new Exception("the card number is invalid");
        if (card.CardNumber.Length != 16)
            throw new Exception("the card number should be 16 number");

        return card;
    }

    public bool UpdateLoginAttempts(string cardNumber, int attempt)
    {
        return _cardRepository.UpdateLoginAttempts(cardNumber, attempt);
    }

    public void Update(GetCardDto getCardDto)
    {
        _cardRepository.Update(getCardDto);
    }
}