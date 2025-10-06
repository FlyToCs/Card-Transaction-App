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
            throw new Exception("The card number or password you entered is incorrect.");

        if (card.LoginAttempts >= 3)
            throw new Exception("Your card has been blocked due to multiple failed login attempts. Try again later.");

        if (!card.IsActive)
            throw new Exception("Your card is currently inactive. Please contact support for assistance.");

        var updateDto = new CardLoginUpdateDto
        {
            CardNumber = cardNumber,
            LastLogin = card.LastLoginTime,
            LoginAttempt = card.LoginAttempts
        };

        if (card.Password != password)
        {
            updateDto.LoginAttempt++;

            cardService.UpdateLoginData(updateDto);

            if (updateDto.LoginAttempt >= 3)
                throw new Exception("Your card has been blocked after multiple failed attempts. Please try again later.");
            else
                throw new Exception("Incorrect card number or password. Please try again.");
        }

        if (card.LastLoginTime.HasValue &&
            (DateTime.Now - card.LastLoginTime.Value).TotalHours > 24)
        {
            updateDto.LoginAttempt = 0;
        }

        updateDto.LastLogin = DateTime.Now;
        updateDto.LoginAttempt = 0;

        cardService.UpdateLoginData(updateDto);

        return cardService.GetCardByCardNumber(cardNumber);
    }
}
