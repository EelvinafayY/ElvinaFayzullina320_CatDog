﻿using sr.DBConnection;
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
    /// Логика взаимодействия для PhotoCatPage.xaml
    /// </summary>
    public partial class PhotoCatPage : Page
    {
        public static List<Photoes> photoes {  get; set; }
        public static List<Pet> pets { get; set; }
        public PhotoCatPage()
        {
            InitializeComponent();
            photoes = new List<Photoes>(DBConnection.DBConnection.samrab.Photoes.ToList());
            pets = new List<Pet>(DBConnection.DBConnection.samrab.Pet.ToList());
            this.DataContext = this;
            CatRaPhotoLV.ItemsSource = new List<Photoes>(DBConnection.DBConnection.samrab.Photoes.Where(i => i.Id_Pet == 1).ToList());
            pets.Insert(0, new Pet() { Id_Employee = -1, Name = "Показать всё!" });
        }

        private void OpisanieTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            CatRaPhotoLV.ItemsSource = new List<Photoes>(DBConnection.DBConnection.samrab.Photoes.Where(i => i.Text.StartsWith(OpisanieTB.Text)));
        }

        private void IdPhotoCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var t = (IdPhotoCB.SelectedItem as Photoes).Id_Photo;
            CatRaPhotoLV.ItemsSource = DBConnection.DBConnection.samrab.Photoes.
                Where(i => i.Id_Photo == t).ToList();
        }
    }
}
