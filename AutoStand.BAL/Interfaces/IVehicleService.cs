// AutoStand.BAL/Interfaces/IVehicleService.cs
using AutoStand.BOL.Entities;
using System.Collections.Generic;

namespace AutoStand.BAL.Interfaces
{
    public interface IVehicleService
    {
        IEnumerable<Vehicle> GetAllVehicles(bool includeDeleted = false);
        Vehicle GetVehicle(int id);
        Vehicle GetVehicleById(int id);
        Vehicle GetVehicleByLicensePlate(string licensePlate);
        void AddVehicle(Vehicle vehicle);
        void UpdateVehicle(Vehicle vehicle);
        void SoftDeleteVehicle(int id);
        void RestoreVehicle(int id);
        IEnumerable<Vehicle> GetAvailableVehicles();
        IEnumerable<Vehicle> GetDeletedVehicles();
    }
}