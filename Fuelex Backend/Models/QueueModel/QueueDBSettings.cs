namespace Fuelex_Backend.Models.QueueModel
{
    public class QueueDBSettings : IQueueDBSettings
    {
        public string QueueCollectionName { get; set; } = String.Empty;
        public string ConnectionString { get; set; } = String.Empty;
        public string DatabaseName { get; set; } = String.Empty;
    }
}
