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
    public class UpdateUserInfo_Should
    {
        private Mock<IEfRepostory<User>> userRepo;
        private ICarAdServices carAdServicesMocked;
        private Mock<IEfUnitOfWork> unitOfWorkMocked;

        [SetUp]
        public void Init()
        {
            this.userRepo = new Mock<IEfRepostory<User>>();
            this.carAdServicesMocked = new Mock<ICarAdServices>().Object;
            this.unitOfWorkMocked = new Mock<IEfUnitOfWork>();
        }

        [Test]
        public void Call_UpdateMethodFromRepositoryOnce()
        {
            // Arrange
            var userServices = new UserServices(
                this.userRepo.Object,
                this.carAdServicesMocked,
                this.unitOfWorkMocked.Object);

            // Act 
            userServices.UpdateUserInfo(It.IsAny<User>());

            // Assert
            this.userRepo.Verify(x => x.Update(It.IsAny<User>()), Times.Once);
        }

        [Test]
        public void Call_CommitFromUnitOfWorkOnce()
        {
            // Arrange
            var userServices = new UserServices(
                this.userRepo.Object,
                this.carAdServicesMocked,
                this.unitOfWorkMocked.Object);

            // Act 
            userServices.UpdateUserInfo(It.IsAny<User>());

            // Assert
            this.unitOfWorkMocked.Verify(x => x.Commit(), Times.Once);
        }
    }
}
