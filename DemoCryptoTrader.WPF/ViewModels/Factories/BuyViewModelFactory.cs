using DemoCryptoTrader.Domain.Services;
using DemoCryptoTrader.Domain.Services.TransactionServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoCryptoTrader.WPF.ViewModels.Factories
{
    public class BuyViewModelFactory : IDemoCryptoTraderViewModelFactory<BuyViewModel>
    {
        private ICoinIndexService _coinIndexService;
        private IBuyCoinService _buyCoinService;

        public BuyViewModelFactory(ICoinIndexService coinIndexService, IBuyCoinService buyCoinService)
        {
            _coinIndexService = coinIndexService;
            _buyCoinService = buyCoinService;
        }

        public BuyViewModel CreateViewModel()
        {
            return new BuyViewModel(_coinIndexService, _buyCoinService) ;
        }
    }
}
