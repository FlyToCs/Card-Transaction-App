namespace DTOs;

public class GetTransactionDto
{
    public float Amount { get; set; }
    public string SourceCard { get; set; }
    public string DestinationCard { get; set; }
    public DateTime TransferTime { get; set; }
    public bool IsSuccess { get; set; }

}