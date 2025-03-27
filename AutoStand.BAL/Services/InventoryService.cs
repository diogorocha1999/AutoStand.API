// AutoStand.BAL/Services/InventoryService.cs
using AutoStand.BAL.Interfaces;
using AutoStand.BOL.Entities;
using AutoStand.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AutoStand.BAL.Services
{
    public class InventoryService : IInventoryService
    {
        private readonly IInventoryRepository _inventoryRepository;
        private readonly IVehicleRepository _vehicleRepository;

        public InventoryService(IInventoryRepository inventoryRepository,
                              IVehicleRepository vehicleRepository)
        {
            _inventoryRepository = inventoryRepository;
            _vehicleRepository = vehicleRepository;
        }

        public IEnumerable<InventoryMovement> GetInventoryHistory()
        {
            return _inventoryRepository.GetAllMovements();
        }

        public IEnumerable<Vehicle> GetAvailableVehicles()
        {
            return _inventoryRepository.GetCurrentInventory();
        }

        public decimal GetTotalInventoryValue()
        {
            return _inventoryRepository.GetInventoryValue();
        }

        public void AddVehicleToInventory(Vehicle vehicle, decimal purchasePrice, string supplier)
        {
            if (vehicle == null)
                throw new ArgumentNullException(nameof(vehicle));

            if (purchasePrice <= 0)
                throw new ArgumentException("Purchase price must be positive");

            // Add the vehicle to the inventory
            _vehicleRepository.Add(vehicle);

            // Record the inventory movement
            var movement = new InventoryMovement
            {
                VehicleId = vehicle.Id,
                MovementType = "Entrada",
                Reason = "Compra",
                PurchasePrice = purchasePrice,
                Supplier = supplier,
                MovementDate = DateTime.Now
            };

            _inventoryRepository.AddMovement(movement);
        }

        public void RemoveVehicleFromInventory(int vehicleId, string reason)
        {
            var vehicle = _vehicleRepository.GetById(vehicleId);
            if (vehicle == null)
                throw new KeyNotFoundException("Vehicle not found");

            // Record the inventory movement
            var movement = new InventoryMovement
            {
                VehicleId = vehicleId,
                MovementType = "Saída",
                Reason = reason,
                MovementDate = DateTime.Now
            };

            _inventoryRepository.AddMovement(movement);

            // Mark vehicle as unavailable
            vehicle.IsAvailable = false;
            _vehicleRepository.Update(vehicle);
        }
    }
}