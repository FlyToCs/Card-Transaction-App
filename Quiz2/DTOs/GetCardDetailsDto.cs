using System.Globalization;

namespace DTOs;

public class GetCardDetailsDto
{
    public int Id { get; set; }
    public string CardNumber { get; set; }
    public string PersonName { get; set; }
    public float Balance { get; set; }
    public bool IsActive { get; set; }
    public DateTime? LastTransferDate { get; set; }
    public float DailyTransferAmount { get; set; }

}