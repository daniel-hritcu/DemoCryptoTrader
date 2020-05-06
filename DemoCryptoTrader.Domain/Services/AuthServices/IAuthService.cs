using DemoCryptoTrader.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DemoCryptoTrader.Domain.Services.AuthServices
{
    public enum RegistrationResult
    {
        Success,
        PasswordsDoNotMatch,
        EmailAlreadyExists,
        UsernameAlreadyExists
    }

    public interface IAuthService
    {
            Task<RegistrationResult> Register(string email, string username, string password, string confirmPassword);
            Task<Account> Login(string username, string password);
    }
}
