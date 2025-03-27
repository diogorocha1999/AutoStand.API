using AutoStand.BOL.Entities;
using AutoStand.DAL.Data;
using AutoStand.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AutoStand.DAL.Repositories
{
    /// <summary>
    /// Implementação do repositório para clientes
    /// </summary>
    public class CustomerRepository : ICustomerRepository
    {
        private readonly AutoStandContext _context;

        public CustomerRepository(AutoStandContext context)
        {
            _context = context;
        }

        public IEnumerable<Customer> GetAll()
        {
            return _context.Customers.Where(c => !c.IsDeleted).ToList();
        }

        public Customer GetById(int id)
        {
            return _context.Customers.FirstOrDefault(c => c.Id == id && !c.IsDeleted);
        }

        public Customer GetByNIF(string nif)
        {
            return _context.Customers.FirstOrDefault(c => c.NIF == nif && !c.IsDeleted);
        }

        public void Add(Customer customer)
        {
            _context.Customers.Add(customer);
            _context.SaveChanges();
        }

        public void Update(Customer customer)
        {
            _context.Customers.Update(customer);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var customer = _context.Customers.Find(id);
            if (customer != null)
            {
                customer.IsDeleted = true;
                customer.DeletedAt = DateTime.Now;
                _context.SaveChanges();
            }
        }
    }
}