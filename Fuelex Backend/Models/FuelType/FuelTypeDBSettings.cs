namespace Fuelex_Backend.Models.FuelType
{
    public class FuelTypeDBSettings : IFuelTypeDBSetttings
    {
        public string FuelTypeCollectionName { get; set; } = String.Empty;
        public string ConnectionString { get; set; } = String.Empty;
        public string DatabaseName { get; set; } = String.Empty;
    }
}
