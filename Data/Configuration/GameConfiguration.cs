namespace GameFinder.Data.Configuration
{
    using GameFinder.Data.Models;
    using GameFinder.Data.Models.Enums;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class GameConfiguration : IEntityTypeConfiguration<Game>
    {
        public static readonly IEnumerable<Game> InitialSeedGames = new List<Game>()
        {
            new Game
            {
                Id = 1,
                Name = "The Elder Scrolls V: Skyrim",
                Description = "A fantastic journey through the cold North of Tamriel, where dragons have awoken once more to spread chaos upon the world.",
                ImageUrl = "https://upload.wikimedia.org/wikipedia/en/1/15/The_Elder_Scrolls_V_Skyrim_cover.png?utm_source=en.wikipedia.org&utm_campaign=index&utm_content=original",
                Difficulty = Difficulty.Customisable,
                PlayerOptions = PlayerOptions.Singleplayer,
                GameModes = null,
                ReleaseDate = new DateOnly(2011, 11, 11),
                GenreId = 1,
            },
            new Game
            {
                Id = 2,
                Name = "The Witcher 3: Wild Hunt",
                Description = "Take upon the mantle of Witcher and play through the story of the legendary Geralt of Rivia, on his perilous quest through the Northern Realms to find his adopted daughter Ciri and stop the Wild Hunt, once and for all.",
                ImageUrl = "https://thumb.wikimedia.org/wikipedia/en/thumb/0/0c/Witcher_3_cover_art.jpg/250px-Witcher_3_cover_art.jpg?utm_source=en.wikipedia.org&utm_campaign=parser&utm_content=thumbnail",
                Difficulty = Difficulty.Customisable,
                PlayerOptions = PlayerOptions.Singleplayer,
                GameModes = null,
                ReleaseDate = new DateOnly(2015, 05, 19),
                GenreId = 1,
            },
            new Game
            {
                Id = 3,
                Name = "Dark Souls",
                Description = "Death is all that awaits you, stranger. Yet, would you dare become a hero, and enter the hallowed world of Lordran? If so - prepare to die, hero.",
                ImageUrl = "https://upload.wikimedia.org/wikipedia/en/8/8d/Dark_Souls_Cover_Art.jpg?utm_source=en.wikipedia.org&utm_campaign=index&utm_content=original",
                Difficulty = Difficulty.Hard,
                PlayerOptions = PlayerOptions.Flexible,
                GameModes = GameModes.Both,
                ReleaseDate = new DateOnly(2012, 08, 24),
                GenreId = 1,
            },
            new Game
            {
                Id = 4,
                Name = "Jump Space",
                Description = "Assemble your crew, and jump into this space-faring adventure as you navigate various missions together as a unit.",
                ImageUrl = "https://images.squarespace-cdn.com/content/v1/61a0b244de2c6f4f7fbc4108/c0e96d30-f186-4cc7-88db-b30b1b78c98f/JumpSpace_Wallpaper_4k.png",
                Difficulty = Difficulty.Medium,
                PlayerOptions = PlayerOptions.Multiplayer,
                GameModes = GameModes.PvE,
                ReleaseDate = new DateOnly(2025, 09, 19),
                GenreId = 2,
            },
            new Game
            {
                Id = 5,
                Name = "Doom",
                Description = "The world is in ruin, overrun by the very spawn of hell itself. But one man alone stands against the terror, to rip and tear until it is done.",
                ImageUrl = "https://thumb.wikimedia.org/wikipedia/en/thumb/2/28/Doom_Cover.jpg/250px-Doom_Cover.jpg?utm_source=en.wikipedia.org&utm_campaign=parser&utm_content=thumbnail",
                Difficulty = Difficulty.Customisable,
                PlayerOptions = PlayerOptions.Flexible,
                GameModes = GameModes.Both,
                ReleaseDate = new DateOnly(2016, 05, 13),
                GenreId = 2,
            },
            new Game
            {
                Id = 6,
                Name = "Counter-Strike 2",
                Description = "The classic competitive shooter, now with improved graphics and physics like never before. Enter the new era of Counter-Strike today, and prove that you're still worthy!",
                ImageUrl = "https://shared.fastly.steamstatic.com/store_item_assets/steam/apps/730/6328493f4cc4a8fb83e1149be1cac5a7823fe588/capsule_616x353.jpg?t=1789251637",
                Difficulty = Difficulty.Hard,
                PlayerOptions = PlayerOptions.Multiplayer,
                GameModes = GameModes.PvP,
                ReleaseDate = new DateOnly(2023, 09, 27),
                GenreId = 2,
            },
            new Game
            {
                Id = 7,
                Name = "Hades",
                Description = "Escape the Underworld(and your responsibilties) in this Godlike-Roguelike!",
                ImageUrl = "https://upload.wikimedia.org/wikipedia/en/c/cc/Hades_cover_art.jpg?utm_source=en.wikipedia.org&utm_campaign=index&utm_content=original",
                Difficulty = Difficulty.Customisable,
                PlayerOptions = PlayerOptions.Singleplayer,
                GameModes = null,
                ReleaseDate = new DateOnly(2020, 09, 17),
                GenreId = 3,
            },
            new Game
            {
                Id = 8,
                Name = "Dead Cells",
                Description = "Live. Die. Repeat. Fight your way out, or die trying. Then do it again. Also, make sure to deposit your cells before dying or you will be very mad at yourself!",
                ImageUrl = "https://upload.wikimedia.org/wikipedia/en/1/1f/Dead_cells_cover_art.png?utm_source=en.wikipedia.org&utm_campaign=index&utm_content=original",
                Difficulty = Difficulty.Medium,
                PlayerOptions = PlayerOptions.Singleplayer,
                GameModes = null,
                ReleaseDate = new DateOnly(2019, 08, 07),
                GenreId = 3,
            },
            new Game
            {
                Id = 9,
                Name = "Binding of Isaac",
                Description = "Help Isaac overcome his Mother's fury in the classic, groundbreaking, and still difficult-as-ever game.",
                ImageUrl = "https://thumb.wikimedia.org/wikipedia/en/thumb/f/fa/Binding_of_isaac_header.jpg/250px-Binding_of_isaac_header.jpg?utm_source=en.wikipedia.org&utm_campaign=parser&utm_content=thumbnail",
                Difficulty = Difficulty.Hard,
                PlayerOptions = PlayerOptions.Singleplayer,
                GameModes = null,
                ReleaseDate = new DateOnly(2011, 09, 28),
                GenreId = 3,
            },
            new Game
            {
                Id = 10,
                Name = "Subnautica",
                Description = "An underwater adventure awaits in this unforgettable, and terrifying, survival game.",
                ImageUrl = "https://shared.fastly.steamstatic.com/store_item_assets/steam/apps/264710/header.jpg?t=1777456112",
                Difficulty = Difficulty.Easy,
                PlayerOptions = PlayerOptions.Singleplayer,
                GameModes = null,
                ReleaseDate = new DateOnly(2018, 01, 23),
                GenreId = 4,
            },
            new Game
            {
                Id = 11,
                Name = "Valheim",
                Description = "Hail, warrior. Your time among the living has passed, but your duty has not. You are of Odyn's chosen, blessed with the task to help unite the Tenth World. Fulfill your destiny, brave warrior, and help banish the chaos.",
                ImageUrl = "https://upload.wikimedia.org/wikipedia/en/7/77/Valheim_2021_logo.jpg?utm_source=en.wikipedia.org&utm_campaign=index&utm_content=original",
                Difficulty = Difficulty.Medium,
                PlayerOptions = PlayerOptions.Flexible,
                GameModes = GameModes.PvE,
                ReleaseDate = new DateOnly(2026, 09, 09),
                GenreId = 4,
            },
            new Game
            {
                Id = 12,
                Name = "Project Zomboid",
                Description = "Survival. Crafting. Zombies. And also a lot of difficulty that glues it all together. This is the ultimate survival experience, but the question is - how long can YOU survive?",
                ImageUrl = "https://shared.fastly.steamstatic.com/store_item_assets/steam/apps/108600/header.jpg?t=1787740093",
                Difficulty = Difficulty.Hard,
                PlayerOptions = PlayerOptions.Flexible,
                GameModes = GameModes.PvE,
                ReleaseDate = new DateOnly(2026, 09, 09),
                GenreId = 4,
            },
            new Game
            {
                Id = 13,
                Name = "Powerwash Simulator",
                Description = "Experience the thrill of owning a powerwasher, and using it to clean the world of fiflth. The soothing sounds of the water are a bonus.",
                ImageUrl = "https://shared.fastly.steamstatic.com/store_item_assets/steam/apps/1290000/0184e192ea58230dd82aa8aed8134be3ed8fc4c2/capsule_616x353.jpg?t=1780392261",
                Difficulty = Difficulty.Casual,
                PlayerOptions = PlayerOptions.Flexible,
                GameModes = GameModes.PvE,
                ReleaseDate = new DateOnly(2026, 09, 09),
                GenreId = 5,
            },
            new Game
            {
                Id = 14,
                Name = "Goblin Cleanup",
                Description = "First of all, no, it's not what you think it is. Second - SOMEONE has to clean-up after all those nosy adventurers wreaking havoc on the dungeon. And third, yes you can wear a maid outfit. Yes, even as a male goblin.",
                ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQGN9aGZpAO7FsqFOOr1ZVSrTeExazop2kQQnVMwTO8-TTRJvtc4B8jTp3E&s=10",
                Difficulty = Difficulty.Easy,
                PlayerOptions = PlayerOptions.Flexible,
                GameModes = GameModes.PvE,
                ReleaseDate = new DateOnly(2025, 09, 18),
                GenreId = 5,
            },
            new Game
            {
                Id = 15,
                Name = "Viscera Cleanup Detail",
                Description = "The original clean-up game, the one to inspire many others, and the one that is still hardest to play because someone just can't stop kicking down the blood-filled buckets. You know who you are.",
                ImageUrl = "https://shared.akamai.steamstatic.com/store_item_assets/steam/apps/246900/header.jpg?t=1666984711",
                Difficulty = Difficulty.Hard,
                PlayerOptions = PlayerOptions.Flexible,
                GameModes = GameModes.PvE,
                ReleaseDate = new DateOnly(2015, 10, 23),
                GenreId = 5,
            },
        };

        public void Configure(EntityTypeBuilder<Game> builder)
        {
            builder.HasData(InitialSeedGames);
        }

    }
}
