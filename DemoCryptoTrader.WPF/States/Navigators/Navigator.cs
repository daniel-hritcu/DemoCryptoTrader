using DemoCryptoTrader.WPF.Commands;
using DemoCryptoTrader.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;

namespace DemoCryptoTrader.WPF.States.Navigators
{
    public class Navigator : INavigator, INotifyPropertyChanged
    {
        public ViewModelBase _currentViewModel { get; set; }

        public ViewModelBase CurrentViewModel 
        {
            get 
            {
                return _currentViewModel;
            }
            set
            {
                _currentViewModel = value;
                OnPropertyChanged(nameof(CurrentViewModel));
            }
        }





       /* I don't like the command beeing in the Navigator Object,
        * but since the command is in it's own class, there should 
        * not be a big problem.
        */
        public ICommand UpdateCurrentViewModelCommand => new UpdateCurrentViewModelCommand(this);

        public event PropertyChangedEventHandler PropertyChanged;

        /*
         * The UI sees that this class implements the INotifyPropertyChanged,
         * so it will subscribe to the PropertyChanged event, it will update
         * the binding that has the property name associated with the EventHandler.
         */

        protected void OnPropertyChanged(string propertyName) 
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}