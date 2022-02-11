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

namespace WpfApp8.Pages
{
    /// <summary>
    /// Логика взаимодействия для Drinks.xaml
    /// </summary>
    public partial class Drinks : Page
    {
        public Drinks()
        {
            InitializeComponent();
            
            Drinks_list.ItemsSource = drinks.Drinks.ToList();
        } 
        public VendingMachinesEntities drinks = new VendingMachinesEntities();
        private void lstDrink_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Drink_Redact drink_Redact = new Drink_Redact();
            //Программа не позволяет 
            string name = (Drinks_list.SelectedItem as Drinks).Name;
            var drunk = drinks.Drinks.Single(sqlname => sqlname.Name == name);
            drink_Redact.Drink_name.Text = drunk.Name;
            drink_Redact.Cost_text.Text = drunk.Cost.ToString();
        }
    }
}
