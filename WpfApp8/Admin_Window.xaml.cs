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

namespace WpfApp8
{
    /// <summary>
    /// Логика взаимодействия для Admin_Window.xaml
    /// </summary>
    public partial class Admin_Window : Window
    {
        public Admin_Window()
        {
            InitializeComponent();
        }

        private void Coins_Click(object sender, RoutedEventArgs e)
        {
            Frame.NavigationService.Navigate(new Pages.Coins_page());
        }

        private void Drinks_Click(object sender, RoutedEventArgs e)
        {
            Frame.NavigationService.Navigate(new Pages.Drinks());
        }

        private void Doc_Click(object sender, RoutedEventArgs e)
        {
            Frame.NavigationService.Navigate(new Pages.Document());
        }

        private void Exit_button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

    }
}
