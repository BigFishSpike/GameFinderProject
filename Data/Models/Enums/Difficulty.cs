using System.ComponentModel.DataAnnotations;

namespace GameFinder.Data.Models.Enums
{
    public enum Difficulty
    {
        [Display(Name = "More than one available/customizable difficulty")]
        Customizable,
        Casual,
        Easy,
        Medium,
        Hard,
    }
}
