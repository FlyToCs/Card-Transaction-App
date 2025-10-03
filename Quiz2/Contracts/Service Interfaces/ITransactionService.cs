using Quiz2.Entities;

namespace Quiz2.Contracts.Service_Interfaces;

public interface ITransactionService
{
    List<Transaction> GetTransactionsByCardNumber();
    List<Transaction> GetTransactionsByCardId();
    Transaction TransferMoney();
}