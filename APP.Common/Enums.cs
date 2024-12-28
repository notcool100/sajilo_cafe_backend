namespace App.Shared
{
    public enum RecordStatus
    {
        Save = 1,
        Submit = 2,
        Approve = 3,
        Reject = 4,
        Delete = 5
        
    }
    public static class RecordStatusExtension
    {
        public static string GetDescription(this RecordStatus status)
        {
            switch (status)
            {
                case RecordStatus.Save:
                    return "Save";
                case RecordStatus.Submit:
                    return "Submit";
                case RecordStatus.Approve:
                    return "Approve";
                case RecordStatus.Reject:
                    return "Reject";
                case RecordStatus.Delete:
                    return "Delete";
                default:
                    return string.Empty;
            }
        }
        public static RecordStatus DefaultStatus()  { return RecordStatus.Submit; } 
}
}
