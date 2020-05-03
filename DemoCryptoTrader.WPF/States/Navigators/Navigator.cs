using DemoCryptoTrader.WPF.Commands;
using DemoCryptoTrader.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace DemoCryptoTrader.WPF.States.Navigators
{
    public class Navigator : INavigator
    {
        /* I don't like the command beeing in the Navigator Object,
        * but since the command is in it's own class, there should 
        * not be a big problem.
        */

        public ViewModelBase CurrentViewModel { get; set; }
        public ICommand UodateCurrentViewModelCommand => new UpdateCurrentViewModelCommand(this);
    }
}