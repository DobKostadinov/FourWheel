using System.Linq;
using System.Collections.Generic;

using FourWheels.Data.Models;
using FourWheels.Data.Repositories;
using FourWheels.Services;

using Moq;
using NUnit.Framework;
using FourWheels.Services.Contracts;
using FourWheels.Data.UnitOfWork;

namespace FourWheels.Tests.Services.CarAdServicesTests
{
    [TestFixture]
    public class GetAll_Should
    {
        private Mock<IEfRepostory<CarAd>> carAdsRepoMock;
        private IEfRepostory<CarBrand> carBrandsRepoMock;
        private IEfRepostory<CarModel> carModelsRepoMock;
        private ICarFeatureServices carFeatureServicesMock;
        private IEfUnitOfWork unitOfWorkMocked;
        private IQueryable<CarAd> carAds;

        [SetUp]
        public void Init()
        {
            this.carAdsRepoMock = new Mock<IEfRepostory<CarAd>>();
            this.carBrandsRepoMock = new Mock<IEfRepostory<CarBrand>>().Object;
            this.carModelsRepoMock = new Mock<IEfRepostory<CarModel>>().Object;
            this.carFeatureServicesMock = new Mock<ICarFeatureServices>().Object;
            this.unitOfWorkMocked = new Mock<IEfUnitOfWork>().Object;

            this.carAds = new List<CarAd>
            {
                new CarAd { Title = "Awesome car!" },
                new CarAd { Title = "Wohoo. Can be yours" },
                new CarAd { Title = "Be fast!" },
            }.AsQueryable();

            this.carAdsRepoMock.Setup(x => x.All).Returns(carAds);
        }   

        [Test]
        public void ReturnQueryable_WithExactNumberOfCarAds()
        {
            // Arrange
            var carAdsServices = new CarAdServices(
                this.carAdsRepoMock.Object,
                this.carBrandsRepoMock,
                this.carModelsRepoMock,
                this.carFeatureServicesMock,
                this.unitOfWorkMocked);

            // Act 
            var allCarAdsCount = carAdsServices.GetAll().Count();

            // Assert
            Assert.AreEqual(allCarAdsCount, this.carAds.Count());
        }

        [Test]
        public void ReturnInstanceOfQuarable_WithValidaDataIsPassed()
        {
            // Arrange
            var carAdsServices = new CarAdServices(
                this.carAdsRepoMock.Object,
                this.carBrandsRepoMock,
                this.carModelsRepoMock,
                this.carFeatureServicesMock,
                this.unitOfWorkMocked);

            // Act 
            var allCarAds = carAdsServices.GetAll();

            // Assert
            Assert.IsInstanceOf<IQueryable<CarAd>>(allCarAds);
        }

        [Test]
        public void Call_AllMethodFromRepositoryOnce()
        {
            // Arrange
            var carAdsServices = new CarAdServices(
                this.carAdsRepoMock.Object,
                this.carBrandsRepoMock,
                this.carModelsRepoMock,
                this.carFeatureServicesMock,
                this.unitOfWorkMocked);

            // Act 
            carAdsServices.GetAll();

            // Assert
            this.carAdsRepoMock.Verify(x => x.All, Times.Once);
        }
    }
}
