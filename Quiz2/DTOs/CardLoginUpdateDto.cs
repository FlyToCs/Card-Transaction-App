namespace DTOs;

public class CardLoginUpdateDto
{
    public string CardNumber { get; set; }
    public DateTime? LastLogin { get; set; }
    public int? LoginAttempt { get; set; }
    public bool? IsActive { get; set; }
}