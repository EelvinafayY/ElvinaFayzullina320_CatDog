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
    /// Логика взаимодействия для PhotoDogPage.xaml
    /// </summary>
    public partial class PhotoDogPage : Page
    {
        public static List<Photoes> photoes { get; set; }
        public static List<Pet> pets { get; set; }
        public PhotoDogPage()
        {
            InitializeComponent();
            photoes = new List<Photoes>(DBConnection.DBConnection.samrab.Photoes.ToList());
            pets = new List<Pet>(DBConnection.DBConnection.samrab.Pet.ToList());
            this.DataContext = this;
            DogNubiPhotoLV.ItemsSource = new List<Photoes>(DBConnection.DBConnection.samrab.Photoes.Where(i => i.Id_Pet == 2).ToList());
        }

        private void OpisanieTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            DogNubiPhotoLV.ItemsSource = new List<Photoes>(DBConnection.DBConnection.samrab.Photoes.Where(i => i.Text.StartsWith(OpisanieTB.Text)));
        }

        private void IdPhotoCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Photoes cl = IdPhotoCB.SelectedItem as Photoes;
            IdPhotoCB.ItemsSource = new List<Photoes>(DBConnection.DBConnection.samrab.Photoes.Where(i => i.Id_Photo == cl.Id_Photo));
        }
    }
}
