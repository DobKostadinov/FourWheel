using System;

using FourWheels.Services;
using FourWheels.Data.Models;
using FourWheels.Data.Repositories;
using FourWheels.Services.Contracts;

using NUnit.Framework;
using Moq;

namespace FourWheels.Tests.Services.CarFeatureServicesTests
{
    [TestFixture]
    public class Constructor_Should
    {
        private IEfRepostory<CarFeature> carFeatureRepo;

        [SetUp]
        public void Init()
        {
            this.carFeatureRepo = new Mock<IEfRepostory<CarFeature>>().Object;
        }

        [Test]
        public void ThrowArgumentNullException_WhenRepositoryIsNull()
        {
            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new CarFeaturesServices(null));
        }

        [Test]
        public void NotThrow_WhenEverythingIsPassed()
        {
            // Act & Assert
            Assert.DoesNotThrow(() => new CarFeaturesServices(this.carFeatureRepo));
        }

        [Test]
        public void ReturnCarFeatureServiceInstance_WhenCorrectDataIsPassed()
        {
            // Act
            var newCarFeatureServiceInstance = new CarFeaturesServices(this.carFeatureRepo);

            // Assert
            Assert.IsInstanceOf<ICarFeatureServices>(newCarFeatureServiceInstance);
        }
    }
}
