using RbPharma.Infrastructure.V1.Interfaces;
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
    }
}
