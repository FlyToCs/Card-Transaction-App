using DTOs;
using Quiz2.Contracts.Repository_Interfaces;
using Quiz2.Contracts.Service_Interfaces;


namespace Services;

public class CardService(ICardRepository cardRepository) : ICardService
{
    private readonly ICardRepository _cardRepository = cardRepository;


    public GetCardDto GetCardByCardNumber(string cardNumber)
    {
        var card =  _cardRepository.GetCardByNumber(cardNumber);
        if (card == null)
            throw new Exception("the card didn't find");
        return card;
    }

    public GetCardDetailsDto GetCardDetails(string cardNumber)
    {
        var card = _cardRepository.GetCardDetails(cardNumber);
        if (card == null)
            throw new Exception("the card didn't find");
        return card;
    }

    public bool CardExist(string cardNumber, string password)
    {
        return _cardRepository.CardExist(cardNumber, password);
    }

    public bool CardIsActive(string cardNumber)
    {
       return _cardRepository.CardIsActive(cardNumber);
    }

    public float GetCardBalance(string cardNumber)
    {
        return _cardRepository.GetCardBalance(cardNumber);
    }

    public void UpdateLastTransferDate(string cardNumber, DateOnly dateOnly)
    {
        _cardRepository.UpdateLastTransferDate(cardNumber, dateOnly);
    }

    public void UpdateLastLoginTime(string cardNumber, DateTime datetime)
    {
        _cardRepository.UpdateLastLoginTime(cardNumber, datetime);
    }

    public void UpdateDailyTransferAmount(string cardNumber, float amount)
    {
        _cardRepository.UpdateDailyTransferAmount(cardNumber, amount);
    }

    public int GetCardLoginAttempts(string cardNumber)
    {
        return _cardRepository.GetCardLoginAttempt(cardNumber);
    }

    public DateTime GetLastLoginTime(string cardNumber)
    {
        return _cardRepository.GetLastLoginTime(cardNumber);
    }

    public void UpdateLoginAttempts(string cardNumber, int attempt)
    {
        _cardRepository.UpdateLoginAttempts(cardNumber, attempt);
    }

    public void UpdateBalance(string cardNumber, float amount)
    {
        _cardRepository.UpdateBalance(cardNumber, amount);
    }

    public void ChangePassword(string cardNumber, string newPass)
    {
        var card = _cardRepository.GetCardByNumber(cardNumber);

        if (newPass.Length != 4)
            throw new Exception("pass length must be 4 digits");


        _cardRepository.UpdateCardPassword(cardNumber, newPass);
    }


}