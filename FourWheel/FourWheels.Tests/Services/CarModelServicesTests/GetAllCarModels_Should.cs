using System.Linq;
using System.Collections.Generic;

using FourWheels.Data.Models;
using FourWheels.Data.Repositories;
using FourWheels.Services;

using Moq;
using NUnit.Framework;

namespace FourWheels.Tests.Services.CarModelServicesTests
{
    [TestFixture]
    public class GetAllCarModels_Should
    {
        private Mock<IEfRepostory<CarModel>> carModelsRepoMocked;
        private IQueryable<CarModel> carModels;

        [SetUp]
        public void Init()
        {
            this.carModelsRepoMocked = new Mock<IEfRepostory<CarModel>>();

            this.carModels = new List<CarModel>
            {
                new CarModel { Model = "A99" },
                new CarModel { Model = "Y6" },
                new CarModel { Model = "Ugly" },
            }.AsQueryable();

            carModelsRepoMocked.Setup(x => x.All).Returns(carModels);
        }

        [Test]
        public void ReturnQueryable_WithExactNumberOfCarModels()
        {
            // Arrange
            var carModelsServices = new CarModelServices(this.carModelsRepoMocked.Object);

            // Act 
            var expectedNumberOfCarModels = carModelsServices.GetAllCarModels().Count();

            // Assert
            Assert.AreEqual(expectedNumberOfCarModels, this.carModels.Count());
        }

        [Test]
        public void ReturnInstanceOfEnumerable_WithValidaDataIsPassed()
        {
            // Arrange
            var carModelsServices = new CarModelServices(this.carModelsRepoMocked.Object);

            // Act 
            var allCarsResult = carModelsServices.GetAllCarModels();

            // Assert
            Assert.IsInstanceOf<IEnumerable<CarModel>>(allCarsResult);
        }

        [Test]
        public void Call_AllMethodFromRepositoryOnce()
        {
            // Arrange
            var carModelServices = new CarModelServices(this.carModelsRepoMocked.Object);

            // Act 
            carModelServices.GetAllCarModels();

            // Assert
            this.carModelsRepoMocked.Verify(x => x.All, Times.Once);
        }
    }
}
