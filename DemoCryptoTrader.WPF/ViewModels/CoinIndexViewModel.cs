using DemoCryptoTrader.Domain.Models;
using DemoCryptoTrader.Domain.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DemoCryptoTrader.WPF.ViewModels
{
    public class CoinIndexViewModel
    {
        private readonly ICoinIndexService _coinIndexService;

        public CoinIndex Bitcoin { get; set; }
        public CoinIndex Ethereum { get; set; }
        public CoinIndex Litecoin { get; set; }

        public CoinIndexViewModel(ICoinIndexService coinIndexService)
        {
            _coinIndexService = coinIndexService;
        }

        public static CoinIndexViewModel LoadCoinIndexViewModel(ICoinIndexService coinIndexService)
        {
            CoinIndexViewModel coinIndexViewModel = new CoinIndexViewModel(coinIndexService);

            /*
             * We don't want to await the LoadCoinIndex. If we wait for it, it will trigger a chain
             * of waits in our viewModel locking the UI;
             */
            coinIndexViewModel.LoadCoinIndex();

            return coinIndexViewModel;
        }

        private void LoadCoinIndex()
        {
            //Bitcoin
            _coinIndexService.GetCoinIndex(CoinIndexId.Bitcoin).ContinueWith(task =>
            {
                if (task.Exception == null) 
                {
                    Bitcoin = task.Result;
                }
            });

            //Ethereum
            _coinIndexService.GetCoinIndex(CoinIndexId.Bitcoin).ContinueWith(task =>
            {
                if (task.Exception == null)
                {
                    Ethereum = task.Result;
                }
            });

            //Litecoin
            _coinIndexService.GetCoinIndex(CoinIndexId.Bitcoin).ContinueWith(task =>
            {
                if (task.Exception == null)
                {
                    Litecoin = task.Result;
                }
            });
        }
    }
}
