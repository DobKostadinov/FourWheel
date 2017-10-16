using System;
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
    public class GetAdById_Should
    {
        private Mock<IEfRepostory<CarAd>> carAdsRepoMock;
        private IEfRepostory<CarBrand> carBrandsRepoMock;
        private IEfRepostory<CarModel> carModelsRepoMock;
        private ICarFeatureServices carFeatureServicesMock;
        private IEfUnitOfWork unitOfWorkMocked;
        private ICollection<CarAd> carAds;
        private CarAd expectedCarAd;

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
            };

            this.expectedCarAd = new CarAd
            {
                Title = "Wohooo"
            };

            carAds.Add(expectedCarAd);

            var carAdsQuarable = this.carAds.AsQueryable();

            this.carAdsRepoMock.Setup(x => x.All).Returns(carAdsQuarable);
        }

        [Test]
        public void ReturnCarAd_WithExactSameId()
        {
            // Arrange
            var carAdsServices = new CarAdServices(
                this.carAdsRepoMock.Object,
                this.carBrandsRepoMock,
                this.carModelsRepoMock,
                this.carFeatureServicesMock,
                this.unitOfWorkMocked);

            // Act 
            var actualReturnedCarAd = carAdsServices.GetAdById(this.expectedCarAd.Id);
       
            // Assert
            Assert.AreSame(this.expectedCarAd, actualReturnedCarAd);
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
            carAdsServices.GetAdById(It.IsAny<Guid>());

            // Assert
            this.carAdsRepoMock.Verify(x => x.All, Times.Once);
        }
    }
}
