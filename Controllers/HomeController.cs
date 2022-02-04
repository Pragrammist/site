using MarketPlace.Models;
using MarketPlace.Models.UsersModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using MarketPlace.Services.Extentions;

namespace MarketPlace.Controllers
{
    public class HomeController : Controller
    {
        UserManager<UserModel> _uM; 
        RoleManager<UserRole> _rM; 
        SignInManager<UserModel> _sM;
        public HomeController(UserManager<UserModel> uM, RoleManager<UserRole> rM, SignInManager<UserModel> sM)
        {
            _uM = uM;
            _rM = rM;
            _sM = sM;
        }

        public async Task<IActionResult> Index()
        {
            
            
            return View();
        }

        public IActionResult Privacy()
        {
            

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
