using System.ComponentModel.DataAnnotations;

namespace GameFinder.ViewModels.Game
{
    public class GameEditViewModel : GameAddViewModel
    {
        [Key]
        public int Id { get; set; }
    }
}
