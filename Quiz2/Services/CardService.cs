using DTOs;
using Quiz2.Contracts.Repository_Interfaces;
using Quiz2.Contracts.Service_Interfaces;


namespace Services;

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

    public bool ChangePassword(string cardNumber, string oldPass, string newPass)
    {
        var card = _cardRepository.GetCardByNumber(cardNumber);
        if (card.Password != oldPass)
            throw new Exception("the old pass didn't math");

        if (newPass.Length!=4)
            throw new Exception("pass length must be 4 digits");
        

        return _cardRepository.UpdateCardPassword(cardNumber, newPass);
    }

    public void Update(GetCardDto getCardDto)
    {
        _cardRepository.Update(getCardDto);
    }
}