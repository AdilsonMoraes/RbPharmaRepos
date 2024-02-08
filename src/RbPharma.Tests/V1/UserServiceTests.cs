using Microsoft.Extensions.Configuration;
using Moq;
using RbPharma.Domain.Entities.V1;
using RbPharma.Domain.Enums.V1;
using RbPharma.Domain.Models.V1;
using RbPharma.Infrastructure.Users.V1.Repositories.Interfaces;
using RbPharma.Services.V1;
using RbPharma.Services.V1.Interfaces;

namespace RbPharma.Tests.V1
{
    public class UserServiceTests
    {
        protected Mock<IUserRepository> _userRepository;
        protected Mock<IUserService> _userService;
        private static UserService _application;

        private IConfiguration CreateConfiguration()
        {
            var myConfiguration = new Dictionary<string, string>
            {
                {"IsEncrypted", "false"},
                {"AzureWebJobsStorage", "UseDevelopmentStorage=true"},
                {"FUNCTIONS_WORKER_RUNTIME", "dotnet"},
                {"ConnectionSql", "Server=.;Database=RbPharma;Trusted_Connection=True;TrustServerCertificate=True"}
            };



            return new ConfigurationBuilder()
                .AddInMemoryCollection(myConfiguration)
                .Build();
        }

        private UserService GetApplication()
        {
            _userService = new Mock<IUserService>();
            var mockUserRepository = GetMock();

            return new UserService(mockUserRepository.Object);
        }


        public async Task<User> GetUserMock()
        {
            return new User()
            {
                Id = 1,
                UserName = "UserTest01"
            };
        }

        public async Task<IEnumerable<User>> GetUsersMock()
        {
            var users = new List<User>()
            {
                new User()
                    {
                        Id = 1,
                        UserName = "UserTest01"
                    },
                new User()
                    {
                        Id = 2,
                        UserName = "UserTest02"
                    }
            }.AsQueryable();

            return users;
        }

        private async Task<ResponseViewModel> GetMockResponseViewModel()
        {
            return new ResponseViewModel()
            {
                Data = "",
                Status = ResponseStatus.Success.ToString()
            };
        }

        private async Task<RequestViewModel> GetMockRequestViewModel()
        {
            return new RequestViewModel()
            {
                Id = 1,
                UserName = "RequestUser01"
            };
        }

        private Mock<IUserRepository> GetMock()
        {
            var mock = new Mock<IUserRepository>();
            var users = GetUsersMock().Result;

            mock.Setup(u => u.GetAllUsers()).Returns(() => users);

            mock.Setup(x => x.GetById(1)).Returns(GetUserMock());

            mock.Setup(x => x.UpdateUser(new User())).Returns(GetMockResponseViewModel());

            mock.Setup(x => x.DeleteUser(new User())).Returns(GetMockResponseViewModel());

            mock.Setup(x => x.InsertUser(new User())).Returns(GetMockResponseViewModel());

            return mock;
        }

        [Fact]
        public async void GetAllUserTest()
        {
            // Arrange
            _application = GetApplication();

            // Act
            var response = await _application.GetAllUsers();

            // Assert
            Assert.NotNull(response);
            Assert.True(response.Status.Equals(ResponseStatus.Success.ToString()));
        }

        [Fact]
        public async void GetUserByIdTest()
        {
            // Arrange
            _application = GetApplication();

            // Act
            var response = await _application.GetById(1);

            // Assert
            Assert.NotNull(response);
            Assert.True(response.Status.Equals(ResponseStatus.Success.ToString()));
        }

        [Fact]
        public async void UpdateUserTest()
        {
            // Arrange
            _application = GetApplication();

            // Act
            var response = await _application.UpdateUser(await GetMockRequestViewModel());

            // Assert
            Assert.NotNull(response);
            Assert.True(response.Status.Equals(ResponseStatus.Success.ToString()));
        }


        [Fact]
        public async void DeleteUserTest()
        {
            // Arrange
            _application = GetApplication();

            // Act
            var response = await _application.DeleteUser(await GetMockRequestViewModel());

            // Assert
            Assert.NotNull(response);
            Assert.True(response.Status.Equals(ResponseStatus.Success.ToString()));
        }

        [Fact]
        public async void InsertUserTest()
        {
            // Arrange
            _application = GetApplication();

            // Act
            var response = await _application.InsertUser(await GetMockRequestViewModel());

            // Assert
            Assert.NotNull(response);
            Assert.True(response.Status.Equals(ResponseStatus.Success.ToString()));
        }

    }
}