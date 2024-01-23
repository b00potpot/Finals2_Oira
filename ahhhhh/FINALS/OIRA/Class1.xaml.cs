using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace OIRA
{


    public class MyViewModel : INotifyPropertyChanged
    {
        private decimal _balance = 1500;
        private string _lastOperation;
        private string[] _pinCode = new string[6];

        public decimal Balance
        {
            get { return _balance; }
            set
            {
                if (_balance != value)
                {
                    _balance = value;
                    OnPropertyChanged(nameof(Balance));
                }
            }
        }
        

        public string[] PinCode
        {
            get { return _pinCode; }
            set
            {
                if (_pinCode != value)
                {
                    _pinCode = value;
                    OnPropertyChanged(nameof(PinCode));
                }
            }
        }

        public string LastOperation
        {
            get { return _lastOperation; }
            set
            {
                if (_lastOperation != value)
                {
                    _lastOperation = value;
                    OnPropertyChanged(nameof(LastOperation));
                }
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void Withdraw(decimal amount)
        {
            if (_balance >= amount)
            {
                _balance -= amount;
                LastOperation = "Withdrawal";
                OnPropertyChanged(nameof(Balance));
            }
        }

        public void Deposit(decimal amount)
        {
            _balance += amount;
            LastOperation = "Deposit";
            OnPropertyChanged(nameof(Balance));
        }

    }
}