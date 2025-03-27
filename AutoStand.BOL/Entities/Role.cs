namespace AutoStand.BOL.Entities
{
    /// <summary>
    /// Entidade que representa um perfil de usuário
    /// </summary>
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; } // Admin, Vendedor, Gestor
        public string Description { get; set; }
    }
}