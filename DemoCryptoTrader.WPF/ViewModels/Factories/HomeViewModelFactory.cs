using System;
using System.Collections.Generic;
using System.Text;

namespace DemoCryptoTrader.WPF.ViewModels.Factories
{
    public class HomeViewModelFactory : IDemoCryptoTraderViewModelFactory<HomeViewModel>
    {
        private IDemoCryptoTraderViewModelFactory<TopCoinViewModel> _topCoinViewModelFactory;

        public HomeViewModelFactory(IDemoCryptoTraderViewModelFactory<TopCoinViewModel> topCoinViewModelFactory)
        {
            _topCoinViewModelFactory = topCoinViewModelFactory;
        }

        public HomeViewModel CreateViewModel()
        {
            return new HomeViewModel(_topCoinViewModelFactory.CreateViewModel());
        }
    }
}
