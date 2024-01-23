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
using System.Windows.Shapes;

namespace OIRA
{
    
    public partial class Window1 : Window
    {
        private MyViewModel _viewModel;
        public Window1()
        {
            InitializeComponent();
            _viewModel = new MyViewModel();
        }

        private void Withdraw_Click(object sender, RoutedEventArgs e)
        {
            Window2 window2 = new Window2(_viewModel);
            window2.Show();
        }

        private void Deposit_Click(object sender, RoutedEventArgs e)
        {
            Window5 window5 = new Window5(_viewModel);
            window5.Show();
        }

        private void Inquiry_Click(object sender, RoutedEventArgs e)
        {
            Window4 window4 = new Window4();
            window4.Show();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Proceeding");
        }
    }
}
