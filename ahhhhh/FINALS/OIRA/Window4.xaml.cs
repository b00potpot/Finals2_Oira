using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    
    public partial class Window4 : Window
    {
        public Window4()
        {
            InitializeComponent();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            Window1 window1 = new Window1();
            window1.Show();
            Close();
        }

        private void Facebook_Click(object sender, RoutedEventArgs e)
        {
            OpenWebPage("https://www.facebook.com/beatriceclaire.oira.37");
        }
        private void InstagramButton_Click(object sender, RoutedEventArgs e)
        {

            OpenWebPage("https://www.instagram.com/forgetmnots2304/");
        }
       
        private void OpenWebPage(string url)
        {
            try
            {
                Process.Start(url);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error opening the web page: {ex.Message}");
            }
        }


    }
}
