using DemoCryptoTrader.WPF.States.Navigators;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoCryptoTrader.WPF.ViewModels.Factories
{
    public class RootDemoCryptoTraderFactory : IRootDemoCryptoTraderViewModelFactory
    {
        private readonly IDemoCryptoTraderViewModelFactory<HomeViewModel> _homeViewModelFactory;
        private readonly IDemoCryptoTraderViewModelFactory<PortfolioViewModel> _portfolioViewModelFactory;
        private readonly IDemoCryptoTraderViewModelFactory<BuyViewModel> _buyViewModelFactory;
        private readonly IDemoCryptoTraderViewModelFactory<SellViewModel> _sellViewModelFactory;
        private readonly IDemoCryptoTraderViewModelFactory<AuthViewModel> _authViewModelFactory;

        public RootDemoCryptoTraderFactory(IDemoCryptoTraderViewModelFactory<HomeViewModel> homeViewModelFactory, IDemoCryptoTraderViewModelFactory<PortfolioViewModel> portfolioViewModelFactory, IDemoCryptoTraderViewModelFactory<BuyViewModel> buyViewModelFactory, IDemoCryptoTraderViewModelFactory<SellViewModel> sellViewModelFactory, IDemoCryptoTraderViewModelFactory<AuthViewModel> authViewModelFactory)
        {
            _homeViewModelFactory = homeViewModelFactory;
            _portfolioViewModelFactory = portfolioViewModelFactory;
            _buyViewModelFactory = buyViewModelFactory;
            _sellViewModelFactory = sellViewModelFactory;
            _authViewModelFactory = authViewModelFactory;
        }

        public ViewModelBase CreateViewModel(ViewType viewType)
        {
            switch (viewType)
            {
                case ViewType.Login:
                    return _authViewModelFactory.CreateViewModel();
                case ViewType.Home:
                    return _homeViewModelFactory.CreateViewModel();
                case ViewType.Portfolio:
                    return _portfolioViewModelFactory.CreateViewModel();
                case ViewType.Buy:
                    return _buyViewModelFactory.CreateViewModel();
                case ViewType.Sell:
                    return _sellViewModelFactory.CreateViewModel();
                default:
                    throw new ArgumentException("ViewType without ViewModel", "viewType");
            }
        }
    }
}
