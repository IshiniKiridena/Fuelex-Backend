namespace Fuelex_Backend.Models.QueueModel
{
    public interface IQueueDBSettings
    {
        string QueueCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
