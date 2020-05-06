using DemoCryptoTrader.WPF.States.Authenticators;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoCryptoTrader.WPF.ViewModels.Factories
{
    public class AuthViewModelFactory : IDemoCryptoTraderViewModelFactory<AuthViewModel>
    {
        private readonly IAuthenticator _authenticator;

        public AuthViewModelFactory(IAuthenticator authenticator)
        {
            _authenticator = authenticator;
        }

        public AuthViewModel CreateViewModel()
        {
            return new AuthViewModel(_authenticator);
        }
    }
}

