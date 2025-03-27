// AutoStand.BOL/Entities/Vehicle.cs
using System;
using System.Collections.Generic;

namespace AutoStand.BOL.Entities
{
    public class Vehicle
    {
        public int Id { get; set; }
        public string LicensePlate { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public decimal Price { get; set; }
        public int Kilometers { get; set; }
        public string FuelType { get; set; }
        public bool IsAvailable { get; set; } = true;
        public DateTime EntryDate { get; set; } = DateTime.Now;
        public bool IsDeleted { get; set; } = false;
        public DateTime? DeletedAt { get; set; }

        // Navigation property
        public ICollection<InventoryMovement> InventoryMovements { get; set; }
    }
}