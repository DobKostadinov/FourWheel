namespace FourWheels.Common
{
    public class DataModelsConstants
    {
        // Town
        public const int MinLengthTownName = 2;
        public const int MaxLengthTownName = 50;

        // CarBrand
        public const int MinLengthCarBrand = 2;
        public const int MaxLengthCarBrand = 50;

        // CarModel
        public const int MinLengthCarModel = 1;
        public const int MaxLengthCarModel = 20;

        // MinManufacture Year
        public const int MinManufactureYear = 1950;
        public const int MaxManufactureYear = 2017;

        // Mileage
        public const int MinCarMileage = 0;
        public const int MaxCarMileage = 4000000;


        // WineReview
        public const int MinLengthWineReviewTitle = 5;
        public const int MaxLengthWineReviewTitle = 40;
        public const int MinLengthWineReviewOpinion = 10;
        public const int MaxLengthWineReviewOpinion = 2000;
        public const int MinWineReviewRating = 1;
        public const int MaxWineReviewRating = 10;

        // ReviewComment
        public const int MinLengthReviewContent = 5;
        public const int MaxLengthReviewContent = 200;
    }
}
