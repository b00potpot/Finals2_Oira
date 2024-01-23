using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace OIRA
{
    
    public partial class MainWindow : Window
    {
        private const string CorrectUsername = "Oira";
        private const string CorrectPassword = "060705";
        public MainWindow()
        {
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
           
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            string enteredUsername = username.Text;
            string enteredPassword = password.Text;

            if (enteredUsername == CorrectUsername && enteredPassword == CorrectPassword)
            {
                
                Window1 window1 = new Window1();
                window1.Show();
                Close(); 
            }
            else
            {
                MessageBox.Show("Invalid username or password. Please try again.");
            }
        }
    }
}
