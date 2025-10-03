using Quiz2.Contracts.Repository_Interfaces;
using Quiz2.Entities;
using Quiz2.Infrastructure.Persestens;

namespace Quiz2.Infrastructure.Repositories;

public class TransactionRepository(AppDbContext context) : ITransactionRepository
{
    public bool Add(Transaction transaction)
    {
        context.Transactions.Add(transaction);
        context.SaveChanges();
        return true;
    }

    public List<Transaction> GetTransactionsByCardNumber(string cardNumber)
    {
        return context.Transactions.Where(x => x.SourceAccount.CardNumber == cardNumber).ToList();
    }

    public List<Transaction> GetTransactionsByCardId(int cardId)
    {
        return context.Transactions.Where(x => x.SourceAccount.Id == cardId).ToList();
    }

    public void Update(Transaction transaction)
    {
        var model = context.Transactions.FirstOrDefault(x => x.Id == transaction.Id);
        if (model != null)
        {
            context.Transactions.Update(transaction);
            context.SaveChanges();
        }
    }
}