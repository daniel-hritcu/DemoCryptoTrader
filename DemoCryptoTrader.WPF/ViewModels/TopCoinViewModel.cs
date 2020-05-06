using DemoCryptoTrader.Domain.Models;
using DemoCryptoTrader.Domain.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DemoCryptoTrader.WPF.ViewModels
{
    public class TopCoinViewModel : ViewModelBase
    {
        private readonly ICoinIndexService _coinIndexService;

        private CoinIndex _bitcoin;
        public CoinIndex Bitcoin
        {
            get
            {
                return _bitcoin;
            }
            set
            {
                _bitcoin = value;
                OnPropertyChanged(nameof(Bitcoin));
            }
        }

        private CoinIndex _ethereum;
        public CoinIndex Ethereum
        {
            get
            {
                return _ethereum;
            }
            set
            {
                _ethereum = value;
                OnPropertyChanged(nameof(Ethereum));
            }
        }

        private CoinIndex _litecoin;
        public CoinIndex Litecoin
        {
            get
            {
                return _litecoin;
            }
            set
            {
                _litecoin = value;
                OnPropertyChanged(nameof(Litecoin));
            }
        }

        public TopCoinViewModel(ICoinIndexService coinIndexService)
        {
            _coinIndexService = coinIndexService;
        }

        public static TopCoinViewModel LoadCoinIndexViewModel(ICoinIndexService coinIndexService)
        {
            TopCoinViewModel coinIndexViewModel = new TopCoinViewModel(coinIndexService);

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
            _coinIndexService.GetCoinIndex(CoinIndexId.Ethereum).ContinueWith(task =>
            {
                if (task.Exception == null)
                {
                    Ethereum = task.Result;
                }
            });

            //Litecoin
            _coinIndexService.GetCoinIndex(CoinIndexId.Litecoin).ContinueWith(task =>
            {
                if (task.Exception == null)
                {
                    Litecoin = task.Result;
                }
            });
        }
    }
}
