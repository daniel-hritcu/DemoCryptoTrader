using DemoCryptoTrader.WPF.States.Authenticators;
using DemoCryptoTrader.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;
using System.Windows.Input;

namespace DemoCryptoTrader.WPF.Commands
{
    public class LoginCommand : ICommand
    {
        private readonly AuthViewModel _authViewModel;
        private readonly IAuthenticator _authenticator;

        public LoginCommand(AuthViewModel authViewModel, IAuthenticator authenticator)
        {
            _authViewModel = authViewModel;
            _authenticator = authenticator;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public async void Execute(object parameter)
        {
            PasswordBox pb = parameter as PasswordBox;
            bool success = await _authenticator.Login(_authViewModel.Username, pb.Password);
        }
    }
}
