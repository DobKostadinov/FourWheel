using System.Linq;
using System.Collections.Generic;

using FourWheels.Data.Models;
using FourWheels.Data.Repositories;
using FourWheels.Services;

using Moq;
using NUnit.Framework;

namespace FourWheels.Tests.Services.CountryServicesTests
{
    [TestFixture]
    public class GetAll_Should
    {
        private Mock<IEfRepostory<Town>> townRepoMocked;
        private IQueryable<Town> towns;

        [SetUp]
        public void Init()
        {
            this.townRepoMocked = new Mock<IEfRepostory<Town>>();

            this.towns = new List<Town>
            {
                new Town { Name = "Paris" },
                new Town { Name = "London" },
                new Town { Name = "Lisabon" },
            }.AsQueryable();

            townRepoMocked.Setup(x => x.All).Returns(towns);
        }

        [Test]
        public void ReturnQueryable_WithExactNumberOfTowns()
        {
            // Arrange
            var townServices = new TownServices(this.townRepoMocked.Object);

            // Act 
            var expectedNumberOfTowns = townServices.GetAllTowns().Count();

            // Assert
            Assert.AreEqual(expectedNumberOfTowns, this.towns.Count());
        }

        [Test]
        public void ReturnInstanceOfEnumerable_WithValidaDataIsPassed()
        {
            var townServices = new TownServices(this.townRepoMocked.Object);

            // Act 
            var allTownsResult = townServices.GetAllTowns();

            // Assert
            Assert.IsInstanceOf<IEnumerable<Town>>(allTownsResult);
        }

        [Test]
        public void Call_AllMethodFromRepositoryOnce()
        {
            // Arrange
            var townServices = new TownServices(this.townRepoMocked.Object);

            // Act 
            townServices.GetAllTowns();

            // Assert
            this.townRepoMocked.Verify(x => x.All, Times.Once);
        }
    }
}
