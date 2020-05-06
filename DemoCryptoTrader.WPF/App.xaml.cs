using DemoCryptoTrader.CoinGekoAPI.Services;
using DemoCryptoTrader.EntityFramework.Services;
using DemoCryptoTrader.Domain.Models;
using DemoCryptoTrader.Domain.Services;
using DemoCryptoTrader.Domain.Services.TransactionServices;
using DemoCryptoTrader.WPF.ViewModels;
using System;
using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using DemoCryptoTrader.EntityFramework;
using DemoCryptoTrader.WPF.States.Navigators;
using DemoCryptoTrader.WPF.ViewModels.Factories;

namespace DemoCryptoTrader.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            IServiceProvider serviceProvider = CreateServiceProvider();

            Window window = serviceProvider.GetRequiredService<MainWindow>();
            window.Show();

            base.OnStartup(e);
        }

        //Dependency Injection
        private IServiceProvider CreateServiceProvider()
        {
            IServiceCollection services = new ServiceCollection();
            
            //Singleton - one instance per app
            services.AddSingleton<DemoCryptoTraderDbContextFactory>();
            services.AddSingleton<ICoinIndexService, CoinIndexService>();
            services.AddSingleton<IBasicDataService<Account>, AccountDataService>();
            services.AddSingleton<IBuyCoinService, BuyCoinService>();
            services.AddSingleton<ISellCoinService, SellCoinService>();

            //ViewModels
            services.AddSingleton<IRootDemoCryptoTraderViewModelFactory, RootDemoCryptoTraderFactory>();
            services.AddSingleton<IDemoCryptoTraderViewModelFactory<TopCoinViewModel>, TopCoinViewModelFactory>();
            services.AddSingleton<IDemoCryptoTraderViewModelFactory<HomeViewModel>, HomeViewModelFactory>();
            services.AddSingleton<IDemoCryptoTraderViewModelFactory<PortfolioViewModel>, PortfolioViewModelFactory>();
            services.AddSingleton<IDemoCryptoTraderViewModelFactory<BuyViewModel>, BuyViewModelFactory>();
            services.AddSingleton<IDemoCryptoTraderViewModelFactory<SellViewModel>, SellViewModelFactory>();
            services.AddSingleton<IDemoCryptoTraderViewModelFactory<AuthViewModel>, AuthViewModelFactory>();

            //Scoped - one instance per scope
            services.AddScoped<INavigator, Navigator>();
            services.AddScoped<MainViewModel>();
            services.AddScoped<BuyViewModel>();
            services.AddScoped<SellViewModel>();
            services.AddScoped<PortfolioViewModel>();

            services.AddScoped<MainWindow>(s => new MainWindow(s.GetRequiredService<MainViewModel>()));

            return services.BuildServiceProvider();
        }
    }
}
