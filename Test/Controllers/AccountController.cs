using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Test.DTOs;
using Test.Reposatries.Account_Reposatory;

namespace Test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountRepository accountRepository;

        public AccountController(IAccountRepository accountRepository )
        {
            this.accountRepository = accountRepository;
        }



        //create account post new user "Registration" => Post
        [HttpPost("Register")]
        public async Task<IActionResult> Regisration( RegistartionDto user)
        {
            IdentityResult result =  await accountRepository.Registration(user);
            if (result.Succeeded)
            {
                return Ok(new { message = "User registered successfully" });
            }
            return BadRequest(result.Errors);
        }

        //check account valid "Login"   => Post

    }
}
