using AutoStand.BOL.Entities;
using System.Collections.Generic;

namespace AutoStand.BAL.Interfaces
{
    /// <summary>
    /// Interface para o serviço de gestão de inventário
    /// </summary>
    public interface IInventoryService
    {
        IEnumerable<InventoryMovement> GetInventoryHistory();
        IEnumerable<Vehicle> GetAvailableVehicles();
        decimal GetTotalInventoryValue();
        void AddVehicleToInventory(Vehicle vehicle, decimal purchasePrice, string supplier);
        void RemoveVehicleFromInventory(int vehicleId, string reason);
    }
}