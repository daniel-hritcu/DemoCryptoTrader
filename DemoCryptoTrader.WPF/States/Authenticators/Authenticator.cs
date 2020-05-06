using DemoCryptoTrader.Domain.Models;
using DemoCryptoTrader.Domain.Services.AuthServices;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DemoCryptoTrader.WPF.States.Authenticators
{
    public class Authenticator : IAuthenticator
    {
        private readonly IAuthService _authService;

        public Authenticator(IAuthService authService)
        {
            _authService = authService;
        }
        public Account CurrentAccount { get; private set; }

        public bool IsLoggedIn => CurrentAccount != null;

        public async Task<bool> Login(string username, string password)
        {
            bool success = true;

            try
            {
                CurrentAccount = await _authService.Login(username, password);
            }
            catch (Exception)
            {
                success = false;
            }

            return success;
        }

        public void Logout()
        {
            CurrentAccount = null;
        }

        public async Task<RegistrationResult> Register(string email, string username, string password, string confirmPassword)
        {
            return await _authService.Register(email, username, password, confirmPassword);
        }
    }
}
