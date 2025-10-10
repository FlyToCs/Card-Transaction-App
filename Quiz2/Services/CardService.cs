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

    public GetCardForLoginDto GetCardForLoginDto(string cardNumber)
    {
        var card = _cardRepository.CardForLoginDto(cardNumber);
        if (card == null)
            throw new Exception("the card didn't find");

        return card;
    }


    public void UpdateLastTransferDate(string cardNumber, DateTime dateOnly)
    {
        _cardRepository.UpdateLastTransferDate(cardNumber, dateOnly);
    }

    public void UpdateLoginData(CardLoginUpdateDto cardLoginUpdateDto)
    {
        _cardRepository.UpdateLoginData(cardLoginUpdateDto);
    }


    public void UpdateDailyTransferAmount(string cardNumber, float amount)
    {
        _cardRepository.UpdateDailyTransferAmount(cardNumber, amount);
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

    public void SaveChanges()
    {
        _cardRepository.SaveChanges();
    }
}