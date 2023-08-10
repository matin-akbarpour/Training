using MediatR;
using FluentResults;
using Infrastructure;
using System.ComponentModel.DataAnnotations;

namespace Application.User;

public class SignupUserCommand: IRequest<Result>
{
    [Required]
    public string? UserName { get; set; }
    [Required]
    public string? Password { get; set; }
    
    public class SignupUserHandler : IRequestHandler<SignupUserCommand, Result>
    {
        private readonly IUnitOfWork _unitOfWork;
        public SignupUserHandler(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        public async Task<Result> Handle(SignupUserCommand command, CancellationToken cancellationToken)
        {
            var result = new Result();

            var userData = await _unitOfWork.User.UserById(command.UserName);
            if (userData != null)
                return result.WithSuccess("There is a user with that username");
                
            var user = new Core.Entities.User
            {
                UserName = command.UserName,
                Password = command.Password,
                IsActive = true,
                SignUpDate = DateTime.Now
            };
                
            await _unitOfWork.User.InsertAsync(user);
            return result.WithSuccess("User signed up");
        }
    }
}
