using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace DemoCryptoTrader.WPF.Models
{
    public class ObservableObject : INotifyPropertyChanged
    {
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
