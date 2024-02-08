using RbPharma.Domain.Entities.V1;

namespace RbPharma.Services.V1.Interfaces
{
    public interface IUserService
    {
        IEnumerable<User> GetAllUsers();
        Task<User> GetById(long id);
        Task InsertUser(User user);
        Task UpdateUser(User user);
        Task DeleteUser(User user);
    }
}
