using Microsoft.EntityFrameworkCore;
using Quiz2.Contracts.Repository_Interfaces;
using Quiz2.Contracts.Service_Interfaces;
using Quiz2.DTOs;
using Quiz2.Entities;
using Quiz2.Infrastructure.Persestens;

namespace Quiz2.Services;

public class TransactionService(ITransactionRepository transactionRepository, ICardService cardService, AppDbContext context) : ITransactionService
{
    private readonly AppDbContext _context = context;
    private readonly ITransactionRepository _transactionRepository = transactionRepository;
    private readonly ICardService _cardService = cardService;



    public List<GetTransactionDto> GetTransactionsByCardNumber(string cardNumber)
    {
        return _transactionRepository.GetTransactionsByCardNumber(cardNumber);
    }


    // public bool TransferMoney(string sourceCardNumber, string destinationCardNumber, float amount)
    // {
    //     var sourceCard = _cardService.GetCardByNumber(sourceCardNumber);
    //     var destinationCard = _cardService.GetCardByNumber(destinationCardNumber);
    //
    //     if (!sourceCard.IsActive)
    //         throw new Exception("The source card is not active");
    //
    //     if (!destinationCard.IsActive)
    //         throw new Exception("the destination card is not active");
    //
    //     if (amount<=0)
    //         throw new Exception("The amount should be more than 0!");
    //
    //
    //
    //     if (sourceCard.DailyTransferAmount+amount<=250)
    //     {
    //         if (sourceCard.Balance >= amount)
    //         {
    //             sourceCard.Balance = sourceCard.Balance - amount;
    //             sourceCard.DailyTransferAmount += amount;
    //             destinationCard.Balance = destinationCard.Balance + amount;
    //         }
    //         else
    //             throw new Exception("the balance is not enough to transfer");
    //     }
    //     else
    //         throw new Exception("the daily limit to transfer money");
    //     
    //
    //
    //     _cardService.Update(sourceCard);
    //     _cardService.Update(destinationCard);
    //     var transaction = new Transaction()
    //     {
    //         Amount = amount,
    //         DestinationAccountId = destinationCard.Id,
    //         SourceAccountId = sourceCard.Id,
    //         IsSuccessful = true,
    //     };
    //     _transactionRepository.Add(transaction);
    //     return true;
    //     
    // }



    public bool TransferMoney(string sourceCardNumber, string destinationCardNumber, float amount) 
    {
        const float dailyLimit = 250;
    
       
        using var dbTransaction = _context.Database.BeginTransaction();
        try
        {
          
            if (amount <= 0)
                throw new Exception("The amount should be more than 0!");
    
            var sourceCard = _cardService.GetCardByNumber(sourceCardNumber);
            var destinationCard = _cardService.GetCardByNumber(destinationCardNumber);
    
            if (!sourceCard.IsActive)
                throw new Exception("The source card is not active.");
    
            var today = DateOnly.FromDateTime(DateTime.Now);
            if (sourceCard.LastTransferDate != today)
            {
                sourceCard.DailyTransferAmount = 0;
            }
    
            if (sourceCard.DailyTransferAmount + amount > dailyLimit)
                throw new Exception("Daily transfer limit exceeded.");
    
            if (sourceCard.Balance < amount)
                throw new Exception("The balance is not enough to transfer.");
    
         
    
            sourceCard.Balance -= amount;
            sourceCard.DailyTransferAmount += amount;
            sourceCard.LastTransferDate = today;
    
            destinationCard.Balance += amount; 
    
            _context.Cards.Update(sourceCard);
            _context.Cards.Update(destinationCard);
    
            var transaction = new Transaction()
            {
                Amount = amount,
                DestinationAccountId = destinationCard.Id,
                SourceAccountId = sourceCard.Id,
                IsSuccessful = true,
                TransactionDate = DateTime.UtcNow
            };
            _context.Transactions.Add(transaction);
    
          
            _context.SaveChanges();
            dbTransaction.Commit();
    
            return true;
        }
        catch (Exception ex)
        {
            dbTransaction.Rollback();
            throw;
        }
    }



}