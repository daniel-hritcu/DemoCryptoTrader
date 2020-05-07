using DemoCryptoTrader.WPF.Commands;
using DemoCryptoTrader.WPF.States.Authenticators;
using DemoCryptoTrader.WPF.States.Navigators;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace DemoCryptoTrader.WPF.ViewModels
{
    public class AuthViewModel : ViewModelBase
    {
		private string _username;
		public string Username
		{
			get
			{
				return _username;
			}
			set
			{
				_username = value;
				OnPropertyChanged(nameof(Username));
			}
		}

		public ICommand LoginCommand { get; }

		public AuthViewModel(IAuthenticator authenticator)
		{
			LoginCommand = new LoginCommand(this, authenticator);
		}
	}
}
