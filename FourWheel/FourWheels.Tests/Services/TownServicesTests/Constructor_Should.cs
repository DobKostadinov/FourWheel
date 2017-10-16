using System;

using FourWheels.Services;
using FourWheels.Data.Models;
using FourWheels.Data.Repositories;
using FourWheels.Services.Contracts;

using NUnit.Framework;
using Moq;

namespace FourWheels.Tests.Services.TownServicesTests
{
    [TestFixture]
    public class Constructor_Should
    {
        private IEfRepostory<Town> townRepoMocked;

        [SetUp]
        public void Init()
        {
            this.townRepoMocked = new Mock<IEfRepostory<Town>>().Object;
        }

        [Test]
        public void ThrowArgumentNullException_WhenRepositoryIsNull()
        {
            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new TownServices(null));
        }

        [Test]
        public void NotThrow_WhenEverythingIsPassed()
        {
            // Act & Assert
            Assert.DoesNotThrow(() => new TownServices(this.townRepoMocked));
        }

        [Test]
        public void ReturnTownServiceInstance_WhenCorrectDataIsPassed()
        {
            // Act
            var newTownServiceInstance = new TownServices(this.townRepoMocked);

            // Assert
            Assert.IsInstanceOf<ITownServices>(newTownServiceInstance);
        }
    }
}
