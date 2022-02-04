using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace MarketPlace.Models.UsersModels
{
    public class UserModel : IdentityUser
    {
        public override string Id { get => base.Id; set => base.Id = value; }
        public int GetHash(string password)
        {
            return password.GetHashCode();
        }
    }
}
