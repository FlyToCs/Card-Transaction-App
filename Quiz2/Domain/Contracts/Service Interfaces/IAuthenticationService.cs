using DTOs;

namespace Quiz2.Contracts.Service_Interfaces;

public interface IAuthenticationService
{
    GetCardDto Login(string cardNumber, string password);

}