using System.Security.AccessControl;
using Quiz2.Contracts.Service_Interfaces;
using Quiz2.DTOs;

namespace Quiz2.Services;

public class AuthenticationService(ICardService cardService) : IAuthenticationService
{
    private readonly ICardService _cardService = cardService;
    public CardLoginDto Login(string cardNumber, string password)
    {
        var card =_cardService.GetCardByNumber(cardNumber);
        if (card.Password != password)
        {
            card.LoginAttempts += 1;
            _cardService.Update(card);
            throw new Exception("Card number or password is incorrect");
        }
        if (card.Password == password && card.LoginAttempts >= 3)
            throw new Exception("the card has blocked, try another time");

        if ((card.LastLoginTime - DateTime.Now).TotalHours >24 || card.Password == password )
        {
            card.LoginAttempts = 0;
            _cardService.Update(card);
        }
        
        return new CardLoginDto()
        {
            CardNumber = card.CardNumber,
            BankName = card.BankName,
            PersonName = card.BankName
        };

    }
}