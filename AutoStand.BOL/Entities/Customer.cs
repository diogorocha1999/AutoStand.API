using System;

namespace AutoStand.BOL.Entities
{
    /// <summary>
    /// Entidade que representa um cliente
    /// </summary>
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string NIF { get; set; } // Identificador fiscal único
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime RegistrationDate { get; set; } = DateTime.Now;
        public bool IsDeleted { get; set; } = false; // Soft delete
        public DateTime? DeletedAt { get; set; } // Adicione esta linha
    }
}