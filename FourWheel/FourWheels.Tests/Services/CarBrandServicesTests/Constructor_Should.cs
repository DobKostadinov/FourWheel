using System;

using FourWheels.Services;
using FourWheels.Data.Models;
using FourWheels.Data.Repositories;
using FourWheels.Services.Contracts;

using NUnit.Framework;
using Moq;

namespace FourWheels.Tests.Services.CarBrandServicesTests
{
    [TestFixture]
    public class Constructor_Should
    {
        private IEfRepostory<CarBrand> carBranRepo;

        [SetUp]
        public void Init()
        {
            this.carBranRepo = new Mock<IEfRepostory<CarBrand>>().Object;
        }

        [Test]
        public void ThrowArgumentNullException_WhenRepositoryIsNull()
        {
            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new CarBrandServices(null));
        }

        [Test]
        public void NotThrow_WhenEverythingIsPassed()
        {
            // Act & Assert
            Assert.DoesNotThrow(() => new CarBrandServices(this.carBranRepo));
        }

        [Test]
        public void ReturnCarBrandServiceInstance_WhenCorrectDataIsPassed()
        {
            // Act
            var newCarBrandServiceInstance = new CarBrandServices(this.carBranRepo);

            // Assert
            Assert.IsInstanceOf<ICarBrandServices>(newCarBrandServiceInstance);
        }
    }
}
