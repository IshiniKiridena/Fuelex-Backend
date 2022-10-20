namespace Fuelex_Backend.Models.FuelTypeModel
{
    public interface IFuelTypeDBSetttings
    {
        string FuelTypeCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
