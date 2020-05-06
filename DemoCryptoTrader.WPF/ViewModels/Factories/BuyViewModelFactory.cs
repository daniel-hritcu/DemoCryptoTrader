using System;
using System.Collections.Generic;
using System.Text;

namespace DemoCryptoTrader.WPF.ViewModels.Factories
{
    public class BuyViewModelFactory : IDemoCryptoTraderViewModelFactory<BuyViewModel>
    {
        public BuyViewModel CreateViewModel()
        {
            return new BuyViewModel();
        }
    }
}
