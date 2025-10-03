using Quiz2.Contracts.Repository_Interfaces;
using Quiz2.Entities;
using Quiz2.Infrastructure.Persestens;

namespace Quiz2.Infrastructure.Repositories;

public class CardRepository(AppDbContext context) : ICardRepository
{
    public Card? GetCard(int id)
    {
        return context.Cards.FirstOrDefault(x => x.Id == id);
    }

    public Card? GetCardByNumber(string cardNumber)
    {
        return context.Cards.FirstOrDefault(x => x.CardNumber == cardNumber);
    }

    public void Update(string cardNumber)
    {
        var card = context.Cards.FirstOrDefault(x => x.CardNumber == cardNumber);
        if (card != null)
        {
            context.Cards.Update(card);
            context.SaveChanges();
        }
    }
}