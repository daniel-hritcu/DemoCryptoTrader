using DemoCryptoTrader.WPF.States.Navigators;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoCryptoTrader.WPF.ViewModels.Factories
{
    public interface IRootDemoCryptoTraderViewModelFactory
    {
        ViewModelBase CreateViewModel(ViewType viewType);
    }
}
