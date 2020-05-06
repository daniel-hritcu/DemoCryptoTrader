using System;
using System.Collections.Generic;
using System.Text;

namespace DemoCryptoTrader.WPF.ViewModels.Factories
{
    public class AuthViewModelFactory : IDemoCryptoTraderViewModelFactory<AuthViewModel>
    {
        public AuthViewModel CreateViewModel()
        {
            return new AuthViewModel();
        }
    }
}
