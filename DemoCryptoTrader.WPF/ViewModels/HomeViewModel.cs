using System;
using System.Collections.Generic;
using System.Text;

namespace DemoCryptoTrader.WPF.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {
        public TopCoinViewModel TopCoinViewModel { get; set; }

        public HomeViewModel(TopCoinViewModel topcoinViewModel)
        {
            TopCoinViewModel = topcoinViewModel;
        }
    }
}
