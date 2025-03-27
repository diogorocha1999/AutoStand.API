using AutoStand.BOL.Entities;
using System.Collections.Generic;

namespace AutoStand.BAL.Interfaces
{
    /// <summary>
    /// Interface para o serviço de gestão de clientes
    /// </summary>
    public interface ICustomerService
    {
        IEnumerable<Customer> GetAllCustomers();
        Customer GetCustomer(int id);
        Customer GetCustomerByNIF(string nif);
        void AddCustomer(Customer customer);
        void UpdateCustomer(Customer customer);
        void DeleteCustomer(int id);
    }
}