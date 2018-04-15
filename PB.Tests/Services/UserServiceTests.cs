using AutoMapper;
using Moq;
using PB.Core.Repositories;
using PB.Core.Models;
using PB.Infrastucture.Services;
using Xunit;
using System.Threading.Tasks;

namespace PB.Tests.Services
{
    public class UserServiceTests
    {
        [Fact]
        public async Task register_async_should_invoke_add_async_on_repository()
        {
            var userRepositoryMock = new Mock<IUserRepository>();
            var mapperMock = new Mock<IMapper>();

            var userService = new UserService(userRepositoryMock.Object, mapperMock.Object);
            await userService.RegisterAsync("wojtek@test.pl", "test", "wojtek");

            userRepositoryMock.Verify(x => x.AddAsync(It.IsAny<User>()), Times.Once);
        }

        [Fact]
        public async Task when_calling_get_async_and_user_exists_it_should_invoke_user_repository_get_async()
        {
            var userRepositoryMock = new Mock<IUserRepository>();           
            var mapperMock = new Mock<IMapper>();

            var user = new User("wojtek", "wojtek@test.pl", "test", "salt");

            userRepositoryMock.Setup(x => x.GetAsync(It.IsAny<string>()))
                              .ReturnsAsync(user);

            var userService = new UserService(userRepositoryMock.Object, mapperMock.Object);
            await userService.LoginAsync("wojtek@test.pl");
            
            userRepositoryMock.Verify(x => x.GetAsync(It.IsAny<string>()), Times.Once());
        }
    }
}