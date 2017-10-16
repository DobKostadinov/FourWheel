using System;

using FourWheels.Services;
using FourWheels.Data.Models;
using FourWheels.Data.Repositories;
using FourWheels.Services.Contracts;

using NUnit.Framework;
using Moq;
using FourWheels.Data.UnitOfWork;

namespace FourWheels.Tests.Services.UserServicesTests
{
    public class Constructor_Should
    {
        private IEfRepostory<User> userRepoMock;
        private ICarAdServices carAdServicesMocked;
        private IEfUnitOfWork unitOfWorkMocked;

        [SetUp]
        public void Init()
        {
            this.userRepoMock = new Mock<IEfRepostory<User>>().Object;
            this.carAdServicesMocked = new Mock<ICarAdServices>().Object;
            this.unitOfWorkMocked = new Mock<IEfUnitOfWork>().Object;
        }

        [Test]
        public void ThrowArgumentNullException_WhenRepositoryIsNull()
        {
            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new UserServices(
                null,
                this.carAdServicesMocked,
                this.unitOfWorkMocked));
        }

        [Test]
        public void ThrowArgumentNullException_WhenCarAdServicesIsNull()
        {
            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new UserServices(
                this.userRepoMock,
                null,
                this.unitOfWorkMocked));
        }

        [Test]
        public void ThrowArgumentNullException_WhenIUnitOfWorkIsNull()
        {
            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new UserServices(
                this.userRepoMock,
                this.carAdServicesMocked,
                null));
        }

        [Test]
        public void NotThrow_WhenEverythingIsPassed()
        {
            // Act & Assert
            Assert.DoesNotThrow(() => new UserServices(
                this.userRepoMock,
                this.carAdServicesMocked,
                this.unitOfWorkMocked));
        }

        [Test]
        public void ReturnUserServiceInstance_WhenCorrectDataIsPassed()
        {
            // Act
            var newUserServiceInstance = new UserServices(
                this.userRepoMock,
                this.carAdServicesMocked,
                this.unitOfWorkMocked);

            // Assert
            Assert.IsInstanceOf<IUserServices>(newUserServiceInstance);
        }
    }
}
