using Microsoft.Win32;
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
    /// Логика взаимодействия для NewDrink.xaml
    /// </summary>
    public partial class NewDrink : Page
    {
        public NewDrink()
        {
            InitializeComponent();
        }

        private void PicLoad_Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openDialog = new OpenFileDialog();
            openDialog.Filter = "Image files (*.BMP, *.JPG, *.GIF, *.TIF, *.PNG, *.ICO, *.EMF, *.WMF)|*.bmp;*.jpg;*.gif; *.tif; *.png; *.ico; *.emf; *.wmf";

            if (openDialog.ShowDialog() == true)
            {
                picpath.Text = openDialog.FileName.ToString();
                Drinkpic.Source = new BitmapImage(new Uri(openDialog.FileName));
            }
        }
    }
}
