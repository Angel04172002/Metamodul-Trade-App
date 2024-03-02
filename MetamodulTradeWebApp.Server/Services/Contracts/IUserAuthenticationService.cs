using MetamodulTradeWebApp.Server.Models;
using Microsoft.AspNetCore.Identity;

namespace MetamodulTradeWebApp.Server.Services.Contracts
{
    public interface IUserAuthenticationService
    {
        Task<IdentityResult> RegisterUserAsync(UserRegistrationViewModel user);

        Task<SignInResult> SignInUserAsync(UserLoginViewModel user);

        Task SignOutUserAsync();
    }
}
