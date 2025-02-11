using Microsoft.AspNetCore.Identity;
using Test.DTOs;

namespace Test.Reposatries.Account_Reposatory
{
    public interface IAccountRepository
    {
        Task<IdentityResult> Registration(RegistartionDto user);
    }
}