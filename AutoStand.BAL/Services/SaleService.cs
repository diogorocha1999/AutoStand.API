using AutoStand.BAL.Interfaces;
using AutoStand.BOL.Entities;
using AutoStand.DAL.Interfaces;
using AutoStand.DAL.Repositories;
using System;
using System.Collections.Generic;

namespace AutoStand.BAL.Services
{
    /// <summary>
    /// Serviço para gestão de vendas
    /// </summary>
    public class SaleService : ISaleService
    {
        private readonly ISaleRepository _saleRepository;
        private readonly IVehicleRepository _vehicleRepository;

        public SaleService(ISaleRepository saleRepository, IVehicleRepository vehicleRepository)
        {
            _saleRepository = saleRepository;
            _vehicleRepository = vehicleRepository;
        }

        public IEnumerable<Sale> GetAllSales()
        {
            return _saleRepository.GetAll();
        }

        public IEnumerable<Sale> GetSalesByDateRange(DateTime startDate, DateTime endDate)
        {
            return _saleRepository.GetByDateRange(startDate, endDate);
        }

        public Sale GetSale(int id)
        {
            return _saleRepository.GetById(id);
        }

        public void RegisterSale(Sale sale)
        {
            var vehicle = _vehicleRepository.GetById(sale.VehicleId);
            if (vehicle == null)
                throw new Exception("Veículo não encontrado");

            if (!vehicle.IsAvailable)
                throw new Exception("Veículo não está disponível para venda");

            vehicle.IsAvailable = false;
            _vehicleRepository.Update(vehicle);

            _saleRepository.Add(sale);
        }

        public void CancelSale(int saleId)
        {
            var sale = _saleRepository.GetById(saleId);
            if (sale == null)
                throw new Exception("Venda não encontrada");

            var vehicle = _vehicleRepository.GetById(sale.VehicleId);
            if (vehicle != null)
            {
                vehicle.IsAvailable = true;
                _vehicleRepository.Update(vehicle);
            }

            _saleRepository.Delete(saleId);
        }
    }
}