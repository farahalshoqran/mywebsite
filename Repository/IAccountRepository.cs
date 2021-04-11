using Diagnostic_Learning_Difficulties_Part2.Models;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace Diagnostic_Learning_Difficulties_Part2.Repository
{
    public interface IAccountRepository
    {
        public Task<IdentityResult> CreateUserAsync(SignupUserModel signupUserModel);
    }
}