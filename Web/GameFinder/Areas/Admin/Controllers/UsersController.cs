namespace GameFinder.Areas.Admin.Controllers;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static Common.Constants.Roles;
using GameFinder.Areas.Admin.ViewModels;

[Area("Admin")]
[Authorize(Roles = "Administrator")]
public class UsersController : Controller
{
    private readonly UserManager<IdentityUser> _userManager;

    public UsersController(UserManager<IdentityUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task<IActionResult> Index()
    {
        List<IdentityUser> users = await _userManager.Users
            .OrderBy(u => u.Email)
            .ToListAsync();

        string? currentUserId = _userManager.GetUserId(User);

        List<AdminUserViewModel> userModels = new List<AdminUserViewModel>();

        foreach (IdentityUser user in users)
        {
            IList<string> roles = await _userManager.GetRolesAsync(user);

            AdminUserViewModel userModel = new AdminUserViewModel
            {
                Id = user.Id,
                Email = user.Email,
                UserName = user.UserName,
                Roles = roles.ToList(),
                IsCurrentUser = user.Id == currentUserId
            };

            userModels.Add(userModel);
        }

        return View(userModels);
    }

    [HttpGet]
    public async Task<IActionResult> Promote(string id)
    {
        if (string.IsNullOrWhiteSpace(id))
        {
            return NotFound();
        }

        IdentityUser? user = await _userManager.FindByIdAsync(id);

        if (user == null)
        {
            return NotFound();
        }

        bool isAdmin = await _userManager.IsInRoleAsync(user, Administrator);

        if (isAdmin)
        {
            TempData["ErrorMessage"] = "Action denied. User is already an Administrator.";
            return RedirectToAction(nameof(Index));
        }

        AdminUserPromoteConfirmationViewModel model = new AdminUserPromoteConfirmationViewModel
        {
            Id = user.Id,
            Email = user.Email
        };

        return View(model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Promote(AdminUserPromoteConfirmationViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        IdentityUser? user = await _userManager.FindByIdAsync(model.Id);

        if (user == null)
        {
            return NotFound();
        }

        bool isAdmin = await _userManager.IsInRoleAsync(user, Administrator);

        if (isAdmin)
        {
            TempData["ErrorMessage"] = "Action denied. User is already an Administrator.";

            return RedirectToAction(nameof(Index));
        }

        IdentityResult result = await _userManager.AddToRoleAsync(user, Administrator);

        if (!result.Succeeded)
        {
            string errors = string.Join("; ", result.Errors.Select(e => e.Description));

            TempData["ErrorMessage"] = $"Action failed. Could not promote user, due to the following errors: {errors}";

            return RedirectToAction(nameof(Index));
        }

        TempData["SuccessMessage"] = $"Successfully promoted the user {user.Email} to Administrator!";

        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public async Task<IActionResult> Demote(string id)
    {
        if (string.IsNullOrWhiteSpace(id))
        {
            return NotFound();
        }

        IdentityUser? user = await _userManager.FindByIdAsync(id);

        if (user == null)
        {
            return NotFound();
        }

        bool isAdmin = await _userManager.IsInRoleAsync(user, Administrator);

        if (!isAdmin)
        {
            TempData["ErrorMessage"] = "Action denied. User is not an Administrator.";
            return RedirectToAction(nameof(Index));
        }

        AdminUserDemoteConfirmationViewModel model = new AdminUserDemoteConfirmationViewModel
        {
            Id = user.Id,
            Email = user.Email
        };

        return View(model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Demote(AdminUserDemoteConfirmationViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        IdentityUser? user = await _userManager.FindByIdAsync(model.Id);

        if (user == null)
        {
            return NotFound();
        }

        bool isAdmin = await _userManager.IsInRoleAsync(user, Administrator);

        if (!isAdmin)
        {
            TempData["ErrorMessage"] = "Action denied. User is not an Administrator.";
            return RedirectToAction(nameof(Index));
        }

        string? currentUserId = _userManager.GetUserId(User);

        if (user.Id == currentUserId)
        {
            TempData["ErrorMessage"] = "Action denied. You can't demote yourself!";
            return RedirectToAction(nameof(Index));
        }

        IList<IdentityUser> administrators = await _userManager.GetUsersInRoleAsync(Administrator);

        if (administrators.Count <= 1)
        {
            TempData["ErrorMessage"] = "Action denied. You cannot demote the only remaining Administrator.";
            return RedirectToAction(nameof(Index));
        }

        bool isRegularUser = await _userManager.IsInRoleAsync(user, DefaultUser);

        if (!isRegularUser)
        {
            IdentityResult addUserResult = await _userManager.AddToRoleAsync(user, DefaultUser);

            if (!addUserResult.Succeeded)
            {
                string errors = string.Join("; ",addUserResult.Errors.Select(e => e.Description));

                TempData["ErrorMessage"] = $"Action failed. Could not assign the User role, due to the following errors:: {errors}";

                return RedirectToAction(nameof(Index));
            }
        }

        IdentityResult result = await _userManager.RemoveFromRoleAsync(user, Administrator);

        if (!result.Succeeded)
        {
            string errors = string.Join("; ",result.Errors.Select(e => e.Description));

            TempData["ErrorMessage"] = $"Action failed. Could not demote user, due to the following errors: {errors}";

            return RedirectToAction(nameof(Index));
        }

        TempData["SuccessMessage"] = $"Successfully demoted {user.Email} to regular User!";

        return RedirectToAction(nameof(Index));
    }
}
