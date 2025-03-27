// AutoStand.DAL/Interfaces/IInventoryRepository.cs
using AutoStand.BOL.Entities;
using System.Collections.Generic;

namespace AutoStand.DAL.Interfaces
{
    public interface IInventoryRepository
    {
        IEnumerable<InventoryMovement> GetAllMovements();
        void AddMovement(InventoryMovement movement);
        IEnumerable<Vehicle> GetCurrentInventory();
        decimal GetInventoryValue();
    }
}