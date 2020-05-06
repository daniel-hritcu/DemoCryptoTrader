using System;
using System.Collections.Generic;
using System.Text;

namespace DemoCryptoTrader.WPF.ViewModels.Factories
{
    public class SellViewModelFactory : IDemoCryptoTraderViewModelFactory<SellViewModel>
    {
        public SellViewModel CreateViewModel()
        {
            return new SellViewModel();
        }
    }
}
