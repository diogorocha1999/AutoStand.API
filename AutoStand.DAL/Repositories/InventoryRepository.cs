// AutoStand.DAL/Repositories/InventoryRepository.cs
using AutoStand.BOL.Entities;
using AutoStand.DAL.Data;
using AutoStand.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace AutoStand.DAL.Repositories
{
    public class InventoryRepository : IInventoryRepository
    {
        private readonly AutoStandContext _context;

        public InventoryRepository(AutoStandContext context)
        {
            _context = context;
        }

        public IEnumerable<InventoryMovement> GetAllMovements()
        {
            return _context.InventoryMovements
                .Include(im => im.Vehicle)
                .OrderByDescending(im => im.MovementDate)
                .ToList();
        }

        public void AddMovement(InventoryMovement movement)
        {
            _context.InventoryMovements.Add(movement);
            _context.SaveChanges();
        }

        public IEnumerable<Vehicle> GetCurrentInventory()
        {
            return _context.Vehicles
                .Where(v => v.IsAvailable && !v.IsDeleted)
                .ToList();
        }

        public decimal GetInventoryValue()
        {
            return _context.Vehicles
                .Where(v => v.IsAvailable && !v.IsDeleted)
                .Sum(v => v.Price);
        }
    }
}