using System;
using System.Collections.Generic;
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
    public partial class Window3 : Window
    
    {
        private MyViewModel _viewModel;

        public Window3(MyViewModel viewModel)
        {
            InitializeComponent();
            _viewModel = viewModel;
            DataContext = _viewModel;
        }

        private void SUBMIT_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateNumbers())
            {
                DisplayInformationInNotepad("PINValidation", 0);
            }
            else
            {
                MessageBox.Show("Invalid numbers. Please enter correct information.");
            }
        }

        public bool ValidateNumbers()
        {
            string correctPin = "012304";  
            return
                ValidateDigit(pincode_1.Text, correctPin[0]) &&
                ValidateDigit(pincode_2.Text, correctPin[1]) &&
                ValidateDigit(pincode_3.Text, correctPin[2]) &&
                ValidateDigit(pincode_4.Text, correctPin[3]) &&
                ValidateDigit(pincode_5.Text, correctPin[4]) &&
                ValidateDigit(pincode_6.Text, correctPin[5]);
        }

        public bool ValidateDigit(string input, char expectedDigit)
        {
            return input.Length == 1 && input[0] == expectedDigit;
        }



        private void DisplayInformationInNotepad(string transactionType, decimal amount)
        {
            string information;

            if (transactionType == "Deposit")
            {
                information = $"Username: Oira\r\nAmount Deposited: {amount}\r\nRemaining Balance: {_viewModel.Balance}\r\nDate: {DateTime.Now}\r\nTransaction: Deposit";
            }
            else if (transactionType == "Withdrawal")
            {
                information = $"Username: Oira\r\nAmount Withdrawn: {amount}\r\nRemaining Balance: {_viewModel.Balance}\r\nDate: {DateTime.Now}\r\nTransaction: Withdrawal";
            }
            else if (transactionType == "PINValidation")
            {
               
                return;
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


