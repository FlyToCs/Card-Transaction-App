using System.Security.AccessControl;
using DTOs;
using Quiz2.Contracts.Service_Interfaces;

namespace Services;

public class AuthenticationService(ICardService cardService) : IAuthenticationService
{
    public GetCardDto Login(string cardNumber, string password)
    {
        var card = cardService.GetCardForLoginDto(cardNumber);

        if (card == null)
            throw new Exception("Card number or password is invalid");
        

        if (card.Password != password)
        {
            cardService.UpdateLoginData(new CardLoginUpdateDto
            {
                CardNumber = cardNumber,
                LoginAttempt = card.LoginAttempts + 1
            });
            throw new Exception("Card number or password is incorrect");
        }

        if (!card.IsActive)
            throw new Exception("Card number in not active");


        if (card.LoginAttempts >= 3)
            throw new Exception("the card has blocked, try another time");

        if (( DateTime.Now - card.LastLoginTime).TotalHours > 24)
        {
            cardService.UpdateLoginData(new CardLoginUpdateDto()
            {
                CardNumber = cardNumber,
                LoginAttempt = 0
            });
        }



        cardService.UpdateLoginData(new CardLoginUpdateDto
        {
            CardNumber = cardNumber,
            LastLogin = DateTime.Now,
            LoginAttempt = 0
        });

        return cardService.GetCardByCardNumber(cardNumber);

    }
}