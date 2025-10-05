namespace Domain.Entities;

public class Transaction
{
    public int Id { get; set; }
    public float Amount { get; set; }
    public DateTime TransactionDate { get; set; }
    public bool IsSuccessful { get; set; }


    public Card SourceAccount { get; set; }
    public int SourceAccountId { get; set; }
    public Card DestinationAccount { get; set; }
    public int DestinationAccountId { get; set; }

}