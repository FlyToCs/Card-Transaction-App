using Domain.Entities;
using DTOs;

namespace Quiz2.Contracts.Repository_Interfaces;

public interface ITransactionRepository
{
    bool Add(Transaction transaction);
    List<GetTransactionDto> GetTransactionsByCardNumber(string cardNumber);
    List<Transaction> GetTransactionsByCardId(int cardId);
    void Update(Transaction transaction);
}