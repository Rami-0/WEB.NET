using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using DAL.ViewModels;
using DAL.Models;

public class RolesController : Controller
{
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly UserManager<ApplicationUser> _userManager;

    public RolesController(RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager)
    {
        _roleManager = roleManager;
        _userManager = userManager;
    }

    // Implement your actions here (e.g., Index, Create, Edit, AssignUsers, etc.)
    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(RoleViewModel model)
    {
        if (ModelState.IsValid)
        {
            var role = new IdentityRole { Name = model.RoleName };
            var result = await _roleManager.CreateAsync(role);
            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }

        return View(model);
    }

    [HttpGet]
    public async Task<IActionResult> Edit(string id)
    {
        var role = await _roleManager.FindByIdAsync(id);
        if (role == null)
        {
            return NotFound();
        }

        var model = new RoleViewModel { RoleName = role.Name };
        return View(model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(RoleViewModel model)
    {
        if (ModelState.IsValid)
        {
            var role = await _roleManager.FindByNameAsync(model.RoleName);
            if (role != null)
            {
                role.Name = model.RoleName;
                var result = await _roleManager.UpdateAsync(role);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Role not found.");
            }
        }

        return View(model);
    }

    public IActionResult Index()
    {
        var roles = _roleManager.Roles.Select(r => r.Name).ToList();
        return View(roles);
    }

    [HttpGet]
    public async Task<IActionResult> AssignUsers(string roleName)
    {
        var role = await _roleManager.FindByNameAsync(roleName);
        if (role == null)
        {
            return NotFound();
        }

        var usersInRole = await _userManager.GetUsersInRoleAsync(roleName);
        var allUsers = _userManager.Users.Select(u => new SelectListItem { Text = u.UserName, Value = u.Id }).ToList();

        var model = new AssignUsersToRoleViewModel
        {
            RoleName = roleName,
            Users = allUsers,
            SelectedUsers = usersInRole.Select(u => u.Id).ToList()
        };

        return View(model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> AssignUsers(AssignUsersToRoleViewModel model)
    {
        if (ModelState.IsValid)
        {
            var role = await _roleManager.FindByNameAsync(model.RoleName);
            if (role != null)
            {
                var usersInRole = await _userManager.GetUsersInRoleAsync(model.RoleName);
                var usersToAdd = model.SelectedUsers.Except(usersInRole.Select(u => u.Id));
                var usersToRemove = usersInRole.Select(u => u.Id).Except(model.SelectedUsers);

                foreach (var userId in usersToAdd)
                {
                    var user = await _userManager.FindByIdAsync(userId);
                    if (user != null)
                    {
                        await _userManager.AddToRoleAsync(user, model.RoleName);
                    }
                }

                foreach (var userId in usersToRemove)
                {
                    var user = await _userManager.FindByIdAsync(userId);
                    if (user != null)
                    {
                        await _userManager.RemoveFromRoleAsync(user, model.RoleName);
                    }
                }

                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Role not found.");
            }
        }

        return View(model);
    }
}