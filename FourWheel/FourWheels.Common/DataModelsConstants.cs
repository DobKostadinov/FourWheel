namespace FourWheels.Common
{
    public class DataModelsConstants
    {
        // Town
        public const int MinLengthTownName = 2;
        public const int MaxLengthTownName = 50;

        // CarBrand
        public const int MinLengthCarBrand = 1;
        public const int MaxLengthCarBrand = 30;

        // CarModel
        public const int MinLengthCarModel = 1;
        public const int MaxLengthCarModel = 30;

        // MinManufacture Year
        public const int MinManufactureYear = 1930;
        public const int MaxManufactureYear = 2017;

        // Mileage
        public const int MinCarMileage = 0;
        public const int MaxCarMileage = 4000000;

        // CarAd
        public const int MinLengthAdTitle = 5;
        public const int MaxLengthAdTitle = 100;
        public const int MinCarPrice = 50;
        public const int MaxCarPrice = 5000000;
        public const int MinLengthAdditionalInfo = 5;
        public const int MaxLengthAdditionalInfo = 2000;

        // CarFeature
        public const int MinLengthCarFeature = 1;
        public const int MaxLengthCarFeature = 50;
    }
}
