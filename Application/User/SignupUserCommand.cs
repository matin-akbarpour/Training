using MediatR;
using Infrastructure;
using Infrastructure.Models;
using Microsoft.IdentityModel.Tokens;
using System.ComponentModel.DataAnnotations;

namespace Application.User;

public class SignupUserCommand: IRequest<string>
{
    [Required]
    public string? UserName { get; set; }
    [Required]
    public string? Password { get; set; }
    
    public class SignupUserHandler : IRequestHandler<SignupUserCommand, string>
    {
        private readonly IUnitOfWork _unitOfWork;
        public SignupUserHandler(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        public async Task<string> Handle(SignupUserCommand command, CancellationToken cancellationToken)
        {
            var user = new Users
            {
                UserName = command.UserName,
                Password = command.Password,
                IsActive = true
            };

            var userData = await _unitOfWork.User.CheckUser(user);
            if (!userData.IsNullOrEmpty()) return "There is a user with that username";
            
            await _unitOfWork.User.SignupUser(user);
            return "User signed up";
        }
    }
}
