using System.Linq;
using System.Collections.Generic;

using FourWheels.Data.Models;
using FourWheels.Data.Repositories;
using FourWheels.Data.UnitOfWork;
using FourWheels.Services;
using FourWheels.Services.Contracts;

using Moq;
using NUnit.Framework;

namespace FourWheels.Tests.Services.UserServicesTests
{
    [TestFixture]
    public class GetUserById_Should
    {
        private Mock<IEfRepostory<User>> userRepo;
        private ICarAdServices carAdServicesMocked;
        private IEfUnitOfWork unitOfWorkMocked;
        private ICollection<User> users;
        private User expectedUser;

        [SetUp]
        public void Init()
        {
            this.userRepo = new Mock<IEfRepostory<User>>();
            this.carAdServicesMocked = new Mock<ICarAdServices>().Object;
            this.unitOfWorkMocked = new Mock<IEfUnitOfWork>().Object;

            this.users = new List<User>()
            {
                new User { UserName = "miro" },
                new User { UserName = "jivko" },
                new User { UserName = "gosho" },
            };

            this.expectedUser = new User
            {
                UserName = "pinko"
            };

            users.Add(expectedUser);

            var usersAsQuarable = this.users.AsQueryable();

            this.userRepo.Setup(x => x.All).Returns(usersAsQuarable);
        }

        [Test]
        public void ReturnUser_WithExactSameId()
        {
            // Arrange
            var userServices = new UserServices(
                this.userRepo.Object,
                this.carAdServicesMocked,
                this.unitOfWorkMocked);

            // Act 
            var actualReturnedUser = userServices.GetUserById(this.expectedUser.Id);

            // Assert
            Assert.AreSame(expectedUser, actualReturnedUser);
        }

        [Test]
        public void ReturnObject_WhichInstanceIsUser()
        {
            // Arrange
            var userServices = new UserServices(
                this.userRepo.Object,
                this.carAdServicesMocked,
                this.unitOfWorkMocked);

            // Act 
            var actualReturnedUser = userServices.GetUserById(this.expectedUser.Id);

            // Assert

            Assert.IsInstanceOf<User>(actualReturnedUser);
        }


        [Test]
        public void Call_AllMethodFromRepositoryOnce()
        {
            // Arrange
            var userServices = new UserServices(
                this.userRepo.Object,
                this.carAdServicesMocked,
                this.unitOfWorkMocked);

            // Act 
            userServices.GetUserById(this.expectedUser.Id);

            // Assert
            this.userRepo.Verify(x => x.All, Times.Once);
        }
    }
}
