using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using Test.DTOs;
using Test.Reposatries.Account_Reposatiry;

namespace Test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountReposatiry accountReposatiry;

        public AccountController(IAccountReposatiry accountReposatiry )
        {
            this.accountReposatiry = accountReposatiry;
        }
        //create account post new user "Registration" => Post
        [HttpPost("Register")]
        public async Task Regisration( RegistartionDto user)
        {
            await accountReposatiry.Registration(user);
        }

        //check account valid "Login"   => Post

    }
}
