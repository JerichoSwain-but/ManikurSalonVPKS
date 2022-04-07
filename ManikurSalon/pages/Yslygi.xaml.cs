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

namespace ManikurSalon
{
    /// <summary>
    /// Логика взаимодействия для Yslygi.xaml
    /// </summary>
    public partial class Yslygi : Page
    {
        public Yslygi()
        {
            InitializeComponent();
            TipaYslygaComboBox.ItemsSource = ManikurSalonEntities.GetContext().Yslyga.ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (ContainerMaybe.ID_Stud == 0)
            {
                MessageBox.Show("Сначала выберите студию");
                return;
            }
            if (ContainerMaybe.ID_Yslyga_mg == 0)
            {
                MessageBox.Show("Сначала выберите услугу");
                return;
            }
            NavigationService nav = NavigationService.GetNavigationService(this);

            nav.Navigate(new Uri("/pages/ZapisPage.xaml", UriKind.Relative));
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            NavigationService nav = NavigationService.GetNavigationService(this);

            nav.Navigate(new Uri("/pages/StudPage.xaml", UriKind.Relative));
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Вы уже находитесь на данной странице!");
        }

        private void TipaYslygaComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var Yslyga = (Yslyga)TipaYslygaComboBox.SelectedItem;
            ContainerMaybe.ID_Yslyga_mg = Yslyga.ID_Yslyga;
            ContainerMaybe.YslygaName = Yslyga.NazvanieYslygi;
            MessageBox.Show("Вы выбрали услугу: " + Yslyga.NazvanieYslygi);
        }
    }
}
