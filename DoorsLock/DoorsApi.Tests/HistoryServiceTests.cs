using DoorsApi.Abstractions.Repositories;
using DoorsApi.Abstractions.Services;
using DoorsApi.Dtos.History;
using DoorsApi.Models;
using DoorsApi.Services;
using FluentAssertions;
using Moq;
using Xunit;

namespace DoorsApi.Tests
{
    public class HistoryServiceTests
    {
        private readonly HistoryService _historyService;
        private readonly Mock<IHistoryRepository> _historyRepositoryMock;
        private readonly Mock<IBuildingsService> _buildingsServiceMock;
        private readonly Mock<IUsersService> _usersServiceMock;

        public HistoryServiceTests()
        {
            _historyRepositoryMock = new Mock<IHistoryRepository>();
            _buildingsServiceMock = new Mock<IBuildingsService>();
            _usersServiceMock = new Mock<IUsersService>();

            _historyService = new HistoryService(
                _historyRepositoryMock.Object,
                _buildingsServiceMock.Object,
                _usersServiceMock.Object);
        }

        [Fact]
        public async Task GetAsync_WithAuthorizedUser_ShouldReturnHistoryObject()
        {
            var building = new Building("Building1");
            var role = new Role("admin", AccessLevel.admin, building.Id);

            var user = new User("John", "Doe", "jdoe@mail.com", "8957429083");
            var userRole = new UserRole(user.Id, role.Id);

            user.UserRoles = new[] { userRole };
            building.Roles = new[] { role };

            var expectedHistory = new History(building.Id, Guid.NewGuid(), user.Id, Status.Open);

            _buildingsServiceMock.Setup(x => x.GetAsync(
                It.IsAny<Guid>(),
                CancellationToken.None))
                .ReturnsAsync(building)
                .Verifiable();

            _usersServiceMock.Setup(x => x.GetAsync(
                It.IsAny<Guid>(),
                CancellationToken.None))
                .ReturnsAsync(user)
                .Verifiable();

            _historyRepositoryMock.Setup(x => x.GetAllAsync(
                It.IsAny<Guid>(),
                It.IsAny<Guid?>(),
                It.IsAny<Guid?>(),
                It.IsAny<DateTime?>(),
                It.IsAny<Status?>(),
                CancellationToken.None))
                .ReturnsAsync(new[] { expectedHistory })
                .Verifiable();

            var result = await _historyService.GetAllAsync(user.Id, new GetHistoryRequest(building.Id));

            result.Should().BeEquivalentTo(new[] { expectedHistory });

            _historyRepositoryMock.Verify(x => x.GetAllAsync(
                It.IsAny<Guid>(),
                It.IsAny<Guid?>(),
                It.IsAny<Guid?>(),
                It.IsAny<DateTime?>(),
                It.IsAny<Status?>(),
                CancellationToken.None), Times.Once);

            _buildingsServiceMock.Verify(x => x.GetAsync(
                It.IsAny<Guid>(),
                CancellationToken.None), Times.Once());

            _usersServiceMock.Verify(x => x.GetAsync(
               It.IsAny<Guid>(),
               CancellationToken.None), Times.Once());
        }

        [Fact]
        public async Task GetAsync_WithUnauthorizedUser_ShouldReturnNull()
        {
            var building = new Building("Building1");
            var role = new Role("admin", AccessLevel.admin, building.Id);

            var employeeRole = new Role("employee", AccessLevel.employee, building.Id);
            var user = new User("John", "Doe", "jdoe@mail.com", "8957429083");
            var userRole = new UserRole(user.Id, employeeRole.Id);

            user.UserRoles = new[] { userRole };
            building.Roles = new[] { role };

            var expectedHistory = new History(building.Id, Guid.NewGuid(), user.Id, Status.Open);

            _buildingsServiceMock.Setup(x => x.GetAsync(
                It.IsAny<Guid>(),
                CancellationToken.None))
                .ReturnsAsync(building)
                .Verifiable();

            _usersServiceMock.Setup(x => x.GetAsync(
                It.IsAny<Guid>(),
                CancellationToken.None))
                .ReturnsAsync(user)
                .Verifiable();

            var result = await _historyService.GetAllAsync(user.Id, new GetHistoryRequest(building.Id));

            result.Should().BeNullOrEmpty();

            _historyRepositoryMock.Verify(x => x.GetAllAsync(
             It.IsAny<Guid>(),
             It.IsAny<Guid?>(),
             It.IsAny<Guid?>(),
             It.IsAny<DateTime?>(),
             It.IsAny<Status?>(),
             CancellationToken.None), Times.Never);

            _buildingsServiceMock.Verify(x => x.GetAsync(
                It.IsAny<Guid>(),
                CancellationToken.None), Times.Once());

            _usersServiceMock.Verify(x => x.GetAsync(
               It.IsAny<Guid>(),
               CancellationToken.None), Times.Once());
        }
    }
}
