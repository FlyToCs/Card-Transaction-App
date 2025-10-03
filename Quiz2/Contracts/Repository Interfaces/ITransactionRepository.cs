using Quiz2.DTOs;
using Quiz2.Entities;

namespace Quiz2.Contracts.Repository_Interfaces;

public interface ITransactionRepository
{
    bool Add(Transaction transaction);
    List<GetTransactionDto> GetTransactionsByCardNumber(string cardNumber);
    List<Transaction> GetTransactionsByCardId(int cardId);
    void Update(Transaction transaction);
}