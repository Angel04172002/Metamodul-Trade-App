using MetamodulTradeWebApp.Server.Models;
using MetamodulTradeWebApp.Server.Services.Contracts;
using Microsoft.AspNetCore.Identity;

namespace MetamodulTradeWebApp.Server.Services
{
    public class UserAuthenticationService : IUserAuthenticationService
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;

        public UserAuthenticationService(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        public async Task<IdentityResult> RegisterUserAsync(UserRegistrationViewModel user)
        {
            var identityUser = new IdentityUser()
            {
                Id = user.Id,
                Email = user.Email,
                PasswordHash = user.Password
            };

            var result = await userManager.CreateAsync(identityUser, user.Password);

            return result;
        }

        public async Task<SignInResult> SignInUserAsync(UserLoginViewModel user)
        {
            var identityUser = new IdentityUser()
            {
                Email = user.Email,
                PasswordHash = user.Password    
            };

           var result = await signInManager.PasswordSignInAsync(identityUser, user.Password, true, lockoutOnFailure: false);

           return result;
        }

        public async Task SignOutUserAsync()
        {
            await signInManager.SignOutAsync();
        }
    }
}
