using Quiz2.Entities;

namespace Quiz2.Contracts.Service_Interfaces;

public interface ITransactionService
{
    List<Transaction> GetTransactionsByCardNumber(string cardNumber);
    List<Transaction> GetTransactionsByCardId(int cardId);
    Transaction TransferMoney(string sourceCardNumber, string destinationCardNumber, float amount);
}