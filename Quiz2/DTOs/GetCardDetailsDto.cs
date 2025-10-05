using System.Globalization;

namespace DTOs;

public class GetCardDetailsDto
{
    public string CardNumber { get; set; }
    public float Balance { get; set; }
    public bool IsActive { get; set; }
    public DateOnly LastTransferDate { get; set; }
    public float DailyTransferAmount { get; set; }

}