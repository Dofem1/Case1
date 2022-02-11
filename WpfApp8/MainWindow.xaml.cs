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

namespace WpfApp8
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            List<Button> coin_buttons = new List<Button>() { One_button, Two_button, Five_button, Ten_button };
            int idmax = drinks.VendingMachineCoins.Max(id => id.CoinsId);
            for (int i = 0; i < idmax; i++)
            {
                VendingMachineCoins nowCoin = drinks.VendingMachineCoins.Single(id => id.CoinsId == (i + 1));
                if(nowCoin.IsActive == 0)
                {
                    coin_buttons[i].IsEnabled = false;
                }
            }

            Drinks_list.ItemsSource = drinks.Drinks.ToList();
        }

        public VendingMachinesEntities drinks = new VendingMachinesEntities();
        public int[] coins_insert = new int[4];

        private void Money_button_Click(object sender, RoutedEventArgs e)
        {
            switch ((sender as Button).Content)
            {
                case "1":
                    coins_insert[0]++;
                    break;
                case "2":
                    coins_insert[1]++;
                    break;
                case "5":
                    coins_insert[2]++;
                    break;
                case "10":
                    coins_insert[3]++;
                    break;
                default:
                    break;
            }
            Money_label.Content = Convert.ToInt32(Money_label.Content) + Convert.ToInt32((sender as Button).Content);
        }
        private void Count_button_Click(object sender, RoutedEventArgs e)
        {
            //Вывод количества монет-------------------------------------------
            int idmax = drinks.VendingMachineCoins.Max(id => id.CoinsId);
            int[] coins = new int[4];
            for (int i = 0; i < idmax; i++)
            {
                VendingMachineCoins nowCoin = drinks.VendingMachineCoins.Single(id => id.CoinsId == (i + 1));
                coins[i] = nowCoin.Count;
            }
            MessageBox.Show($"1 = {coins[0]}\n 2 = {coins[1]}\n 5 = {coins[2]}\n 10 = {coins[3]}\n");
            //Вывод количества монет-------------------------------------------

            //Расчёт сдачи----------------------------------------------------------------
            int money_out = Convert.ToInt32(Money_label.Content);
            
            int tens_out = money_out / 10;
            if(coins[3] < tens_out)
            {
                money_out -= coins[3] * 10;
                tens_out = coins[3];
            }
            else
            {
                money_out -= tens_out * 10;
            }

            int fives_out = money_out / 5;
            if (coins[2] < fives_out)
            {
                money_out -= coins[2] * 5;
                fives_out = coins[2];
            }
            else
            {
                money_out -= fives_out * 5;
            }
            

            int twos_out = money_out / 2;
            if (coins[1] < twos_out)
            {
                money_out -= coins[1] * 2;
                twos_out = coins[1];
            }
            else
            {
                money_out -= twos_out * 2;
            }

            int ones_out = money_out / 1;
            if (coins[0] < ones_out)
            {
                money_out -= coins[0] * 1;
                ones_out = coins[0];
            }
            else
            {
                money_out -= ones_out * 1;
            }

            coins[0] -= ones_out;
            coins[1] -= twos_out;
            coins[2] -= fives_out;
            coins[3] -= tens_out;

            MessageBox.Show($"Сдача:\n10 = {tens_out}\n5 = {fives_out}\n2 = {twos_out}\n1 = {ones_out}\nНедостача = {money_out}\nИтого = {Money_label.Content}");
            Money_label.Content = "0";
            for (int i = 0; i < idmax; i++)
            {
                VendingMachineCoins nowCoin = drinks.VendingMachineCoins.Single(id => id.CoinsId == (i + 1));
                nowCoin.Count =coins[i];
            }
            drinks.SaveChangesAsync();
            //Расчёт сдачи----------------------------------------------------------------
        }

        private void Drinks_list_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Drinks_list.SelectedItem != null)
            {
                int idmax = drinks.VendingMachineCoins.Max(id => id.CoinsId);
                for (int i = 0; i < idmax; i++)
                {
                    var nowCoin = drinks.VendingMachineCoins.Single(id => id.CoinsId == i + 1);
                    nowCoin.Count += coins_insert[i];
                    coins_insert[i] = 0;
                }
                drinks.SaveChangesAsync();

                if (Convert.ToInt32(Money_label.Content) >= Convert.ToInt32((Drinks_list.SelectedItem as Drinks).Cost))
                {
                    Money_label.Content = Convert.ToInt32(Money_label.Content) - Convert.ToInt32((Drinks_list.SelectedItem as Drinks).Cost);
                }
                else
                {
                    MessageBox.Show("Недостаточно денег");
                }
                Drinks_list.SelectedItem = null;
            }
        }

        private void adm_Click(object sender, RoutedEventArgs e)
        {
            Admin_Window admin_Window = new Admin_Window();
            admin_Window.ShowDialog();
        }
    }
}
