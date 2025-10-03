using Quiz2.Contracts.Repository_Interfaces;
using Quiz2.Entities;

namespace Quiz2.Services;

public class TransactionService(ITransactionRepository transactionRepository) : ITransactionRepository
{
    private readonly ITransactionRepository _transactionRepository = transactionRepository;

    public List<Transaction> GetTransactionsByCardNumber(string cardNumber)
    {
        throw new NotImplementedException();
    }

    public List<Transaction> GetTransactionsByCardId(int cardId)
    {
        throw new NotImplementedException();
    }
}