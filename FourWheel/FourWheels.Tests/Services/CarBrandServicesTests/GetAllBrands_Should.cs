using System.Linq;
using System.Collections.Generic;

using FourWheels.Data.Models;
using FourWheels.Data.Repositories;
using FourWheels.Services;

using Moq;
using NUnit.Framework;

namespace FourWheels.Tests.Services.CarBrandServicesTests
{
    [TestFixture]
    public class GetAllBrands_Should
    {
        private Mock<IEfRepostory<CarBrand>> carBrandRepoMocked;
        private IQueryable<CarBrand> carBrands;

        [SetUp]
        public void Init()
        {
            this.carBrandRepoMocked = new Mock<IEfRepostory<CarBrand>>();

            this.carBrands = new List<CarBrand>
            {
                new CarBrand { Brand = "Zaska" },
                new CarBrand { Brand = "Trabant" },
                new CarBrand { Brand = "Zastava" },
            }.AsQueryable();

            carBrandRepoMocked.Setup(x => x.All).Returns(carBrands);
        }

        [Test]
        public void ReturnQueryable_WithExactNumberOfCarBrands()
        {
            // Arrange
            var carBrandServices = new CarBrandServices(this.carBrandRepoMocked.Object);

            // Act 
            var expectedNumberOfCarBrands = carBrandServices.GetAllBrands().Count();

            // Assert
            Assert.AreEqual(expectedNumberOfCarBrands, this.carBrands.Count());
        }

        [Test]
        public void ReturnInstanceOfEnumerable_WithValidaDataIsPassed()
        {
            // Arrange
            var carBrandServices = new CarBrandServices(this.carBrandRepoMocked.Object);

            // Act 
            var carBrandsAll = carBrandServices.GetAllBrands();

            // Assert
            Assert.IsInstanceOf<IEnumerable<CarBrand>>(carBrandsAll);
        }

        [Test]
        public void Call_AllMethodFromRepositoryOnce()
        {
            // Arrange
            var carBrandServices = new CarBrandServices(this.carBrandRepoMocked.Object);

            // Act 
            carBrandServices.GetAllBrands();

            // Assert
            this.carBrandRepoMocked.Verify(x => x.All, Times.Once);
        }
    }
}
