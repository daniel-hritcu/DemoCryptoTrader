using DemoCryptoTrader.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace DemoCryptoTrader.WPF.States.Navigators
{
    //Available Views
    public enum ViewType
    {
        Login,
        Home,
        Portfolio,
        Buy,
        Sell
    }
    public interface INavigator
    {
        ViewModelBase CurrentViewModel { get; set; }
        ICommand UodateCurrentViewModelCommand { get; }
    }
}
