using MediatR;
using System.Text;
using FluentResults;
using Infrastructure;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Configuration;
using System.ComponentModel.DataAnnotations;

namespace Application.User;

public class LoginUserCommand : IRequest<Result<string>>
{
    [Required]
    public string? UserName { get; set; }
    [Required]
    public string? Password { get; set; }
    
    public class LoginUserHandler : IRequestHandler<LoginUserCommand, Result<string>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;

        public LoginUserHandler(IUnitOfWork unitOfWork, IConfiguration config)
        {
            _configuration = config;
            _unitOfWork = unitOfWork;
        }
        
        public async Task<Result<string>> Handle(LoginUserCommand command, CancellationToken cancellationToken)
        {
            var result = new Result<string>();
            
            var user = new Core.Entities.User
            {
                UserName = command.UserName,
                Password = command.Password
            };
                
            var userData = await _unitOfWork.User.LoginUser(user);
            if (userData.IsNullOrEmpty())
                return result.WithSuccess("Invalid username or password");
                
            var claims = new[] {
                new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]!),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                new Claim("UserName", user.UserName!)
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!));
            var login = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                _configuration["Jwt:Issuer"],
                _configuration["Jwt:Audience"],
                claims,
                expires: DateTime.UtcNow.AddMinutes(10),
                signingCredentials: login);

            result.WithSuccess("User Logged in");
            return result.WithValue(new JwtSecurityTokenHandler().WriteToken(token));
        }
    }
}
