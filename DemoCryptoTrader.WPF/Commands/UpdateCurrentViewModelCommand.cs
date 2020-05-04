using DemoCryptoTrader.CoinGekoAPI.Services;
using DemoCryptoTrader.WPF.States.Navigators;
using DemoCryptoTrader.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace DemoCryptoTrader.WPF.Commands
{
    public class UpdateCurrentViewModelCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private INavigator _navigator;

        public UpdateCurrentViewModelCommand(INavigator navigator)
        {
            _navigator = navigator;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (parameter is ViewType)
            {
                ViewType viewType = (ViewType)parameter;
                switch (viewType)
                {
                    case ViewType.Login:
                        _navigator.CurrentViewModel = new AuthViewModel();
                        break;
                    case ViewType.Home:
                        _navigator.CurrentViewModel = new HomeViewModel(CoinIndexViewModel.LoadCoinIndexViewModel(new CoinIndexService()));
                        break;
                    case ViewType.Portfolio:
                        _navigator.CurrentViewModel = new PortfolioViewModel();
                        break;
                    case ViewType.Buy:
                        _navigator.CurrentViewModel = new BuyViewModel();
                        break;
                    case ViewType.Sell:
                        _navigator.CurrentViewModel = new SellViewModel();
                        break;
                    default:
                        break;
                }
            }
        }
    }
}