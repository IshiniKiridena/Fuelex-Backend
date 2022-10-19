namespace Fuelex_Backend.Models.FuelType
{
    public interface IFuelTypeDBSetttings
    {
        string FuelTypeCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
