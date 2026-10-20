namespace GameFinder.Common
{
    public static class EntityValidation
    {
        public static class User
        {         
            public const int UserNameMinLength = 3;
            public const int UserNameMaxLength = 50;

        }
        public static class Game
        {
            public const int GameNameMinLength = 2;
            public const int GameNameMaxLength = 150;

            public const int GameDescriptionMaxLength = 500;

            public const int GameImageUrlMaxLength = 2083;

        }

        public static class Genre
        {
            public const int GenreNameMinLength = 3;
            public const int GenreNameMaxLength = 64;

            public const int GenreDescriptionMaxLength = 350;

            public const int GenreImageUrlMaxLength = 2083;
        }
        public static class ApplicationConstants
        {
            public const int EntitiesPerPage = 15;

            public const string ApplicationDateFormat = "dd/MM/yyyy";

        }
        public static class SearchDefaults
        {
            public const string DefaultGenre = "No genre preference";
            public const string DefaultGameMode = "Doesn't bother me either way";
            public const string DefaultPlayerOption = "Any and all players";
            public const string DefaultDifficulty = "I can handle anything";

        }
    }
}
