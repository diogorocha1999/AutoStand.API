namespace AutoStand.BOL.Dtos
{
    /// <summary>
    /// DTO para registro de usuário
    /// </summary>
    public class UserForRegisterDto
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; } = 2; // Default para Vendedor
    }

    /// <summary>
    /// DTO para login de usuário
    /// </summary>
    public class UserForLoginDto
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

    /// <summary>
    /// DTO com informações detalhadas do usuário
    /// </summary>
    public class UserForDetailedDto
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? LastLogin { get; set; }
    }
}