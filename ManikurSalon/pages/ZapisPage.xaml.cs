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

namespace ManikurSalon.pages
{
    /// <summary>
    /// Логика взаимодействия для Zapis.xaml
    /// </summary>
    public partial class ZapisPage : Page
    {
        public ZapisPage()
        {
            InitializeComponent();
            List<MastersList> masters = new List<MastersList>();
            var mastersdb = ManikurSalonEntities.GetContext().Masters.ToList();
            foreach(var data in mastersdb)
            {
                masters.Add(new MastersList() { MasterID = data.ID_Masters, MasterName = data.SecondNameMaster + " " + data.NameMaster + " " + data.OtchestvoMaster });
            }
            StudBlock.Text = ContainerMaybe.StudName;
            YslygaBlock.Text = ContainerMaybe.YslygaName;
            MasterCombo.ItemsSource = masters;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Вы уже находитесь на данной странице!");
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            NavigationService nav = NavigationService.GetNavigationService(this);

            nav.Navigate(new Uri("/pages/StudPage.xaml", UriKind.Relative));
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            NavigationService nav = NavigationService.GetNavigationService(this);

            nav.Navigate(new Uri("/pages/Yslygi.xaml", UriKind.Relative));
        }

        private void PodZ_Click(object sender, RoutedEventArgs e)
        {
            var Master = (MastersList)MasterCombo.SelectedItem;
            if (Master == null)
            {
                MessageBox.Show("А мастера кто выберет?");
                return;
            }
            if (TimeZ.Text == "Введите время.")
            {
                MessageBox.Show("Введите время!");
                return;
            }
            if(TextName.Text == "Имя")
            {
                MessageBox.Show("Введите имя!");
                return;
            }
            if (TextSecond.Text == "Фамилия")
            {
                MessageBox.Show("Фамилию хочеца");
                return;
            }
            if (TextOtchestvo.Text == "Отчество")
            {
                MessageBox.Show("Введите Отчество!");
                return;
            }
            Zapis zapis = new Zapis();
            zapis.ID_stud = ContainerMaybe.ID_Stud;
            zapis.ID_Yslyga = ContainerMaybe.ID_Yslyga_mg;
            zapis.Name_Zakasik = TextName.Text;
            zapis.SecondName_Zakasik = TextSecond.Text;
            zapis.Otchestvo_Zakasik = TextOtchestvo.Text;
            zapis.Time = TimeZ.Text;
            zapis.ID_Master = Master.MasterID;
            ManikurSalonEntities.GetContext().Zapis.Add(zapis);
            ManikurSalonEntities.GetContext().SaveChanges();
            MessageBox.Show("Запись сохранена!");
        }
    }
    class MastersList
    {
        public int MasterID { get; set; }
        public string MasterName { get; set; }
    }
}
