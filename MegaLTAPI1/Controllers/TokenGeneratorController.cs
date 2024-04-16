using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using BLLayer.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using ModelDTOs.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MegaLTAPI1.Controllers
{
    [Route("api/token")]
    public class TokenGeneratorController : Controller
    {
        private readonly IUserService _userService;
        private readonly IConfiguration _configuration;

        public TokenGeneratorController(IService Service, IConfiguration configuration)
        {
            _userService = Service.UserService;
            _configuration = configuration;
        }

        [HttpPost]
        public IActionResult GetToken([FromBody]UserDTO usr)
        {
            var user = _userService.Validate(usr.Email, usr.Password);

            if (user == null)
            {
                return BadRequest("Invalid UserId/Password");
            }

            List<Claim> claims = new()
            {
                new Claim(JwtRegisteredClaimNames.Name, user.Email),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim("Age", user.Age.ToString()),
            };

            var claimsIdentity = new ClaimsIdentity(claims);

            var key = _configuration["JwtBearer:SecretKey"];
            var byteKey = Encoding.UTF8.GetBytes(key);
            var symKey = new SymmetricSecurityKey(byteKey);

            SigningCredentials signingCredentials = new SigningCredentials(symKey, SecurityAlgorithms.HmacSha256Signature);


            var tokenHandler  = new JwtSecurityTokenHandler();

            SecurityTokenDescriptor tokenDescriptor = new()
            {
                Subject = claimsIdentity,
                Audience = _configuration["JwtBearer:Audience"],
                Issuer = _configuration["JwtBearer:Issuer"],
                SigningCredentials = signingCredentials,
                Expires=DateTime.UtcNow.AddMinutes(30),                     
            };

            SecurityToken securityToken=  tokenHandler.CreateToken(tokenDescriptor);
            var token = tokenHandler.WriteToken(securityToken);

            return Ok(token);
            
        }
    }
}

