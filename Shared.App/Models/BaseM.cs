namespace Shared.App
{
    public class BaseM
    {
        public Guid Id { get; set; }
        public string EntryBy { get; internal set; }
        public DateTime? EntryDate { get; internal set; }
        public DateTime? LastUpdated { get; internal set; }
        public int Status { get; internal set; }
        public BaseM() { }
        public BaseM(string entryBy, int status = 1)
        {
            Id = Guid.NewGuid();
            EntryBy=entryBy;
            EntryDate=DateTime.Now;
            LastUpdated=null;
            Status=status;
        }
        public void Delete()
        {
            Status = 5;
        }
    }
}
