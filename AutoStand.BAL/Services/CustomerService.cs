using AutoStand.BAL.Interfaces;
using AutoStand.BOL.Entities;
using AutoStand.DAL.Interfaces;
using AutoStand.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AutoStand.BAL.Services
{
    /// <summary>
    /// Serviço para gestão de clientes
    /// </summary>
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public IEnumerable<Customer> GetAllCustomers()
        {
            return _customerRepository.GetAll();
        }

        public Customer GetCustomer(int id)
        {
            return _customerRepository.GetById(id);
        }

        public Customer GetCustomerByNIF(string nif)
        {
            return _customerRepository.GetByNIF(nif);
        }

        public void AddCustomer(Customer customer)
        {
            if (string.IsNullOrEmpty(customer.NIF))
                throw new ArgumentException("NIF é obrigatório");

            if (_customerRepository.GetByNIF(customer.NIF) != null)
                throw new ArgumentException("Já existe um cliente com este NIF");

            _customerRepository.Add(customer);
        }

        public void UpdateCustomer(Customer customer)
        {
            var existing = _customerRepository.GetByNIF(customer.NIF);
            if (existing != null && existing.Id != customer.Id)
                throw new ArgumentException("NIF já está em uso por outro cliente");

            _customerRepository.Update(customer);
        }

        public void DeleteCustomer(int id)
        {
            _customerRepository.Delete(id);
        }
    }
}