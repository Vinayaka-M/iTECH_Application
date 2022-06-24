using iTECH_Application.Models;
using iTECH_Application.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace iTECH_Application.Controllers
{
    public class AccountController : Controller
    {
       
        private readonly IAccountRepository _accountRepository;
      
        public AccountController(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }
        
        [Route("signup")]
        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }
       
        [Route("signup")]
        [HttpPost]
        public async Task<IActionResult> SignUp(SignUpUserModel userModel)
        {
            if(ModelState.IsValid)
            {
                var result =await _accountRepository.CreateUserAsync(userModel);

                if (result.Succeeded)
                {
                    return RedirectToAction("SignUp", "Account");
                }
              //  if (!result.Succeeded)
              else
                {
                    
                    foreach (var errorMessage in result.Errors)
                    {
                        ModelState.AddModelError("", errorMessage.Description);
                    }
                }
               
                ModelState.Clear();
                return View();
            }
            return View(userModel);
        }
       
        [Route("login")]
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [Route("login")]
        [HttpPost]
        public async Task<IActionResult> Login(LoginModel loginmodel)
        {
            if(ModelState.IsValid)
            {
               var result=await _accountRepository.PasswordSignInAsync(loginmodel);
                
                if(result.Succeeded)
                {
                   return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "Invalid Credentials");
            }
            return View(loginmodel);
        }
        [Route("logout")]
        public async Task<IActionResult> Logout()
        {
            await _accountRepository.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
