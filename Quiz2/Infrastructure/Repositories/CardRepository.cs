using DTOs;
using Infrastructure.Persestens;
using Microsoft.EntityFrameworkCore;
using Quiz2.Contracts.Repository_Interfaces;
using System;


namespace Infrastructure.Repositories;

public class CardRepository(AppDbContext context) : ICardRepository
{

    public GetCardDto? GetCardByNumber(string cardNumber)
    {
        return context.Cards
            .Where(c => c.CardNumber == cardNumber)
            .Select(x => new GetCardDto()
            {
                Id = x.Id,
                BankName = x.BankName,
                CardNumber = x.CardNumber,
                PersonName = x.PersonName,
            }).FirstOrDefault();
    }

    public GetCardDetailsDto? GetCardDetails(string cardNumber)
    {
        return context.Cards
            .Where(c => c.CardNumber == cardNumber)
            .Select(x => new GetCardDetailsDto()
            {
                Id = x.Id,
                Balance = x.Balance,
                CardNumber = x.CardNumber,
                IsActive = x.IsActive,
                LastTransferDate = x.LastTransferDate,
                DailyTransferAmount = x.DailyTransferAmount,
                PersonName = x.PersonName
            }).FirstOrDefault();
    }

    public GetCardForLoginDto? CardForLoginDto(string cardNumber)
    {
        return context.Cards
            .Where(c => c.CardNumber == cardNumber)
            .Select(c => new GetCardForLoginDto()
            {
                CardNumber = c.CardNumber,
                Password = c.Password,
                IsActive = c.IsActive,
                LoginAttempts = c.LoginAttempts,
                LastLoginTime = c.LastLoginTime
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

    public int GetCardLoginAttempt(string cardNumber)
    {
        return context.Cards.Where(c => c.CardNumber == cardNumber)
            .Select(c => c.LoginAttempts)
            .First();
    }

    public DateTime? GetLastLoginTime(string cardNumber)
    {
        return context.Cards
            .Where(c => c.CardNumber == cardNumber)
            .Select(c => c.LastLoginTime)
            .FirstOrDefault();
    }

    public void UpdateLoginData(CardLoginUpdateDto dto)
    {
        var query = context.Cards.Where(c => c.CardNumber == dto.CardNumber);

        if (dto.LoginAttempt.HasValue)
            query.ExecuteUpdate(setters => setters
                .SetProperty(c => c.LoginAttempts, dto.LoginAttempt.Value));

        if (dto.LastLogin.HasValue)
            query.ExecuteUpdate(setters => setters
                .SetProperty(c => c.LastLoginTime, dto.LastLogin.Value));

        if (dto.IsActive.HasValue)
            query.ExecuteUpdate(setters => setters
                .SetProperty(c => c.IsActive, dto.IsActive.Value));
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

    public void UpdateLastTransferDate2(string cardNumber, DateTime dateOnly)
    {
        context.Cards
            .Where(c => c.CardNumber == cardNumber)
            .ExecuteUpdate(setter => setter
                .SetProperty(c => c.LastTransferDate, dateOnly));
    }
    public void UpdateLastTransferDate(string cardNumber, DateTime dateOnly)
    {
        var card = context.Cards.First(c => c.CardNumber == cardNumber);
        card.LastTransferDate = dateOnly;
    }

    public void UpdateLastLoginTime(string cardNumber, DateTime datetime)
    {
        context.Cards
            .Where(c => c.CardNumber == cardNumber)
            .ExecuteUpdate(setter => setter
                .SetProperty(c => c.LastLoginTime, datetime));
    }

    public void UpdateDailyTransferAmount2(string cardNumber, float amount)
    {
        context.Cards
            .Where(c => c.CardNumber == cardNumber)
            .ExecuteUpdate(setter => setter
                .SetProperty(c => c.DailyTransferAmount, amount));
    }
    public void UpdateDailyTransferAmount(string cardNumber, float amount)
    {
        var card = context.Cards.First(c => c.CardNumber == cardNumber);
        card.DailyTransferAmount = amount;
    }

    public void UpdateBalance2(string cardNumber, float amount)
    {
        context.Cards
            .Where(c => c.CardNumber == cardNumber)
            .ExecuteUpdate(setter => setter
                .SetProperty(c => c.Balance, amount));
    }

    public void SaveChanges()
    {
        context.SaveChanges();
    }

    public void UpdateBalance(string cardNumber, float amount)
    {
        var card = context.Cards.First(c => c.CardNumber == cardNumber);
        card.Balance = amount;
    }
}