using System;
using System.Collections.Generic;
using System.Text;

namespace DemoCryptoTrader.WPF.ViewModels
{
    class HomeViewModel : ViewModelBase
    {
        public CoinIndexViewModel CoinIndexViewModel { get; set; }

        public HomeViewModel(CoinIndexViewModel coinIndexViewModel)
        {
            CoinIndexViewModel = coinIndexViewModel;
        }
    }
}
