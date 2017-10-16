using System.Linq;
using System.Collections.Generic;

using FourWheels.Data.Models;
using FourWheels.Data.Repositories;
using FourWheels.Services;

using Moq;
using NUnit.Framework;
using System;

namespace FourWheels.Tests.Services.CarModelServicesTests
{
    [TestFixture]
    public class GetAllModelsByBrand_Should
    {
        private Mock<IEfRepostory<CarModel>> carModelsRepoMocked;

        [SetUp]
        public void Init()
        {
            this.carModelsRepoMocked = new Mock<IEfRepostory<CarModel>>();
        }

        [Test]
        public void ReturnCarModelObject_WithExactPassedId()
        {
            // Arrange
            var expectedBrandId = Guid.NewGuid();
            var randomRandomBrandId = Guid.NewGuid();

            var carModels = new List<CarModel>
            {
                new CarModel { Model = "A99", CarBrandId = expectedBrandId},
                new CarModel { Model = "Y6", CarBrandId = expectedBrandId },
                new CarModel { Model = "Ugly", CarBrandId = randomRandomBrandId},
                new CarModel { Model = "A3", CarBrandId = randomRandomBrandId },
            }.AsQueryable();

            carModelsRepoMocked.Setup(x => x.All).Returns(carModels);

            var carModelsServices = new CarModelServices(this.carModelsRepoMocked.Object);

            // Act 
            var carModelsFromExecution = carModelsServices.GetAllModelsByBrand(expectedBrandId);

            // Assert
            Assert.AreEqual(2, carModelsFromExecution.Count());
        }

        [Test]
        public void ReturnInstanceOfEnumerable_WithValidaDataIsPassed()
        {
            // Arrange
            var carModelsServices = new CarModelServices(this.carModelsRepoMocked.Object);

            // Act 
            var allCarModelsResult = carModelsServices.GetAllModelsByBrand(It.IsAny<Guid>());

            // Assert
            Assert.IsInstanceOf<IEnumerable<CarModel>>(allCarModelsResult);
        }


        [Test]
        public void Call_AllMethodFromRepositoryOnce()
        {
            // Arrange
            var expectedBrandId = Guid.NewGuid();
            var randomRandomBrandId = Guid.NewGuid();

            var carModels = new List<CarModel>
            {
                new CarModel { Model = "A99", CarBrandId = expectedBrandId},
                new CarModel { Model = "Y6", CarBrandId = expectedBrandId },
                new CarModel { Model = "Ugly", CarBrandId = randomRandomBrandId},
                new CarModel { Model = "A3", CarBrandId = randomRandomBrandId },
            }.AsQueryable();

            carModelsRepoMocked.Setup(x => x.All).Returns(carModels);

            var carModelsServices = new CarModelServices(this.carModelsRepoMocked.Object);

            // Act 
            carModelsServices.GetAllModelsByBrand(expectedBrandId);

            // Assert
            this.carModelsRepoMocked.Verify(x => x.All, Times.Once);
        }
    }
}
