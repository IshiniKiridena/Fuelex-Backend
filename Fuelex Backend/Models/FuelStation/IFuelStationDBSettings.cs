namespace Fuelex_Backend.Models.FuelStation
{
    public interface IFuelStationDBSettings
    {
        string FuelStationCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
