using AutoStand.BOL.Entities;
using System;
using System.Collections.Generic;

namespace AutoStand.BAL.Interfaces
{
    /// <summary>
    /// Interface para o serviço de gestão de vendas
    /// </summary>
    public interface ISaleService
    {
        IEnumerable<Sale> GetAllSales();
        IEnumerable<Sale> GetSalesByDateRange(DateTime startDate, DateTime endDate);
        Sale GetSale(int id);
        void RegisterSale(Sale sale);
        void CancelSale(int saleId);
    }
}