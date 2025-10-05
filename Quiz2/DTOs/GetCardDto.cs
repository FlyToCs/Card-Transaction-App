using System.Globalization;

namespace DTOs;

public class GetCardDto
{
    public int Id { get; set; }
    public string CardNumber { get; set; }
    public string BankName { get; set; }
    public string PersonName { get; set; }

}