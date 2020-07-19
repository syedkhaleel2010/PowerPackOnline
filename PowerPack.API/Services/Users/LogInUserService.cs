using PowerPack.Models;
using PowerPack.API.Repositories;
using PowerPack.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Configuration;

namespace PowerPack.API.Services
{
    public class LogInUserService : ILogInUserService
    {
        private readonly ILogInUserRepository _logInUserRepository;
        private IConfiguration _config;
        public LogInUserService(ILogInUserRepository logInUserRepository, IConfiguration config)
        {
            _logInUserRepository = logInUserRepository;
            _config = config;
        }

        public async Task<LogInUser> GetLoginUserByUserName(string userName,string Password)
        {
            var loginUser = await _logInUserRepository.GetLogInUserByUserName(userName, Password);
            if(loginUser != null)
                loginUser.Token = GenerateJSONWebToken(loginUser);
            return loginUser;
        }

        public async Task<IEnumerable<LogInUser>> GetUserList(int StoreId)
        {
            return await _logInUserRepository.GetUserList(StoreId);
        }

        /// <summary>
        /// Deepak Singh, 19 August 2019, To get token for api authentication
        /// </summary>
        /// <param name="logInUser"></param>
        /// <returns></returns>
        private string GenerateJSONWebToken(LogInUser logInUser)
        {
            var key = _config["Jwt:Key"];
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
                            {
                                new Claim(JwtRegisteredClaimNames.Sub, logInUser.Id.ToString()),
                                new Claim(JwtRegisteredClaimNames.FamilyName, logInUser.LastName),
                                new Claim(JwtRegisteredClaimNames.GivenName, logInUser.FirstName),
                                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                                new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString())
                             };

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
                _config["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddMinutes(Convert.ToInt32(_config["Jwt:Minutes"])),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
