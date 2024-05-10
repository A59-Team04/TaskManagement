namespace TaskManagement.Models.Contracts
{
    public interface IActivityHistoryItem
    {
        string Description { get; }
        DateTime Time { get; }

        string ViewInfo();
    }
}