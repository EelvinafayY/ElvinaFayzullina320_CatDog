using sr.DBConnection;
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

namespace sr.Pages
{
    /// <summary>
    /// Логика взаимодействия для catRaPage.xaml
    /// </summary>
    public partial class catRaPage : Page
    {
        public static List<Pet> pets { get; set; }
        public static List<Employee> employees { get; set; }
        public catRaPage()
        {
            InitializeComponent();
            pets = new List<Pet>(DBConnection.DBConnection.samrab.Pet.Where(i => i.Id_Pet == 1).ToList());
            employees = new List<Employee>(DBConnection.DBConnection.samrab.Employee.ToList());
            this.DataContext = this;
            CatRaLV.ItemsSource = new List<Pet>(DBConnection.DBConnection.samrab.Pet.Where(i => i.Id_Pet == 1).ToList());
        }

        private void PhotoBT_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PhotoCatPage());
        }
    }
}
