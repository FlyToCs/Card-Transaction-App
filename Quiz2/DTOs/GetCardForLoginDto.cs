namespace DTOs;

public class GetCardForLoginDto
{
    public string CardNumber { get; set; }
    public string Password { get; set; }
    public bool IsActive { get; set; }
    public int LoginAttempts { get; set; }
    public DateTime LastLoginTime { get; set; }
}