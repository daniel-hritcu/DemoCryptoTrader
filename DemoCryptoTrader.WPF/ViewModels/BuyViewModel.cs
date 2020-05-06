using DemoCryptoTrader.Domain.Services;
using DemoCryptoTrader.Domain.Services.TransactionServices;
using DemoCryptoTrader.WPF.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace DemoCryptoTrader.WPF.ViewModels
{
    public class BuyViewModel : ViewModelBase
    {
		private string _coinId;
		public string CoinId
		{
			get
			{
				return _coinId;
			}
			set
			{
				_coinId = value;
				OnPropertyChanged(nameof(CoinId));
			}
		}

		private string _searchResultId = string.Empty;
		public string SearchResultId
		{
			get
			{
				return _searchResultId;
			}
			set
			{
				_searchResultId = value;
				OnPropertyChanged(nameof(SearchResultId));
			}
		}

		private double _coinPrice;
		public double CoinPrice
		{
			get
			{
				return _coinPrice;
			}
			set
			{
				_coinPrice = value;
				OnPropertyChanged(nameof(CoinPrice));
				OnPropertyChanged(nameof(TotalPrice));
			}
		}

		private double _ammountToBuy;
		public double AmmountToBuy
		{
			get
			{
				return _ammountToBuy;
			}
			set
			{
				_ammountToBuy = value;
				OnPropertyChanged(nameof(AmmountToBuy));
				OnPropertyChanged(nameof(TotalPrice));
			}
		}

		public double TotalPrice
		{
			get
			{
				return AmmountToBuy * CoinPrice;
			}
		}

		public ICommand SearchCoinCommand { get; set; }
		public ICommand BuyCoinCommand { get; set; }

		public BuyViewModel(ICoinIndexService coinIndexService, IBuyCoinService buyCoinService)
		{
			SearchCoinCommand = new SearchCoinCommand(this, coinIndexService);
			BuyCoinCommand = new BuyCoinCommand(this, buyCoinService);
		}
	}
}
