using AutoStand.BOL.Entities;
using System;
using System.Collections.Generic;

namespace AutoStand.DAL.Interfaces
{
    /// <summary>
    /// Interface para o repositório de vendas
    /// </summary>
    public interface ISaleRepository
    {
        IEnumerable<Sale> GetAll();
        Sale GetById(int id);
        IEnumerable<Sale> GetByDateRange(DateTime startDate, DateTime endDate);
        void Add(Sale sale);
        void Delete(int id);
    }
}