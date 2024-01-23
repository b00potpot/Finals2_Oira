using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
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

    public partial class Window2 : Window
    {
        private MyViewModel _viewModel;

        public Window2(MyViewModel viewModel)
        {
            InitializeComponent();
            _viewModel = viewModel;
            DataContext = _viewModel;
        }


        private void Withdraw_Click(object sender, RoutedEventArgs e)
        {
            Window3 pinWindow = new Window3(_viewModel);

           
            bool? pinResult = pinWindow.ShowDialog();

            if (pinResult == true)
            {
                
                if (decimal.TryParse(AmountWithdraw.Text, out decimal withdrawalAmount) && withdrawalAmount > 0)
                {
                    _viewModel.Withdraw(withdrawalAmount);
                    DisplayInformationInNotepad(_viewModel.LastOperation, withdrawalAmount);
                    Close();
                }
                else
                {
                    MessageBox.Show("Invalid withdrawal amount. Please enter a valid positive number.");
                }
            }
            else
            {
                
                MessageBox.Show("PIN entry canceled or incorrect. Withdrawal canceled.");
            }
        }






        private void DisplayInformationInNotepad(string transactionType, decimal amount)
        {
            string information;

            if (transactionType == "Withdrawal")
            {
                information = $"Username: Oira\r\nAmount Withdrawn: {amount}\r\nRemaining Balance: {_viewModel.Balance}\r\nDate: {DateTime.Now}\r\nTransaction: Withdrawal";
            }
            else if (transactionType == "Deposit")
            {
                information = $"Username: Oira\r\nAmount Deposited: {amount}\r\nRemaining Balance: {_viewModel.Balance}\r\nDate: {DateTime.Now}\r\nTransaction: Deposit";
            }
            else
            {
                MessageBox.Show("Invalid transaction type.");
                return;
            }

            try
            {
                using (StreamWriter sw = new StreamWriter("NotepadOutput.txt"))
                {
                    sw.Write(information);
                }

                Process.Start("notepad.exe", "NotepadOutput.txt");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error opening Notepad: {ex.Message}");
            }
        }

    }
}
      