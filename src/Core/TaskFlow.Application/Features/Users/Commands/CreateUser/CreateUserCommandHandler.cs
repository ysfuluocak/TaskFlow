using MediatR;
using TaskFlow.Domain.Entities;
using TaskFlow.Application.DTOs;
using TaskFlow.Application.Wrappers.Results;
using TaskFlow.Application.Interfaces.Security;
using TaskFlow.Application.Features.Users.Rules;
using TaskFlow.Application.Interfaces.Repositories.UserRepositories;

namespace TaskFlow.Application.Features.Users.Commands.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Result<UserDto>>
    {
        private readonly IUserWriteRepository _writeRepository;
        private readonly IHashingHelper _hashingHelper;
        private readonly UserBusinessRules _userBusinessRules;

        public CreateUserCommandHandler(IUserWriteRepository writeRepository, IHashingHelper hashingHelper, UserBusinessRules userBusinessRules)
        {
            _writeRepository = writeRepository;
            _hashingHelper = hashingHelper;
            _userBusinessRules = userBusinessRules;
        }

        public async Task<Result<UserDto>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            await _userBusinessRules.EmailCanNotBeDuplicatedWhenRegistered(request.Email);
            _hashingHelper.CreatePasswordHash(request.Password, out byte[] passwordHash, out byte[] passwordSalt);

            User user = new User()
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Status = true,
                CreatedDate = DateTime.Now,
            };

            await _writeRepository.AddAsync(user, cancellationToken);
            await _writeRepository.CommitAsync(cancellationToken);

            return Result<UserDto>.Success(new UserDto()
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Status = user.Status
            });
        }
    }
}
