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
    public class DeleteAd_Should
    {
        private Mock<IEfRepostory<CarAd>> carAdsRepoMock;
        private IEfRepostory<CarBrand> carBrandsRepoMock;
        private IEfRepostory<CarModel> carModelsRepoMock;
        private ICarFeatureServices carFeatureServicesMock;
        private Mock<IEfUnitOfWork> unitOfWorkMocked;
        private IQueryable<CarAd> carAds;

        [SetUp]
        public void Init()
        {
            this.carAdsRepoMock = new Mock<IEfRepostory<CarAd>>();
            this.carBrandsRepoMock = new Mock<IEfRepostory<CarBrand>>().Object;
            this.carModelsRepoMock = new Mock<IEfRepostory<CarModel>>().Object;
            this.carFeatureServicesMock = new Mock<ICarFeatureServices>().Object;
            this.unitOfWorkMocked = new Mock<IEfUnitOfWork>();

            this.carAds = new List<CarAd>
            {
                new CarAd { Title = "Awesome car!" },
                new CarAd { Title = "Wohoo. Can be yours" },
                new CarAd { Title = "Be fast!" },
            }.AsQueryable();
        }

        [Test]
        public void RemoveOneElementFromCollection_WhenValitEntityIsPassed()
        {
            // Arrange
            var carAdsServices = new CarAdServices(
                this.carAdsRepoMock.Object,
                this.carBrandsRepoMock,
                this.carModelsRepoMock,
                this.carFeatureServicesMock,
                this.unitOfWorkMocked.Object);

            var countBeforeDelete = carAds.Count();

            var carAdsAllAsEnumerable = carAds.ToList();

            this.carAdsRepoMock.Setup(x => x.Delete(It.IsAny<CarAd>()))
                .Callback(() =>
                {
                    carAdsAllAsEnumerable.Remove(carAds.ToList().First());

                });

            // Act 
            carAdsServices.DeleteAd(It.IsAny<Guid>());

            var countAfterDelete = carAdsAllAsEnumerable.Count();

            // Assert
            Assert.AreEqual(countBeforeDelete - 1, countAfterDelete);
        }


        [Test]
        public void Call_GetByIdMethodFromRepositoryOnce()
        {
            // Arrange
            var carAdsServices = new CarAdServices(
                this.carAdsRepoMock.Object,
                this.carBrandsRepoMock,
                this.carModelsRepoMock,
                this.carFeatureServicesMock,
                this.unitOfWorkMocked.Object);

            // Act 
            carAdsServices.DeleteAd(It.IsAny<Guid>());

            // Assert
            this.carAdsRepoMock.Verify(x => x.GetById(It.IsAny<Guid>()), Times.Once);
        }

        [Test]
        public void Call_CommitFromUnitOfWorkOnce()
        {
            // Arrange
            var carAdsServices = new CarAdServices(
                this.carAdsRepoMock.Object,
                this.carBrandsRepoMock,
                this.carModelsRepoMock,
                this.carFeatureServicesMock,
                this.unitOfWorkMocked.Object);

            // Act 
            carAdsServices.DeleteAd(It.IsAny<Guid>());

            // Assert
            this.unitOfWorkMocked.Verify(x => x.Commit(), Times.Once);
        }

        [Test]
        public void Call_DeleteFromRepositoryOnce()
        {
            // Arrange
            var carAdsServices = new CarAdServices(
                this.carAdsRepoMock.Object,
                this.carBrandsRepoMock,
                this.carModelsRepoMock,
                this.carFeatureServicesMock,
                this.unitOfWorkMocked.Object);

            // Act 
            carAdsServices.DeleteAd(It.IsAny<Guid>());

            // Assert
            this.carAdsRepoMock.Verify(x => x.Delete(It.IsAny<CarAd>()), Times.Once);
        }
    }
}
