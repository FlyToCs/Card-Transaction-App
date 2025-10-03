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

    public bool TransferMoney(string sourceCardNumber, string destinationCardNumber, float amount)
    {
        var sourceCard = _cardService.GetCardByNumber(sourceCardNumber);
        var destinationCard = _cardService.GetCardByNumber(destinationCardNumber);

        if (!sourceCard.IsActive)
            throw new Exception("The source card is not active");
        

        if (!destinationCard.IsActive)
            throw new Exception("the destination card is not active");
        
        if (sourceCard.Balance >= amount)
            sourceCard.Balance = sourceCard.Balance-amount;
        
        else
            throw new Exception("the balance is not enough to transfer");

        destinationCard.Balance = destinationCard.Balance+amount;
        _cardService.Update(sourceCard);
        _cardService.Update(destinationCard);
        var transaction = new Transaction()
        {
            Amount = amount,
            DestinationAccountId = destinationCard.Id,
            SourceAccountId = sourceCard.Id,
            IsSuccessful = true,
        };
        _transactionRepository.Add(transaction);
        return true;
        
    }
}