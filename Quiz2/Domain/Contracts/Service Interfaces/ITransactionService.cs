using DTOs;


namespace Quiz2.Contracts.Service_Interfaces;

public interface ITransactionService
{
    
    List<GetTransactionDto> GetTransactionsByCardNumber(string cardNumber);
    bool TransferMoney(string sourceCardNumber, string destinationCardNumber, float amount);
}