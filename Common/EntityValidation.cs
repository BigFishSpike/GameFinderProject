namespace GameFinder.Common
{
    public static class EntityValidation
    {
        public static class User
        {
            public const int UsernameMinLength = 3;
            public const int UsernameMaxLength = 36;

            public const int PasswordMinLength = 6;
            public const int PasswordMaxLength = 128; //debating on wether to keep it or remove the max limit; setting a high one for now
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

    }
}
