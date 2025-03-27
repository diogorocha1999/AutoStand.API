// AutoStand.BOL/Entities/InventoryMovement.cs
using System;

namespace AutoStand.BOL.Entities
{
    public class InventoryMovement
    {
        public int Id { get; set; }
        public int VehicleId { get; set; }
        public Vehicle Vehicle { get; set; }
        public DateTime MovementDate { get; set; } = DateTime.Now;
        public string MovementType { get; set; } // "Entrada" ou "Saída"
        public string Reason { get; set; }
        public decimal? PurchasePrice { get; set; }
        public string Supplier { get; set; }
    }
}