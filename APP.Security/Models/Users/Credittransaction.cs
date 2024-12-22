namespace APP.Security.Models.Users;

public partial class Credittransaction
{
    public int Transactionid { get; set; }

    public int UserId { get; set; }

    public int Cafeid { get; set; }

    public string Transactiontype { get; set; } = null!;

    public decimal Amount { get; set; }

    public DateTime? Transactiondate { get; set; }

    public string? Note { get; set; }

    public int? Orderid { get; set; }
}
