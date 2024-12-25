﻿
namespace App.Shared.Models
{
    public class BaseM:IAggregateRoot
    {
        public Guid Id { get; set; }
        public string EntryBy { get; internal set; }
        public DateTime? EntryDate { get; internal set; }
        public DateTime? LastUpdated { get; internal set; }
        public RecordStatus Status { get; internal set; }
        public BaseM() { }
        public BaseM(string entryBy, RecordStatus status )
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
