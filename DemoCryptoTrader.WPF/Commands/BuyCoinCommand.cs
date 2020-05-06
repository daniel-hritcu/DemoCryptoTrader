using DemoCryptoTrader.Domain.Models;
using DemoCryptoTrader.Domain.Services.TransactionServices;
using DemoCryptoTrader.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace DemoCryptoTrader.WPF.Commands
{
    class BuyCoinCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private BuyViewModel _buyViewModel;
        private IBuyCoinService _buyStockService;

        public BuyCoinCommand(BuyViewModel buyViewModel, IBuyCoinService buyStockService)
        {
            _buyViewModel = buyViewModel;
            _buyStockService = buyStockService;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public async void Execute(object parameter)
        {
            try
            {
                Account account = await _buyStockService.BuyCoin(new Account()
                {
                    Id = 1,
                    Balance = 5000,
                    CoinTransactions = new List<CoinTransaction>()
                }, _buyViewModel.CoinId, _buyViewModel.AmmountToBuy);

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
    }
}
