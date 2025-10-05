using DTOs;
using Quiz2.Contracts.Repository_Interfaces;
using Quiz2.Contracts.Service_Interfaces;


namespace Services;

public class CardService(ICardRepository cardRepository) : ICardService
{
    private readonly ICardRepository _cardRepository = cardRepository;


    public bool CardExist(string cardNumber, string password)
    {
        _cardRepository.CardExist(cardNumber, password);
    }

    public bool CardIsActive(string cardNumber)
    {
        _cardRepository.CardIsActive(cardNumber);
    }

    public float GetCardBalance(string cardNumber)
    {
        return _cardRepository.GetCardBalance(cardNumber);
    }

    public void UpdateLoginAttempts(string cardNumber, int attempt)
    {
        _cardRepository.UpdateLoginAttempts(cardNumber, attempt);
    }

    public void UpdateBalance(string cardNumber, float amount)
    {
        _cardRepository.UpdateBalance(cardNumber, amount);
    }

    public void ChangePassword(string cardNumber, string oldPass, string newPass)
    {
        var card = _cardRepository.GetCardByNumber(cardNumber);
        if (card.Password != oldPass)
            throw new Exception("the old pass didn't math");

        if (newPass.Length != 4)
            throw new Exception("pass length must be 4 digits");


        _cardRepository.UpdateCardPassword(cardNumber, newPass);
    }


}