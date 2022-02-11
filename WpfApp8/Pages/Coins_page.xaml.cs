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
    /// Логика взаимодействия для Coins_page.xaml
    /// </summary>
    public partial class Coins_page : Page
    {
        public Coins_page()
        {
            InitializeComponent();


            CoinTxt = new List<TextBox> { txt1rubles, txt2rubles, txt5rubles, txt10rubles };
            CoinCh = new List<CheckBox>() { ch1rubles, ch2rubles, ch5rubles, ch10rubles };
            CoinLbl = new List<Label>() { lbl1rubles, lbl2rubles, lbl5rubles, lbl10rubles };

            for (int i = 0; i < CoinCh.Count; i++)
            {
                string denom = CoinLbl[i].Content.ToString();
                var u = _VME.Coins.Single(a => a.Denomination.ToString() == denom);
                
                var q = _VME.VendingMachineCoins.Single(d => d.CoinsId == u.Id);
                CoinTxt[i].Text = q.Count.ToString();
                var active = q.IsActive;
                if (active == 1)
                {
                    CoinCh[i].IsChecked = true;
                }
                else
                {
                    CoinCh[i].IsChecked = false;
                }
            }
        }

        VendingMachinesEntities _VME = new VendingMachinesEntities();
        List<TextBox> CoinTxt;
        List<CheckBox> CoinCh;
        List<Label> CoinLbl;

        private void btnBlockCoins_Click(object sender, RoutedEventArgs e)
        {
            
            for (int i = 0; i < CoinCh.Count; i++)
            {
                string denom = CoinLbl[i].Content.ToString();
                var u = _VME.Coins.Single(a => a.Denomination.ToString() == denom);

                var q = _VME.VendingMachineCoins.Single(d => d.CoinsId == u.Id);
                q.Count = Convert.ToInt32(CoinTxt[i].Text);
                if (CoinCh[i].IsChecked == true)
                {
                    q.IsActive = 1;
                }
                else
                {
                    q.IsActive = 0;
                }
                _VME.SaveChanges();
            }
        }
    }
}
