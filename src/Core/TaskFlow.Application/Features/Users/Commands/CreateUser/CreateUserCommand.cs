using MediatR;
using TaskFlow.Application.DTOs;
using TaskFlow.Application.Wrappers.Results;

namespace TaskFlow.Application.Features.Users.Commands.CreateUser
{
    public class CreateUserCommand : IRequest<Result<UserDto>>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
