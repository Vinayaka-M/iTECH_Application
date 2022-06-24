using iTECH_Application.Models;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace iTECH_Application.Repository
{
    public interface IAccountRepository
    {
        Task<IdentityResult> CreateUserAsync(SignUpUserModel userModel);
        Task<SignInResult> PasswordSignInAsync(LoginModel loginModel);

        Task SignOutAsync();
        //Task FindByEmailAsync(SignUpUserModel email);
       

    }
}