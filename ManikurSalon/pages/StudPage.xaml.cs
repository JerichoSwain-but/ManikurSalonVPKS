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
    /// Логика взаимодействия для Stud.xaml
    /// </summary>
    public partial class StudPage : Page
    {
        public StudPage()
        {
            InitializeComponent();
            GetStud();
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

            nav.Navigate(new Uri("/pages/Yslygi.xaml", UriKind.Relative));
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Вы уже находитесь на данной странице!");
        }

        private void GetStud()
        {
            var stud = ManikurSalonEntities.GetContext().Stud.ToList();

            var StudList = new List<StudConverted>();

            foreach (var item in stud)
            {
                StudList.Add(new StudConverted()
                {
                    ID_stud = item.ID_stud,
                    Name = item.Name,
                    Opisanie = item.Opisanie
                });
            }

            StudListView.ItemsSource = StudList;
        }

        public class StudConverted
        {
            public int ID_stud { get; set; }
            public string Name { get; set; }
            public string Opisanie { get; set; }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            var Element = sender as Button;
            var StudDA = Element.DataContext as StudConverted;
            ContainerMaybe.ID_Stud = StudDA.ID_stud;
            ContainerMaybe.StudName = StudDA.Name;
            MessageBox.Show("Вы выбрали студию: " + StudDA.Name);
        }
    }
}
