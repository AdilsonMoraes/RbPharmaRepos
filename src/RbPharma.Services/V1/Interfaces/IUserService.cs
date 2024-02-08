using RbPharma.Domain.Entities.V1;
using RbPharma.Domain.Models.V1;

namespace RbPharma.Services.V1.Interfaces
{
    public interface IUserService
    {
        Task<ResponseViewModel> GetAllUsers();
        Task<ResponseViewModel> GetById(long id);
        Task<ResponseViewModel> InsertUser(RequestViewModel requestViewModel);
        Task<ResponseViewModel> UpdateUser(RequestViewModel requestViewModel);
        Task<ResponseViewModel> DeleteUser(RequestViewModel requestViewModel);
    }
}
