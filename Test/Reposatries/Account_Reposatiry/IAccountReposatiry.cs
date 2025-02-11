using Test.DTOs;

namespace Test.Reposatries.Account_Reposatiry
{
    public interface IAccountReposatiry
    {
        Task Registration(RegistartionDto user);
    }
}