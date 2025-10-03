namespace Quiz2.Entities;

public class Card
{
    public int Id { get; set; }
    public string CardNumber { get; set; }
    public float Balance { get; set; }
    public string Password { get; set; }
    public bool IsActive { get; set; }
    public List<Transaction> SourceTransactions { get; set; } = [];
    public List<Transaction> DestinationTransactions { get; set; } = [];

}