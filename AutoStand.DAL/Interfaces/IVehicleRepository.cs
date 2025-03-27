// AutoStand.DAL/Interfaces/IVehicleRepository.cs
using AutoStand.BOL.Entities;
using System.Collections.Generic;

namespace AutoStand.DAL.Interfaces
{
    public interface IVehicleRepository
    {
        IEnumerable<Vehicle> GetAll(bool includeDeleted = false);
        Vehicle GetById(int id);
        Vehicle GetByLicensePlate(string licensePlate);
        void Add(Vehicle vehicle);
        void Update(Vehicle vehicle);
        void SoftDelete(int id);
        void Restore(int id);
        IEnumerable<Vehicle> GetAvailableVehicles();
        IEnumerable<Vehicle> GetDeletedVehicles();
    }
}