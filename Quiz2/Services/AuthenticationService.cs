using System.Security.AccessControl;
using DTOs;
using Quiz2.Contracts.Service_Interfaces;

namespace Services;

public class AuthenticationService(ICardService cardService) : IAuthenticationService
{
    private readonly ICardService _cardService = cardService;
    public GetCardDto Login(string cardNumber, string password)
    {
        var card =_cardService.GetCardByNumber(cardNumber);
        if (card.Password != password)
        {
            var attempts = card.LoginAttempts += 1;
            _cardService.UpdateLoginAttempts(cardNumber,attempts);
            throw new Exception("Card number or password is incorrect");
        }
        if (card.Password == password && card.LoginAttempts >= 3)
            throw new Exception("the card has blocked, try another time");

        if ((card.LastLoginTime - DateTime.Now).TotalHours >24 || card.Password == password )
            _cardService.UpdateLoginAttempts(cardNumber, 0);
        
        
        return new GetCardDto()
        {
            CardNumber = card.CardNumber,
            BankName = card.BankName,
            PersonName = card.PersonName,
        };

    }
}