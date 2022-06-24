﻿using iTECH_Application.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace iTECH_Application.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountRepository(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public async Task<IdentityResult> CreateUserAsync(SignUpUserModel userModel)
        {
            var user = new ApplicationUser()
            {
                FirstName=userModel.FirstName,
                LastName=userModel.LastName,
                Email = userModel.Email,
                UserName = userModel.Email
            };
          var result=await _userManager.CreateAsync(user, userModel.Password);
            return result;
        }
        public async Task<SignInResult> PasswordSignInAsync(LoginModel loginModel)
        {
           var result= await _signInManager.PasswordSignInAsync(loginModel.Email, loginModel.Password, loginModel.RememberMe, false);
            return result;
        }

        public async Task SignOutAsync()
        {
            await _signInManager.SignOutAsync();
        }
       
        //public async Task IsEmailInUse(SignUpUserModel email)
        //{
        //    await _userManager.FindByEmailAsync(email.Email);
        //}
    }
}
