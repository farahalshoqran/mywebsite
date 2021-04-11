using Diagnostic_Learning_Difficulties_Part2.Models;
using Diagnostic_Learning_Difficulties_Part2.Repository;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Diagnostic_Learning_Difficulties_Part2.Controllers
{
    public class AccountController : Controller
    {
        private List<SignupUserModel> Users;
        private readonly IAccountRepository account;
        private readonly ILogger<AccountController> _logger;
        IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "oPeefs2jwxKPz1CiU4i9y9UXXz19oA7vAhFCtkHS",
            BasePath = "https://unitygamefirebase-default-rtdb.firebaseio.com/"
        };
        IFirebaseClient client;
        public AccountController(ILogger<AccountController> logger,IAccountRepository account)
        {
            _logger = logger;
            this.account = account;
        }
        [Route("Signup")]
        public IActionResult SignUp()
        {
            return View();
        }
       
      
        [Route("Signup")]
        [AcceptVerbs("get","post")]
        public async Task<IActionResult>  SignUp(SignupUserModel signupUserModel)
        {
            try { 
            AddUsertodatabase(signupUserModel);
                if (ModelState.IsValid)
                {
                    Users.Add(signupUserModel);
                    var result = await account.CreateUserAsync(signupUserModel);
                    if (!result.Succeeded)
                    {
                        foreach (var errormessage in result.Errors)
                        {
                            ModelState.AddModelError("", errormessage.Description);
                        }
                    }
                    ModelState.Clear();
                    return RedirectToAction("Signup", new { Email = signupUserModel.Email });
                }
                ModelState.AddModelError(string.Empty, "Added succ");
            }
            catch(Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }
            return View();
        }
        private void AddUsertodatabase(SignupUserModel registeruserinfo)
        {
            client = new FireSharp.FirebaseClient(config);
            var data = registeruserinfo;
            PushResponse pushResponse = client.Push("User", data);

            data.Email = pushResponse.Result.name;
            SetResponse setResponse = client.Set("User" + data.Email, data);
        }
    }
}
