using App.Shared.Infrastructure;
using APP.Security.Models;
using APP.Security.Models.Users;

namespace Shared.App
{
    public class BaseM:IAggregateRoot
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public User EntryBy { get; internal set; }
        public DateTime? EntryDate { get; internal set; }
        public DateTime? LastUpdated { get; internal set; }
        public Status Status { get; internal set; }
        public BaseM() { }
        public BaseM(string Name,User entryBy, Status? status)
        {
            Id = Guid.NewGuid();
            this.Name = Name;
            EntryBy =entryBy;
            EntryDate=DateTime.Now;
            LastUpdated=null;
            Status=status?? Status.Active;
        }
        public void Delete()
        {
            Status = 5;
        }
    }

   
}
