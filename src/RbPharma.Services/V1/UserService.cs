using RbPharma.Domain.Entities.V1;
using RbPharma.Infrastructure.Users.V1.Repositories.Interfaces;
using RbPharma.Services.V1.Interfaces;

namespace RbPharma.Services.V1
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task DeleteUser(User user)
        {
            var userRemove = await _userRepository.GetById(user.Id);

            if (userRemove != null)
                await _userRepository.DeleteUser(userRemove);
        }

        public IEnumerable<User> GetAllUsers()
            => _userRepository.GetAllUsers();

        public async Task<User> GetById(long id)
            => await _userRepository.GetById(id);

        public async Task InsertUser(User user)
            => await _userRepository.InsertUser(user);

        public async Task UpdateUser(User user)
        {
            var userUpdate = await _userRepository.GetById(user.Id);

            if (userUpdate != null)
                await _userRepository.UpdateUser(userUpdate);
        }


    }
}
