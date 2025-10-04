using Quiz2.Contracts.Repository_Interfaces;
using Quiz2.DTOs;
using Quiz2.Entities;
using Quiz2.Infrastructure.Persestens;

namespace Quiz2.Infrastructure.Repositories;

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

    public bool UpdateLoginAttempts(string cardNumber, int attempt)
    {
        var card = context.Cards.FirstOrDefault(x => x.CardNumber == cardNumber);
        if (card != null)
        {
            card.LoginAttempts = attempt;
            context.SaveChanges();
            return true;
        }

        return false;
    }

    public bool UpdateCardPassword(string cardNumber, string password)
    {
        var card = context.Cards.FirstOrDefault(x => x.CardNumber == cardNumber);
        if (card != null)
        {
            card.Password = password;
            context.SaveChanges();
            return true;
        }

        return false;
    }

    public void Update(GetCardDto getCardDto)
    {
        var card = context.Cards.FirstOrDefault(x => x.CardNumber == getCardDto.CardNumber);
        if (card != null)
        {
            context.Cards.Update(card);
            context.SaveChanges();
        }
    }
}