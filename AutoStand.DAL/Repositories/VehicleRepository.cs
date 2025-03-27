// AutoStand.DAL/Repositories/VehicleRepository.cs
using AutoStand.BOL.Entities;
using AutoStand.DAL.Data;
using AutoStand.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AutoStand.DAL.Repositories
{
    public class VehicleRepository : IVehicleRepository
    {
        private readonly AutoStandContext _context;

        public VehicleRepository(AutoStandContext context)
        {
            _context = context;
        }

        public IEnumerable<Vehicle> GetAll(bool includeDeleted = false)
        {
            var query = _context.Vehicles.AsQueryable();

            if (!includeDeleted)
            {
                query = query.Where(v => !v.IsDeleted);
            }

            return query.Include(v => v.InventoryMovements)
                       .ToList();
        }

        public Vehicle GetById(int id)
        {
            return _context.Vehicles
                .Include(v => v.InventoryMovements)
                .FirstOrDefault(v => v.Id == id);
        }

        public Vehicle GetByLicensePlate(string licensePlate)
        {
            return _context.Vehicles
                .Include(v => v.InventoryMovements)
                .FirstOrDefault(v => v.LicensePlate == licensePlate);
        }

        public void Add(Vehicle vehicle)
        {
            if (vehicle == null)
                throw new ArgumentNullException(nameof(vehicle));

            _context.Vehicles.Add(vehicle);
            _context.SaveChanges();
        }

        public void Update(Vehicle vehicle)
        {
            if (vehicle == null)
                throw new ArgumentNullException(nameof(vehicle));

            _context.Vehicles.Update(vehicle);
            _context.SaveChanges();
        }

        public void SoftDelete(int id)
        {
            var vehicle = _context.Vehicles.Find(id);
            if (vehicle != null)
            {
                vehicle.IsDeleted = true;
                vehicle.DeletedAt = DateTime.Now;
                _context.SaveChanges();
            }
        }

        public void Restore(int id)
        {
            var vehicle = _context.Vehicles.Find(id);
            if (vehicle != null)
            {
                vehicle.IsDeleted = false;
                vehicle.DeletedAt = null;
                _context.SaveChanges();
            }
        }

        public IEnumerable<Vehicle> GetAvailableVehicles()
        {
            return _context.Vehicles
                .Where(v => v.IsAvailable && !v.IsDeleted)
                .Include(v => v.InventoryMovements)
                .ToList();
        }

        public IEnumerable<Vehicle> GetDeletedVehicles()
        {
            return _context.Vehicles
                .Where(v => v.IsDeleted)
                .Include(v => v.InventoryMovements)
                .ToList();
        }
    }
}