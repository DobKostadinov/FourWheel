using System;

using FourWheels.Services;
using FourWheels.Data.Models;
using FourWheels.Data.Repositories;
using FourWheels.Services.Contracts;

using NUnit.Framework;
using Moq;

namespace FourWheels.Tests.Services.CarModelServicesTests
{
    [TestFixture]
    public class Constructor_Should
    {
        private IEfRepostory<CarModel> carModelRepo;

        [SetUp]
        public void Init()
        {
            this.carModelRepo = new Mock<IEfRepostory<CarModel>>().Object;
        }

        [Test]
        public void ThrowArgumentNullException_WhenRepositoryIsNull()
        {
            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new CarModelServices(null));
        }

        [Test]
        public void NotThrow_WhenEverythingIsPassed()
        {
            // Act & Assert
            Assert.DoesNotThrow(() => new CarModelServices(this.carModelRepo));
        }

        [Test]
        public void ReturnCarModelServicesInstance_WhenCorrectDataIsPassed()
        {
            // Act
            var newCarFeatureServicesInstance = new CarModelServices(this.carModelRepo);

            // Assert
            Assert.IsInstanceOf<ICarModelServices>(newCarFeatureServicesInstance);
        }
    }
}
