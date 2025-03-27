using AutoStand.BOL.Entities;
using System.Collections.Generic;

namespace AutoStand.DAL.Interfaces
{
    /// <summary>
    /// Interface para o repositório de clientes
    /// </summary>
    public interface ICustomerRepository
    {
        IEnumerable<Customer> GetAll();
        Customer GetById(int id);
        Customer GetByNIF(string nif);
        void Add(Customer customer);
        void Update(Customer customer);
        void Delete(int id);
    }
}