using System;

using FourWheels.Services;
using FourWheels.Data.Models;
using FourWheels.Data.Repositories;
using FourWheels.Services.Contracts;

using NUnit.Framework;
using Moq;
using FourWheels.Data.UnitOfWork;

namespace FourWheels.Tests.Services.CarAdServicesTests
{
    public class Constructor_Should
    {
        private IEfRepostory<CarAd> carAdsRepoMock;
        private IEfRepostory<CarBrand> carBrandsRepoMock;
        private IEfRepostory<CarModel> carModelsRepoMock;
        private ICarFeatureServices carFeatureServicesMock;
        private IEfUnitOfWork unitOfWorkMocked;

        [SetUp]
        public void Init()
        {
            this.carAdsRepoMock = new Mock<IEfRepostory<CarAd>>().Object;
            this.carBrandsRepoMock = new Mock<IEfRepostory<CarBrand>>().Object;
            this.carModelsRepoMock = new Mock<IEfRepostory<CarModel>>().Object;
            this.carFeatureServicesMock = new Mock<ICarFeatureServices>().Object;
            this.unitOfWorkMocked = new Mock<IEfUnitOfWork>().Object;
        }

        [Test]
        public void ThrowArgumentNullException_WhenCarAdsRepositoryIsNull()
        {
            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new CarAdServices(
                null,
                this.carBrandsRepoMock,
                this.carModelsRepoMock,
                this.carFeatureServicesMock,
                this.unitOfWorkMocked));
        }

        [Test]
        public void ThrowArgumentNullException_WhenCarBrandsRepositoryIsNull()
        {
            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new CarAdServices(
                this.carAdsRepoMock,
                null,
                this.carModelsRepoMock,
                this.carFeatureServicesMock,
                this.unitOfWorkMocked));
        }

        [Test]
        public void ThrowArgumentNullException_WhenCarModelsRepositoryIsNull()
        {
            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new CarAdServices(
                this.carAdsRepoMock,
                this.carBrandsRepoMock,
                null,
                this.carFeatureServicesMock,
                this.unitOfWorkMocked));
        }

        [Test]
        public void ThrowArgumentNullException_WhenCarFeatureServiceIsNull()
        {
            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new CarAdServices(
                this.carAdsRepoMock,
                this.carBrandsRepoMock,
                this.carModelsRepoMock,
                null,
                this.unitOfWorkMocked));
        }

        [Test]
        public void ThrowArgumentNullException_WhenUnitOfWorkIsNull()
        {
            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new CarAdServices(
                this.carAdsRepoMock,
                this.carBrandsRepoMock,
                this.carModelsRepoMock,
                this.carFeatureServicesMock,
                null));
        }

        [Test]
        public void NotThrow_WhenEverythingIsPassed()
        {
            // Act & Assert
            Assert.DoesNotThrow(() => new CarAdServices(
                this.carAdsRepoMock,
                this.carBrandsRepoMock,
                this.carModelsRepoMock,
                this.carFeatureServicesMock,
                this.unitOfWorkMocked));
        }

        [Test]
        public void ReturnTownServiceInstance_WhenCorrectDataIsPassed()
        {
            // Act
            var newCarAdServiceInstance = new CarAdServices(
                this.carAdsRepoMock,
                this.carBrandsRepoMock,
                this.carModelsRepoMock,
                this.carFeatureServicesMock,
                this.unitOfWorkMocked);

            // Assert
            Assert.IsInstanceOf<ICarAdServices>(newCarAdServiceInstance);
        }
    }
}
