using System.Globalization;

namespace DTOs;

public class GetCardDto
{
    public int Id { get; set; }
    public string CardNumber { get; set; }
    public string Password { get; set; }
    public string BankName { get; set; }
    public string PersonName { get; set; }
    public int LoginAttempts { get; set; }
    public DateTime LastLoginTime { get; set; }
    public float Balance { get; set; }
    public bool IsActive { get; set; }
    public DateOnly LastTransferDate { get; set; }
    public float DailyTransferAmount { get; set; }


}