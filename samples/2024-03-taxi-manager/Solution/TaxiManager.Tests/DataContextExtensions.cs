﻿using TaxiManager.Data;

namespace TaxiManager.Tests;

public static class DataContextExtensions
{
    public static async Task<(Taxi Taxi, int ID)> AddDummyTaxiAsync(this TaxiDataContext DbContext)
    {
        var newTaxi = new Taxi { LicensePlate = Guid.NewGuid().ToString() };
        var newTaxiID = await DbContext.AddTaxiAsync(newTaxi);
        return (newTaxi, newTaxiID);
    }

    public static async Task<(Driver Driver, int ID)> AddDummyDriverAsync(this TaxiDataContext DbContext)
    {
        var newDriver = new Driver { Name = Guid.NewGuid().ToString() };
        var newDriverID = await DbContext.AddDriverAsync(newDriver);
        return (newDriver, newDriverID);
    }

    public static async Task<(Taxi Taxi, Driver Driver, int ID)> AddDummyRideAsync(this TaxiDataContext DbContext)
    {
        var newTaxi = await DbContext.AddDummyTaxiAsync();
        var newDriver = await DbContext.AddDummyDriverAsync();

        var newRideID = await DbContext.StartRideAsync(newTaxi.Taxi, newDriver.Driver);
        return (newTaxi.Taxi, newDriver.Driver, newRideID);
    }
}