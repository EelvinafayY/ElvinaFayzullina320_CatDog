using Microsoft.Win32;
using sr.DBConnection;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Policy;
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
    /// Логика взаимодействия для PlusPhotoCatPage.xaml
    /// </summary>
    public partial class PlusPhotoCatPage : Page
    {
        public static List<Pet> pets { get; set; }
        public static List<Employee> employees { get; set; }
        public static List<Photoes> photoes { get; set; }

        public static Photoes photo = new Photoes();
        public PlusPhotoCatPage()
        {
            InitializeComponent();
            pets = new List<Pet>(DBConnection.DBConnection.samrab.Pet.ToList());
            employees = new List<Employee>(DBConnection.DBConnection.samrab.Employee.ToList());
            photoes = new List<Photoes>(DBConnection.DBConnection.samrab.Photoes.ToList());
            this.DataContext = this;
        }

        private void SaveBT_Click(object sender, RoutedEventArgs e)
        {
            photo.Text = OpisTB.Text;
            var a = 2;
            if(IdPetCB.Text == "Котенок Ра")
            {
                a = 1;
            }
            var b = 2;
            if(IdEmployeeCB.Text == "Андрей Пирокинезис")
            {
                b = 1;
            }
            photo.Id_Pet = a;

            DBConnection.DBConnection.samrab.Photoes.Add(photo);

            DBConnection.DBConnection.samrab.SaveChanges();


            if(a == 1 && b == 1)
            {
                NavigationService.Navigate(new PhotoCatPage());
            }
            if(a == 2 && b == 2)
            {
                NavigationService.Navigate(new PhotoDogPage());
            }
            if (a == 2 && b == 1)
            {
                NavigationService.Navigate(new catRaPage());
            }
            if (a == 1 && b == 2)
            {
                NavigationService.Navigate(new dogNubiPage());
            }
            
        }

        private void AddPhotoBT_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog()
            {
                Filter = "*.png|*.png|*.jpeg|*.jpeg|*.jpg|*.jpg"
            };

            if (openFileDialog.ShowDialog().GetValueOrDefault())
            {
                photo.Photo = File.ReadAllBytes(openFileDialog.FileName);
                Image.Source = new BitmapImage(new Uri(openFileDialog.FileName));
            }
        }

       
    }
}
