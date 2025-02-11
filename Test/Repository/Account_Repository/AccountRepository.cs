using Microsoft.AspNetCore.Identity;
using Test.DTOs;
using Test.Models;

namespace Test.Reposatries.Account_Reposatory
{
    public class AccountRepository : IAccountRepository
    {
        private readonly MyContext context;
        private readonly UserManager<ApplicationUser> usermanager;

        public AccountRepository(MyContext context, UserManager<ApplicationUser> usermanager)
        {
            this.context = context;
            this.usermanager = usermanager;
        }

        public async Task<IdentityResult> Registration(RegistartionDto user)
        {
            ApplicationUser applicationUser = new ApplicationUser { UserName = user.UserName, Email = user.Email };

            return await usermanager.CreateAsync(applicationUser, user.Password);

        }
    }
}
