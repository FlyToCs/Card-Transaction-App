using Quiz2.Contracts.Repository_Interfaces;
using Quiz2.Contracts.Service_Interfaces;
using Quiz2.Entities;

namespace Quiz2.Services;

public class TransactionService(ITransactionRepository transactionRepository, ICardService cardService) : ITransactionService
{
    private readonly ITransactionRepository _transactionRepository = transactionRepository;
    private readonly ICardService _cardService = cardService;

    public List<Transaction> GetTransactionsByCardNumber(string cardNumber)
    {
        return _transactionRepository.GetTransactionsByCardNumber(cardNumber);
    }

    public List<Transaction> GetTransactionsByCardId(int cardId)
    {
        return _transactionRepository.GetTransactionsByCardId(cardId);
    }

    public Transaction TransferMoney(string sourceCardNumber, string destinationCardNumber, float amount)
    {
        var sourceCard = _cardService.GetCardByNumber(sourceCardNumber);
        var destinationCard = _cardService.GetCardByNumber(destinationCardNumber);
        if (sourceCard.Balance >= amount)
        {
            sourceCard.Balance = -amount;
        }

        throw new Exception();

    }
}