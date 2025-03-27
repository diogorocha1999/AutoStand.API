using AutoStand.BOL.Entities;
using AutoStand.DAL.Data;
using AutoStand.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AutoStand.DAL.Repositories
{
    /// <summary>
    /// Implementação do repositório para vendas
    /// </summary>
    public class SaleRepository : ISaleRepository
    {
        private readonly AutoStandContext _context;

        public SaleRepository(AutoStandContext context)
        {
            _context = context;
        }

        public IEnumerable<Sale> GetAll()
        {
            return _context.Sales
                .Include(s => s.Vehicle)
                .Include(s => s.Customer)
                .ToList();
        }

        public Sale GetById(int id)
        {
            return _context.Sales
                .Include(s => s.Vehicle)
                .Include(s => s.Customer)
                .FirstOrDefault(s => s.Id == id);
        }

        public IEnumerable<Sale> GetByDateRange(DateTime startDate, DateTime endDate)
        {
            return _context.Sales
                .Include(s => s.Vehicle)
                .Include(s => s.Customer)
                .Where(s => s.SaleDate >= startDate && s.SaleDate <= endDate)
                .ToList();
        }

        public void Add(Sale sale)
        {
            _context.Sales.Add(sale);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var sale = _context.Sales.Find(id);
            if (sale != null)
            {
                _context.Sales.Remove(sale);
                _context.SaveChanges();
            }
        }
    }
}