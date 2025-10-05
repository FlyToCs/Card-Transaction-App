using DTOs;
using Infrastructure.Persestens;
using Microsoft.EntityFrameworkCore;
using Quiz2.Contracts.Repository_Interfaces;


namespace Infrastructure.Repositories;

public class CardRepository(AppDbContext context) : ICardRepository
{

    public GetCardDto? GetCardByNumber(string cardNumber)
    {
        return context.Cards.Select(x=>new GetCardDto()
        {
            Id = x.Id,
            BankName = x.BankName,
            CardNumber = x.CardNumber,
            PersonName = x.PersonName,
            Password = x.Password,
            LoginAttempts = x.LoginAttempts,
            LastLoginTime = x.LastLoginTime,
            Balance = x.Balance,
            DailyTransferAmount = x.DailyTransferAmount,
            LastTransferDate = x.LastTransferDate,
            IsActive = x.IsActive,


        }).FirstOrDefault();
    }

    public bool CardExist(string cardNumber, string password)
    {
        return context.Cards.Any(c => c.CardNumber == cardNumber && c.Password == password);
    }

    public bool CardIsActive(string cardNumber)
    {
        return context.Cards.Any(c => c.CardNumber == cardNumber && c.IsActive);
    }

    public float GetCardBalance(string cardNumber)
    {
        return context.Cards
            .Where(c => c.CardNumber == cardNumber)
            .Select(c => c.Balance)
            .First();
    }

    public void UpdateLoginAttempts(string cardNumber, int attempt)
    {
        context.Cards
            .Where(c => c.CardNumber == cardNumber)
            .ExecuteUpdate(setter => setter
                .SetProperty(c => c.LoginAttempts, attempt));
    }

    public void UpdateCardPassword(string cardNumber, string password)
    {
        context.Cards.Where(c => c.CardNumber == cardNumber)
            .ExecuteUpdate(setter => setter
                .SetProperty(c => c.Password, password));
    }

    public void UpdateBalance(string cardNumber, float amount)
    {
        context.Cards
            .Where(c => c.CardNumber == cardNumber)
            .ExecuteUpdate(setter => setter
                .SetProperty(c => c.Balance, amount));
    }
}