using DemoCryptoTrader.CoinGekoAPI.Services;
using DemoCryptoTrader.EntityFramework.Services;
using DemoCryptoTrader.Domain.Models;
using DemoCryptoTrader.Domain.Services;
using DemoCryptoTrader.Domain.Services.TransactionServices;
using DemoCryptoTrader.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace DemoCryptoTrader.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        protected override async void OnStartup(StartupEventArgs e)
        {
            IBasicDataService<Account> accountService = new AccountDataService(new EntityFramework.DemoCryptoTraderDbContextFactory());
            ICoinIndexService coinIndexService = new CoinIndexService();
            IBuyCoinService buyCoinService = new BuyCoinService(coinIndexService, accountService);

            Account buyer = await accountService.Get(1);

            await buyCoinService.BuyCoin(buyer, "bitcoin", 0.1);

            Window window = new MainWindow();
            window.DataContext = new MainViewModel();
            window.Show();

            base.OnStartup(e);
        }
    }
}
