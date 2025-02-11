using Microsoft.AspNetCore.Identity;
using Test.DTOs;
using Test.Models;

namespace Test.Reposatries.Account_Reposatiry
{
    public class AccountReposatiry : IAccountReposatiry
    {
        private readonly MyContext context;
        private readonly UserManager<ApplicationUser> usermanager;

        public AccountReposatiry(MyContext context, UserManager<ApplicationUser> usermanager)
        {
            this.context = context;
            this.usermanager = usermanager;
        }

        public async Task Registration(RegistartionDto user)
        {
            ApplicationUser applicationUser = new ApplicationUser();
            applicationUser.UserName = user.UserName;
            applicationUser.Email = user.Email;
            usermanager.CreateAsync(applicationUser, user.Password);

        }
    }
}
