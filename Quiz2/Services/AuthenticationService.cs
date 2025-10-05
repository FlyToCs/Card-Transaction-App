using System.Security.AccessControl;
using DTOs;
using Quiz2.Contracts.Service_Interfaces;

namespace Services;

public class AuthenticationService(ICardService cardService) : IAuthenticationService
{
    private readonly ICardService _cardService = cardService;
    public GetCardDto Login(string cardNumber, string password)
    {
        if (!_cardService.CardExist(cardNumber, password))
            throw new Exception("Card number or password is incorrect");

        if (!_cardService.CardIsActive(cardNumber))
            throw new Exception("Card number in not active");

        var lastLogin = _cardService.GetLastLoginTime(cardNumber);
        if ((lastLogin - DateTime.Now).TotalHours > 24)
            _cardService.UpdateLoginAttempts(cardNumber, 0);

        var loginAttempt = _cardService.GetCardLoginAttempts(cardNumber);
        if (loginAttempt >= 3)
            throw new Exception("the card has blocked, try another time");


        return _cardService.GetCardByCardNumber(cardNumber);

    }
}