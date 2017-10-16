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
using FourWheels.Data.Models.Enums;

namespace FourWheels.Tests.Services.CarAdServicesTests
{
    public class AddNewCarAd_Should
    {
        private Mock<IEfRepostory<CarAd>> carAdsRepoMock;
        private IEfRepostory<CarBrand> carBrandsRepoMock;
        private IEfRepostory<CarModel> carModelsRepoMock;
        private Mock<ICarFeatureServices> carFeatureServicesMock;
        private Mock<IEfUnitOfWork> unitOfWorkMocked;
        private IQueryable<CarAd> carAds;

        [SetUp]
        public void Init()
        {
            this.carAdsRepoMock = new Mock<IEfRepostory<CarAd>>();
            this.carBrandsRepoMock = new Mock<IEfRepostory<CarBrand>>().Object;
            this.carModelsRepoMock = new Mock<IEfRepostory<CarModel>>().Object;
            this.carFeatureServicesMock = new Mock<ICarFeatureServices>();
            this.unitOfWorkMocked = new Mock<IEfUnitOfWork>();

            this.carAds = new List<CarAd>
            {
                new CarAd { Title = "Awesome car!" },
                new CarAd { Title = "Wohoo. Can be yours" },
                new CarAd { Title = "Be fast!" },
            }.AsQueryable();
        }

        [Test]
        public void Call_GetAllCarFeatures_FromCarFeatureServicesOnce()
        {
            // Arrange
            var carAdsServices = new CarAdServices(
                this.carAdsRepoMock.Object,
                this.carBrandsRepoMock,
                this.carModelsRepoMock,
                this.carFeatureServicesMock.Object,
                this.unitOfWorkMocked.Object);

            var firstCarFeature = new CarFeature { Name = "Klima!" };
            var secondCarFeature = new CarFeature { Name = "Windows!" };

            var carFeatures = new List<CarFeature>
            {
                firstCarFeature,
                secondCarFeature
            };

            var carFeaturesIds = new List<string>
            {
                firstCarFeature.Id.ToString(),
                secondCarFeature.Id.ToString(),
            };

            this.carFeatureServicesMock.Setup(x => x.GetAllCarFeatures()).Returns(carFeatures.AsQueryable());

            // Act 
            carAdsServices.AddNewCarAd(
                It.IsAny<string>(),
                It.IsAny<Guid>(),
                It.IsAny<CarType>(),
                It.IsAny<int>(),
                It.IsAny<int>(),
                It.IsAny<FuelType>(),
                It.IsAny<TransmissionType>(),
                carFeaturesIds,
                It.IsAny<Guid>(),
                It.IsAny<double>(),
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<string>());

            // Assert
            this.carFeatureServicesMock.Verify(x => x.GetAllCarFeatures(), Times.Once);
        }

        [Test]
        public void Call_AddMethod_FromCarAdRepositoryOnce()
        {
            // Arrange
            var carAdsServices = new CarAdServices(
                this.carAdsRepoMock.Object,
                this.carBrandsRepoMock,
                this.carModelsRepoMock,
                this.carFeatureServicesMock.Object,
                this.unitOfWorkMocked.Object);

            var firstCarFeature = new CarFeature { Name = "Klima!" };
            var secondCarFeature = new CarFeature { Name = "Windows!" };

            var carFeatures = new List<CarFeature>
            {
                firstCarFeature,
                secondCarFeature
            };

            var carFeaturesIds = new List<string>
            {
                firstCarFeature.Id.ToString(),
                secondCarFeature.Id.ToString(),
            };

            this.carFeatureServicesMock.Setup(x => x.GetAllCarFeatures()).Returns(carFeatures.AsQueryable());

            // Act 
            carAdsServices.AddNewCarAd(
                It.IsAny<string>(),
                It.IsAny<Guid>(),
                It.IsAny<CarType>(),
                It.IsAny<int>(),
                It.IsAny<int>(),
                It.IsAny<FuelType>(),
                It.IsAny<TransmissionType>(),
                carFeaturesIds,
                It.IsAny<Guid>(),
                It.IsAny<double>(),
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<string>());

            // Assert
            this.carAdsRepoMock.Verify(x => x.Add(It.IsAny<CarAd>()), Times.Once);
        }

        [Test]
        public void Call_CommitMethod_FromUnitOfWorkOnce()
        {
            // Arrange
            var carAdsServices = new CarAdServices(
                this.carAdsRepoMock.Object,
                this.carBrandsRepoMock,
                this.carModelsRepoMock,
                this.carFeatureServicesMock.Object,
                this.unitOfWorkMocked.Object);

            var firstCarFeature = new CarFeature { Name = "Klima!" };
            var secondCarFeature = new CarFeature { Name = "Windows!" };

            var carFeatures = new List<CarFeature>
            {
                firstCarFeature,
                secondCarFeature
            };

            var carFeaturesIds = new List<string>
            {
                firstCarFeature.Id.ToString(),
                secondCarFeature.Id.ToString(),
            };

            this.carFeatureServicesMock.Setup(x => x.GetAllCarFeatures()).Returns(carFeatures.AsQueryable());

            // Act 
            carAdsServices.AddNewCarAd(
                It.IsAny<string>(),
                It.IsAny<Guid>(),
                It.IsAny<CarType>(),
                It.IsAny<int>(),
                It.IsAny<int>(),
                It.IsAny<FuelType>(),
                It.IsAny<TransmissionType>(),
                carFeaturesIds,
                It.IsAny<Guid>(),
                It.IsAny<double>(),
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<string>());

            // Assert
            this.unitOfWorkMocked.Verify(x => x.Commit(), Times.Once);
        }
    }
}
