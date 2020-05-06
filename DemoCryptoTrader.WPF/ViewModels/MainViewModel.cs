﻿using DemoCryptoTrader.WPF.States.Navigators;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoCryptoTrader.WPF.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public INavigator Navigator { get; set; } = new Navigator();

        public MainViewModel()
        {
            Navigator.UpdateCurrentViewModelCommand.Execute(ViewType.Home);
        }
    }
}
