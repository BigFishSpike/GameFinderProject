using System.ComponentModel.DataAnnotations;

namespace GameFinder.Areas.Admin.ViewModels;

public class AdminUserViewModel
{
    [Key]
    public string Id { get; set; } = null!;

    public string? Email { get; set; }

    public string? UserName { get; set; }

    public List<string> Roles { get; set; } = new List<string>();

    public bool IsCurrentUser { get; set; }
}