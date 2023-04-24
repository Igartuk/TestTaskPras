using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTaskPrasDAL.Models.Entities;

namespace TestTaskPrasDAL.Repositories
{
    public class AdminCreator
    {
        RoleManager<IdentityRole> _roleManager;
        UserManager<User> _userManager;
        public AdminCreator(RoleManager<IdentityRole> roleManager, UserManager<User> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }
        public async Task CreateAdminWithRole(IServiceProvider serviceProvider)
        {
            var roleExist = await _roleManager.RoleExistsAsync("Admin");
            var userExist = await _userManager.FindByEmailAsync("admin@gmail.com");
            if(!roleExist || userExist == null)
            {
                if (!roleExist)
                {
                    var role = new IdentityRole();
                    role.Name = "Admin";
                    await _roleManager.CreateAsync(role);
                }
                if (userExist == null)
                {
                    var user = new User();
                    user.UserName = "admin@gmail.com";
                    user.Email = "admin@gmail.com";
                    string userPassword = "1234";
                    IdentityResult checkUser = await _userManager.CreateAsync(user, userPassword);
                    if (checkUser.Succeeded)
                    {
                        var result = await _userManager.AddToRoleAsync(user, "Admin");
                    }
                }
            }
        }
    }
}
