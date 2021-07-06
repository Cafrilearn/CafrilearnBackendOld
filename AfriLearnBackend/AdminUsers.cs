using AfriLearnBackend.Constants;
using AfriLearnBackend.Models;
using System.Collections.Generic;

namespace AfriLearnBackend
{
    public static class AdminUsers
    {
        public static List<AppUser> Admins = new List<AppUser>()
        {
            // This is the default Admin
            new AppUser()
            {
                PasswordHash = "African2288.",
                UserName = "Humphryshikunzi",
                Email = "humphry.shikunzi@outlook.com",
                Role = Roles.Admin
            }
        };

    }
}
