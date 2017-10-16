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
    public class AllUserAds_Should
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
                UserName = "pinko",
                CarAds = new List<CarAd>
                {
                    new CarAd {Title = "The best car" },
                    new CarAd {Title = "It is amazing" }
                }
            };

            users.Add(expectedUser);

            var usersAsQuarable = this.users.AsQueryable();

            this.userRepo.Setup(x => x.All).Returns(usersAsQuarable);
        }

        [Test]
        public void ReturnExpectedUserAds_WhenUserIdIsPassed()
        {
            // Arrange
            var userServices = new UserServices(
                this.userRepo.Object,
                this.carAdServicesMocked,
                this.unitOfWorkMocked);

            // Act 
            var userAds = userServices.AllUserAds(this.expectedUser.Id);

            // Assert
            Assert.AreEqual(expectedUser.CarAds, userAds);
        }

        [Test]
        public void ReturnInstanceOfIQuarableOfCarAd_WhenUserIdIsPassed()
        {
            // Arrange
            var userServices = new UserServices(
                this.userRepo.Object,
                this.carAdServicesMocked,
                this.unitOfWorkMocked);

            // Act 
            var userAds = userServices.AllUserAds(this.expectedUser.Id);

            // Assert
            Assert.IsInstanceOf<IQueryable<CarAd>>(userAds);
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
            userServices.AllUserAds(this.expectedUser.Id);

            // Assert
            this.userRepo.Verify(x => x.All, Times.Once);
        }
    }
}
