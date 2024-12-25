using App.Shared;
using System.Collections.Generic;

namespace Cafe.Infrastructure.Application
{
    public class CafeContext:BaseContext
    {
        public virtual DbSet<CafeM> Cafe { get; set; }

        public virtual DbSet<Cafestaff> Cafestaffs { get; set; }
        public virtual DbSet<Subscription> Subscriptions { get; set; }
    }
}
