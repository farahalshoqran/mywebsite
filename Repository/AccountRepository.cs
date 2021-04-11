using Diagnostic_Learning_Difficulties_Part2.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Diagnostic_Learning_Difficulties_Part2.Repository
{
    public class AccountRepository : IAccountRepository
    {
       
        private readonly UserManager<IdentityUser> userManager;

        public AccountRepository(UserManager<IdentityUser> userManager)
        {
            this.userManager = userManager;
        }
        public async Task<IdentityResult> CreateUserAsync(SignupUserModel signupUserModel)
        {
            var user = new IdentityUser()
            {
                Email = signupUserModel.Email
            };
           var result = await userManager.CreateAsync(user, signupUserModel.Password);
            return result;
        }
    }
}
