using TaskFlow.Domain.Entities;
using TaskFlow.Application.Exceptions.ExceptionTypes;
using TaskFlow.Application.Interfaces.Repositories.UserRepositories;

namespace TaskFlow.Application.Features.Users.Rules
{
    public class UserBusinessRules
    {
        private readonly IUserReadRepository _readRepository;

        public UserBusinessRules(IUserReadRepository readRepository)
        {
            _readRepository = readRepository;
        }

        public async Task EmailCanNotBeDuplicatedWhenRegistered(string email)
        {
            User? user = await _readRepository.GetAsync(u => u.Email == email);
            if (user != null) throw new BusinessException("Mail already exists");
        }
    }
}
