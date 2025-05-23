using Cafe.BL.ViewModels;
using Cafe.DAL.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe.BL.Services;

public class AccountService
{
    private readonly UserManager<AppUser> _userManager;

    public AccountService(UserManager<AppUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task<string> Register(RegisterAccountVM vM)
    {
        AppUser user = new AppUser();
        user.UserName = vM.UserName;
        user.Email = vM.Email;

        IdentityResult result = await _userManager.CreateAsync(user,vM.Password);
        if (!result.Succeeded)
        {
            string msg = string.Empty;
            foreach (var message in result.Errors)
            {
                msg = msg + message + "\n";
                return msg;
            }
        }
            return "OK";
    }

  








}
