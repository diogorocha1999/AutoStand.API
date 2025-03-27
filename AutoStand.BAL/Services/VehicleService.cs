// AutoStand.BAL/Services/VehicleService.cs
using AutoStand.BAL.Interfaces;
using AutoStand.BOL.Entities;
using AutoStand.DAL.Interfaces;
using System;
using System.Collections.Generic;

namespace AutoStand.BAL.Services
{
    public class VehicleService : IVehicleService
    {
        private readonly IVehicleRepository _vehicleRepository;

        public VehicleService(IVehicleRepository vehicleRepository)
        {
            _vehicleRepository = vehicleRepository;
        }

        public IEnumerable<Vehicle> GetAllVehicles(bool includeDeleted = false)
        {
            return _vehicleRepository.GetAll(includeDeleted);
        }

        public Vehicle GetVehicleById(int id)
        {
            return _vehicleRepository.GetById(id);
        }

        // AutoStand.BAL/Services/VehicleService.cs
        public Vehicle GetVehicle(int id)
        {
            return _vehicleRepository.GetById(id);
        }

        public Vehicle GetVehicleByLicensePlate(string licensePlate)
        {
            if (string.IsNullOrWhiteSpace(licensePlate))
                throw new ArgumentException("License plate cannot be empty");

            return _vehicleRepository.GetByLicensePlate(licensePlate);
        }

        public void AddVehicle(Vehicle vehicle)
        {
            if (vehicle == null)
                throw new ArgumentNullException(nameof(vehicle));

            if (string.IsNullOrWhiteSpace(vehicle.LicensePlate))
                throw new ArgumentException("License plate is required");

            if (_vehicleRepository.GetByLicensePlate(vehicle.LicensePlate) != null)
                throw new InvalidOperationException("Vehicle with this license plate already exists");

            _vehicleRepository.Add(vehicle);
        }

        public void UpdateVehicle(Vehicle vehicle)
        {
            if (vehicle == null)
                throw new ArgumentNullException(nameof(vehicle));

            var existing = _vehicleRepository.GetById(vehicle.Id);
            if (existing == null)
                throw new KeyNotFoundException("Vehicle not found");

            _vehicleRepository.Update(vehicle);
        }

        public void SoftDeleteVehicle(int id)
        {
            _vehicleRepository.SoftDelete(id);
        }

        public void RestoreVehicle(int id)
        {
            _vehicleRepository.Restore(id);
        }

        public IEnumerable<Vehicle> GetAvailableVehicles()
        {
            return _vehicleRepository.GetAvailableVehicles();
        }

        public IEnumerable<Vehicle> GetDeletedVehicles()
        {
            return _vehicleRepository.GetDeletedVehicles();
        }
    }
}