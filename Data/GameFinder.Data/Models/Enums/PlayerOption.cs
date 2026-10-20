using System.ComponentModel.DataAnnotations;

namespace GameFinder.Data.Models.Enums
{
    public enum PlayerOption
    {
        Singleplayer,

        [Display(Name = "Local Co-Op")]
        LocalCoOp,

        [Display(Name = "Online Co-Op")]
        OnlineCoOp,

        [Display(Name = "Multiplayer")]
        Multiplayer,
        
    }
}
