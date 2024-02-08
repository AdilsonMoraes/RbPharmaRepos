using Newtonsoft.Json;
using RbPharma.Domain.Entities.V1;
using RbPharma.Domain.Enums.V1;
using RbPharma.Domain.Utils.V1;
using RbPharma.Domain.Models.V1;
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

        public async Task<ResponseViewModel> DeleteUser(RequestViewModel requestViewModel)
        {
            var response = new ResponseViewModel();
            try
            {
                ValidId(requestViewModel.Id);
                var user = new User() {Id = requestViewModel.Id, UserName = requestViewModel.UserName };
                var userRemove = await _userRepository.GetById(user.Id);

                if (userRemove != null)
                    await _userRepository.DeleteUser(userRemove);

                response.Data = string.Empty;
                response.Status = ResponseStatus.Success.ToString();
            }
            catch (ErroException err)
            {
                BuildBusinessError(ref response, err);
            }
            catch (Exception ex)
            {
                BuildErrorException(ref response, ex);
            }

            return response;
        }

        public async Task<ResponseViewModel> GetAllUsers()
        {
            var response = new ResponseViewModel();
            try
            {
                var users = _userRepository.GetAllUsers();
                response.Data = JsonConvert.SerializeObject(users);
                response.Status = ResponseStatus.Success.ToString();
            }
            catch (ErroException err)
            {
                BuildBusinessError(ref response, err);
            }
            catch (Exception ex)
            {
                BuildErrorException(ref response, ex);
            }

            return response;
        }

        public async Task<ResponseViewModel> GetById(long id)
        {
            var response = new ResponseViewModel();
            try
            {
                ValidId(id);
                var users = await _userRepository.GetById(id);
                response.Data = JsonConvert.SerializeObject(users);
                response.Status = ResponseStatus.Success.ToString();
            }
            catch (ErroException err)
            {
                BuildBusinessError(ref response, err);
            }
            catch (Exception ex)
            {
                BuildErrorException(ref response, ex);
            }

            return response;
        }

        public async Task<ResponseViewModel> InsertUser(RequestViewModel requestViewModel)
        {
            var response = new ResponseViewModel();
            try
            {
                ValidUserName(requestViewModel);
                await _userRepository.InsertUser(new User() { UserName = requestViewModel.UserName });
                response.Data = string.Empty;
                response.Status = ResponseStatus.Success.ToString();
            }
            catch (ErroException err)
            {
                BuildBusinessError(ref response, err);
            }
            catch (Exception ex)
            {
                BuildErrorException(ref response, ex);
            }

            return response;
        }

        public async Task<ResponseViewModel> UpdateUser(RequestViewModel requestViewModel)
        {
            var response = new ResponseViewModel();
            try
            {
                ValidParameters(requestViewModel);
                var user = new User() { Id = requestViewModel.Id, UserName = requestViewModel.UserName };
                var userUpdate = await _userRepository.GetById(user.Id);

                if (userUpdate != null)
                    await _userRepository.UpdateUser(userUpdate);

                response.Data = string.Empty;
                response.Status = ResponseStatus.Success.ToString();
            }
            catch (ErroException err)
            {
                BuildBusinessError(ref response, err);
            }
            catch (Exception ex)
            {
                BuildErrorException(ref response, ex);
            }

            return response;
        }

        private void ValidParameters(RequestViewModel userRequest)
        {
            if (userRequest.Id == 0 || string.IsNullOrWhiteSpace(userRequest.UserName))
                throw new ErroException(UserEnumException.DATA_NOT_INFO.ErrorCod.ToString(),
                    UserEnumException.DATA_NOT_INFO.Value);
        }

        private void ValidId(long id)
        {
            if (id == 0)
                throw new ErroException(UserEnumException.INVALID_ID.ErrorCod.ToString(),
                    UserEnumException.INVALID_ID.Value);
        }

        private void ValidUserName(RequestViewModel userRequest)
        {
            if (string.IsNullOrWhiteSpace(userRequest.UserName))
            {

                throw new ErroException(UserEnumException.RESQUEST_ERROR.ErrorCod.ToString(),
                    UserEnumException.RESQUEST_ERROR.Value);
            }
        }

        private static void BuildBusinessError(ref ResponseViewModel response, ErroException e)
        {
            response.Data = "null";
            response.Status = ResponseStatus.Error.ToString();
            response.Errors = new List<ErrorViewModel> { new ErrorViewModel() { ErrorCode = e.ErrorCode, Description = e.Description } };
        }

        private static void BuildErrorException(ref ResponseViewModel response, Exception e)
        {
            response.Data = "null";
            response.Status = ResponseStatus.Error.ToString();
            response.Errors = new List<ErrorViewModel> { new ErrorViewModel() { ErrorCode = "99", Description = $"{e.Message} - Please contact the technical team.." } };
        }
    }
}
