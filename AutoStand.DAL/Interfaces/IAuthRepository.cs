using AutoStand.BOL.Dtos;
using AutoStand.BOL.Entities;
using System.Threading.Tasks;

namespace AutoStand.DAL.Interfaces
{
    /// <summary>
    /// Interface para o repositório de autenticação
    /// </summary>
    public interface IAuthRepository
    {
        Task<User> Register(User user, string password);
        Task<User> Login(string username, string password);
        Task<bool> UserExists(string username);
    }
}