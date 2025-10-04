using Quiz2.DTOs;

namespace Quiz2.Contracts.Service_Interfaces;

public interface IAuthenticationService
{
    CardLoginDto Login(string userName, string password);

}