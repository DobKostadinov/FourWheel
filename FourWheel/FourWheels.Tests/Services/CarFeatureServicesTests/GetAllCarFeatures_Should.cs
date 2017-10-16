using System.Linq;
using System.Collections.Generic;

using FourWheels.Data.Models;
using FourWheels.Data.Repositories;
using FourWheels.Services;

using Moq;
using NUnit.Framework;

namespace FourWheels.Tests.Services.CarFeatureServicesTests
{
    [TestFixture]
    public class GetAllCarFeatures_Should
    {
        private Mock<IEfRepostory<CarFeature>> carFeaturesRepoMocked;
        private IQueryable<CarFeature> carFeatures;

        [SetUp]
        public void Init()
        {
            this.carFeaturesRepoMocked = new Mock<IEfRepostory<CarFeature>>();

            this.carFeatures = new List<CarFeature>
            {
                new CarFeature { Name = "Klimatik" },
                new CarFeature { Name = "Heating" },
                new CarFeature { Name = "Seats" },
            }.AsQueryable();

            carFeaturesRepoMocked.Setup(x => x.All).Returns(carFeatures);
        }

        [Test]
        public void ReturnQueryable_WithExactNumberOfCarFeatures()
        {
            // Arrange
            var carFeatureServices = new CarFeaturesServices(this.carFeaturesRepoMocked.Object);

            // Act 
            var expectedNumberOfCarFeatures = carFeatureServices.GetAllCarFeatures().Count();

            // Assert
            Assert.AreEqual(expectedNumberOfCarFeatures, this.carFeatures.Count());
        }

        [Test]
        public void ReturnInstanceOfQuarable_WithValidaDataIsPassed()
        {
            // Arrange
            var carFeatureServices = new CarFeaturesServices(this.carFeaturesRepoMocked.Object);

            // Act 
            var allCarFeaturesResult = carFeatureServices.GetAllCarFeatures();

            // Assert
            Assert.IsInstanceOf<IQueryable<CarFeature>>(allCarFeaturesResult);
        }


        [Test]
        public void Call_AllMethodFromRepositoryOnce()
        {
            // Arrange
            var carFeaturesServices = new CarFeaturesServices(this.carFeaturesRepoMocked.Object);

            // Act 
            carFeaturesServices.GetAllCarFeatures();

            // Assert
            this.carFeaturesRepoMocked.Verify(x => x.All, Times.Once);
        }
    }
}
