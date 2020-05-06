using DemoCryptoTrader.WPF.Commands;
using DemoCryptoTrader.WPF.Models;
using DemoCryptoTrader.WPF.ViewModels;
using DemoCryptoTrader.WPF.ViewModels.Factories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;

namespace DemoCryptoTrader.WPF.States.Navigators
{
        public class Navigator : ObservableObject, INavigator
        {
            private ViewModelBase _currentViewModel;
            public ViewModelBase CurrentViewModel
            {
                get
                {
                    return _currentViewModel;
                }
                set
                {
                    _currentViewModel = value;
                    OnPropertyChanged(nameof(CurrentViewModel));
                }
            }

            public ICommand UpdateCurrentViewModelCommand { get; set; }

            public Navigator(IRootDemoCryptoTraderViewModelFactory viewModelFactory)
            {
                UpdateCurrentViewModelCommand = new UpdateCurrentViewModelCommand(this, viewModelFactory);
            }
        }
    }