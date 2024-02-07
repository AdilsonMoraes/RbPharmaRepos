using RbPharma.Domain.V1.Entities;

namespace RbPharma.Infrastructure.Users.V1.Repositories.Interfaces
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAllUsers();
        Task<User> GetById(long id);
        Task InsertUser(User user);
        Task UpdateUser(User user);
        Task DeleteUser(User user);
    }
}
