namespace APP.Security.Models.Cafe;

public partial class Subscription
{
    public int Subscriptionid { get; set; }

    public string Subscriptionname { get; set; } = null!;

    public decimal Price { get; set; }

    public int Durationmonths { get; set; }

    public bool? Isactive { get; set; }

    public DateTime? Createdat { get; set; }
    public virtual ICollection<CafeM> Caves { get; set; } = new List<CafeM>();
}
