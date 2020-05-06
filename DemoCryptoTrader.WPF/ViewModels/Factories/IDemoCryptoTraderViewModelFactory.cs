using System;
using System.Collections.Generic;
using System.Text;

namespace DemoCryptoTrader.WPF.ViewModels.Factories
{
    public interface IDemoCryptoTraderViewModelFactory<T> where T : ViewModelBase
    {
        T CreateViewModel();
    }
}
