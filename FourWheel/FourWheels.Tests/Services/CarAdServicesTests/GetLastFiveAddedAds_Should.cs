using System.Linq;
using System.Collections.Generic;

using FourWheels.Data.Models;
using FourWheels.Data.Repositories;
using FourWheels.Data.UnitOfWork;
using FourWheels.Services;
using FourWheels.Services.Contracts;

using Moq;
using NUnit.Framework;

namespace FourWheels.Tests.Services.CarAdServicesTests
{
    [TestFixture]
    public class GetLastFiveAddedAds_Should
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
                new CarAd { Title = "Be Mine!" },
                new CarAd { Title = "Be Yours!" },
            }.AsQueryable();

            this.carAdsRepoMock.Setup(x => x.All).Returns(carAds);
        }

        [Test]
        public void ReturnQueryable_WithExactlyFourOfCarAds()
        {
            // Arrange
            var carAdsServices = new CarAdServices(
                this.carAdsRepoMock.Object,
                this.carBrandsRepoMock,
                this.carModelsRepoMock,
                this.carFeatureServicesMock,
                this.unitOfWorkMocked);

            // Act 
            var exactlyFourCarAdsResult = carAdsServices.GetLastFiveAddedAds().Count();

            // Assert
            Assert.AreEqual(4, exactlyFourCarAdsResult);
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
            carAdsServices.GetLastFiveAddedAds();

            // Assert
            this.carAdsRepoMock.Verify(x => x.All, Times.Once);
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
            var allLatestCarAds = carAdsServices.GetLastFiveAddedAds();

            // Assert
            Assert.IsInstanceOf<IQueryable<CarAd>>(allLatestCarAds);
        }
    }
}
