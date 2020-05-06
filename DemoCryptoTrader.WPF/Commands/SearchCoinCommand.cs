using DemoCryptoTrader.Domain.Services;
using DemoCryptoTrader.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace DemoCryptoTrader.WPF.Commands
{
    class SearchCoinCommand : ICommand
    {
        private BuyViewModel _viewModel;
        private ICoinIndexService _coinIndexService;

        public SearchCoinCommand(BuyViewModel viewModel, ICoinIndexService coinIndexService)
        {
            _viewModel = viewModel;
            _coinIndexService = coinIndexService;
        }

        public event EventHandler CanExecuteChanged;


        public bool CanExecute(object parameter)
        {
            return true;
        }

        public async void Execute(object parameter)
        {
            try
            {
                double coinPrice = await _coinIndexService.GetCoinPrice(_viewModel.CoinId);
                _viewModel.SearchResultId = _viewModel.CoinId.ToUpper();
                _viewModel.CoinPrice = coinPrice;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
    }
}
