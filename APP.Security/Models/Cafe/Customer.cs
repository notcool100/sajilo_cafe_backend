using APP.Security.Models.Cafe;

namespace APP.Security.Models.Users;

public partial class Customer : User
{




    public decimal? Totalcredit { get; set; }

    //public string? TranDate { get; set; }  need to add diffrent tbale for transactions only 

    //public string? Machine { get; set; } same as below need to add to diffrent table with timestamp

    //public string? IpAddress { get; set; } need to addd to sperate table wiht timestamp


    public User CreatedBy { get; set; }





    public virtual CafeM? Cafe { get; set; }

}
