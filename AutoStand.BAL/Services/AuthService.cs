using AutoStand.BAL.Interfaces;
using AutoStand.BOL.Dtos;
using AutoStand.BOL.Entities;
using AutoStand.DAL.Interfaces;
using AutoStand.DAL.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace AutoStand.BAL.Services
{
    /// <summary>
    /// Serviço para autenticação de usuários
    /// </summary>
    public class AuthService : IAuthService
    {
        private readonly IAuthRepository _authRepo;
        private readonly IConfiguration _config;

        public AuthService(IAuthRepository authRepo, IConfiguration config)
        {
            _authRepo = authRepo;
            _config = config;
        }

        public async Task<string> Login(UserForLoginDto userForLoginDto)
        {
            var user = await _authRepo.Login(userForLoginDto.Username, userForLoginDto.Password);

            if (user == null)
                return null;

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Role, user.Role.Name)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8
                .GetBytes(_config.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }

        public async Task<User> Register(UserForRegisterDto userForRegisterDto)
        {
            if (await _authRepo.UserExists(userForRegisterDto.Username))
                throw new Exception("Username já existe");

            var userToCreate = new User
            {
                Username = userForRegisterDto.Username,
                Email = userForRegisterDto.Email,
                RoleId = userForRegisterDto.RoleId
            };

            var createdUser = await _authRepo.Register(userToCreate, userForRegisterDto.Password);

            return createdUser;
        }
    }
}