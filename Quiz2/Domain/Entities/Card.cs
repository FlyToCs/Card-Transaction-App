namespace Domain.Entities;

public class Card
{
    public int Id { get; set; }
    public string CardNumber { get; set; }
    public string BankName { get; set; }
    public string PersonName { get; set; }
    public float Balance { get; set; }
    public string Password { get; set; }
    public bool IsActive { get; set; }
    public float DailyTransferAmount { get; set; }
    public int LoginAttempts { get; set; }
    public DateTime LastLoginTime { get; set; }
    public DateOnly LastTransferDate { get; set; }
    public List<Transaction> SourceTransactions { get; set; } = [];
    public List<Transaction> DestinationTransactions { get; set; } = [];

}