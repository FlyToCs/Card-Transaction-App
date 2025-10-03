using Quiz2.Entities;

namespace Quiz2.Contracts.Repository_Interfaces;

public interface ITransactionRepository
{
    bool Add(Transaction transaction);
    List<Transaction> GetTransactionsByCardNumber(string cardNumber);
    List<Transaction> GetTransactionsByCardId(int cardId);
    void Update(Transaction transaction);
}