using MarketPlace.Models.UsersModels;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarketPlace.Services.Extentions
{
    public static class SingInManagerExtentions
    {
        public static string GetCurrent(this SignInManager<UserModel> manager)
        {
            const string key = "user";
            string value;
            var res = manager.Context.Request.Cookies.TryGetValue(key, out value);
            if (res)
            {
                return value;
            }
            return "";
        }
        public static async Task<UserViewModel> GetViewUser(this UserManager<UserModel> manager, string id)
        {
            var user = await manager.FindByIdAsync(id);
            if (user is null)
            {
                return null;
            }
            UserViewModel userView = new UserViewModel();
            userView.Email = user.Email;
            userView.Name = user.UserName;
            return userView;
        }
    }
}
