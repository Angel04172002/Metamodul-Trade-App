using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace MetamodulTradeApp.Controllers
{
    public class UserController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly RoleManager<IdentityUser> roleManager;
      
        public UserController(UserManager<IdentityUser> _userManager ,RoleManager<IdentityUser> _roleManager)
        {
            userManager = _userManager;
            roleManager = _roleManager;
        }

        public async Task<IActionResult> AddUserToRole(string username, string rolename)
        {
            
            if(await roleManager.RoleExistsAsync(rolename))
            {
                var user = await userManager.FindByNameAsync(username);

                if(user != null)
                {
                    if(await userManager.IsInRoleAsync(user, rolename) == false)
                    {
                        await userManager.AddToRoleAsync(user, rolename);
                    }
                }
            }

            return RedirectToAction("Index", "Home");
        }

        public IActionResult CheckRole(string rolename) 
        {
            return Ok(User.IsInRole(rolename));
        }


        public string GetUserId()
        {
        }
    }
}
