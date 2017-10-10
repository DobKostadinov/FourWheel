namespace FourWheels.Common
{
    public class DataModelsConstants
    {
        // Country
        public const int MinLengthCountryName = 2;
        public const int MaxLengthCountryName = 50;

        // Region
        public const int MinLengthRegionName = 3;
        public const int MaxLengthRegionName = 50;

        // Winery
        public const int MinLengthWineryName = 1;
        public const int MaxLengthWineryName = 20;

        // Wine
        public const int MinLengthWineName = 2;
        public const int MaxLengthWineName = 20;
        public const int MinLengthGrapeName = 4;
        public const int MaxLengthGrapeName = 30;
        public const int MinYearOfWineProduction = 1970;
        public const int MaxYearOfWineProduction = 2017;

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
