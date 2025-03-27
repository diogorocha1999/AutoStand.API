using System;

namespace AutoStand.BOL.Entities
{
    /// <summary>
    /// Entidade que representa uma venda no sistema
    /// </summary>
    public class Sale
    {
        public int Id { get; set; }
        public int VehicleId { get; set; }
        public Vehicle Vehicle { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public DateTime SaleDate { get; set; } = DateTime.Now;
        public decimal SalePrice { get; set; }
        public string PaymentMethod { get; set; } // Dinheiro, Cartão, Financiamento
        public string Salesperson { get; set; } // Nome do vendedor
    }
}