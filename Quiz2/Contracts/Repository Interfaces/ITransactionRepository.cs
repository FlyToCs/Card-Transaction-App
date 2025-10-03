using Quiz2.Entities;

namespace Quiz2.Contracts.Repository_Interfaces;

public interface ITransactionRepository
{
    List<Transaction> GetTransactionsByCardNumber(string cardNumber);
    List<Transaction> GetTransactionsByCardId(int cardId);
    void Update(int transactionId);
}