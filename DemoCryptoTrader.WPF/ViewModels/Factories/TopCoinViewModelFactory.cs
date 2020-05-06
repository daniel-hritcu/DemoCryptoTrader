using DemoCryptoTrader.Domain.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoCryptoTrader.WPF.ViewModels.Factories
{
    public class TopCoinViewModelFactory : IDemoCryptoTraderViewModelFactory<TopCoinViewModel>
    {
        private readonly ICoinIndexService _coinIndexService;

        public TopCoinViewModelFactory(ICoinIndexService coinIndexService)
        {
            _coinIndexService = coinIndexService;
        }

        public TopCoinViewModel CreateViewModel()
        {
            return TopCoinViewModel.LoadCoinIndexViewModel(_coinIndexService);
        }
    }
}
