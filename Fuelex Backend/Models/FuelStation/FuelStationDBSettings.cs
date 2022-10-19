﻿namespace Fuelex_Backend.Models.FuelStation
{
    public class FuelStationDBSettings : IFuelStationDBSettings
    {
        public string FuelStationCollectionName { get; set; } = String.Empty;
        public string ConnectionString { get; set; } = String.Empty;
        public string DatabaseName { get; set; } = String.Empty;
    }
}
