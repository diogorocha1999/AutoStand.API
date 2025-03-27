using AutoStand.BOL.Dtos;
using AutoStand.BOL.Entities;
using System.Threading.Tasks;

namespace AutoStand.BAL.Interfaces
{
    /// <summary>
    /// Interface para o serviço de autenticação
    /// </summary>
    public interface IAuthService
    {
        Task<string> Login(UserForLoginDto userForLoginDto);
        Task<User> Register(UserForRegisterDto userForRegisterDto);
    }
}